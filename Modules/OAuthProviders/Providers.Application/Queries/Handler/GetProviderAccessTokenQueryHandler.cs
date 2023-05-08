using Core.Queries;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using Providers.Domain;
using Providers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Application.Queries.Handler
{
    
    public class GetProviderAccessTokenQueryHandler : IQueryHandler<GetProviderAccessTokenQuery, ResponseResult>
    {
        private readonly ProviderContext _dbContext;
        private readonly OAuth2ProviderFactory _oauth2ProviderFactory;
        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        public GetProviderAccessTokenQueryHandler(ProviderContext dbContext, OAuth2ProviderFactory oauth2ProviderFactory)
        {
            _dbContext = dbContext;
            _oauth2ProviderFactory = oauth2ProviderFactory;
        }
        public async Task<ResponseResult> Handle(GetProviderAccessTokenQuery query, CancellationToken cancellationToken)
        {
            OAuthToken oAuthToken;

            // Obtain the lock so that only one instance of this code runs at a time.
            await _semaphoreSlim.WaitAsync();
            try
            {
                var providerdata = await _dbContext.ProviderSettingsEntries.Where(c => c.Name == query.ProviderName).FirstOrDefaultAsync();

                oAuthToken = await _dbContext.OAuthTokenEntries
                    .FirstOrDefaultAsync(x => x.Provider == query.ProviderName
                        && x.IsActive
                        && x.ExpireTime > DateTime.UtcNow);
                if (oAuthToken == null)
                {
                    IOAuth2Provider provider = _oauth2ProviderFactory.CreateProvider(providerdata);
                    var token = await provider.RequestAccessTokenAsync(query.Code, providerdata.RedirectUri);

                    if (token != null)
                    {
                        // Set IsActive to false for older token entries.
                        var expiredTokens = await _dbContext.OAuthTokenEntries
                            .Where(x => x.Provider == query.ProviderName && x.IsActive && x.ExpireTime < DateTime.UtcNow)
                            .ToListAsync();

                        foreach (var expiredToken in expiredTokens)
                        {
                            expiredToken.IsActive = false;
                        }

                        oAuthToken = new OAuthToken
                        {
                            AccessToken = token.AccessToken,
                            TokenType = token.TokenType,
                            ExpiresIn = token.ExpiresIn,
                            RefreshToken = token.RefreshToken,
                            IssuedAt = DateTime.UtcNow,
                            IsActive = true,
                            State = query.State,
                            Provider = query.ProviderName,
                            ExpireTime = DateTime.UtcNow.AddSeconds(token.ExpiresIn)
                        };
                        _dbContext.OAuthTokenEntries.Add(oAuthToken);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
            finally
            {
                // Release the lock.
                _semaphoreSlim.Release();
            }

            if (oAuthToken == null)
            {
                return new ResponseResult
                {
                    Success = false,
                    Message = "Failed to obtain access token.",
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }

            return new ResponseResult
            {
                Success = true,
                Data = oAuthToken,
                TotalRecords = 1
            };
        }
        public async Task<ResponseResult> Handle1(GetProviderAccessTokenQuery query)
        {
            var providerdata = await _dbContext.ProviderSettingsEntries.Where(c => c.Name == query.ProviderName).FirstOrDefaultAsync();

            if (providerdata == null)
            {
                return new ResponseResult
                {
                    Success = false,
                    Message = "Provider not found",
                    StatusCode = HttpStatusCode.NotFound
                };
            }
            IOAuth2Provider provider = _oauth2ProviderFactory.CreateProvider(providerdata);
            var token = await provider.RequestAccessTokenAsync(query.Code, providerdata.RedirectUri);
            if (token != null)
            {
                var oAuthToken = new OAuthToken
                {
                    AccessToken = token.AccessToken,
                    TokenType = token.TokenType,
                    ExpiresIn = token.ExpiresIn,
                    RefreshToken = token.RefreshToken,
                    IssuedAt = DateTime.UtcNow,
                    IsActive = true,
                    State = query.State,
                    Provider = query.ProviderName,
                    ExpireTime = DateTime.UtcNow.AddSeconds(token.ExpiresIn),
                    ProviderID = providerdata.Id // assuming you have a property called ProviderID in your TokenResponse model
                };

                // find all tokens with the same Provider and ProviderID as the new token
                var oldTokens = await _dbContext.OAuthTokenEntries.Where(t => t.Provider == oAuthToken.Provider && t.ProviderID == oAuthToken.ProviderID).ToListAsync();

                // set IsActive to false for each old token
                foreach (var oldToken in oldTokens)
                {
                    oldToken.IsActive = false;
                }

                _dbContext.OAuthTokenEntries.Add(oAuthToken);
                await _dbContext.SaveChangesAsync();
            }

            //Todo Saving Token In Database for use
            return new ResponseResult
            {
                Success = true,
                Data = token,
                TotalRecords = 1
            };
        }

    }
}
