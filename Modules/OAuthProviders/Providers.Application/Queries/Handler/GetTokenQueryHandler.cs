using Core.Queries;
using Core.Responses;
using Microsoft.EntityFrameworkCore;
using Providers.Domain;
using Providers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Application.Queries.Handler
{
    
    public class GetTokenQueryHandler : IQueryHandler<GetTokenQuery, ResponseResult>
    {
        private readonly ProviderContext _dbContext;
        private readonly OAuth2ProviderFactory _oauth2ProviderFactory;
        public GetTokenQueryHandler(ProviderContext dbContext, OAuth2ProviderFactory oauth2ProviderFactory)
        {
            _dbContext = dbContext;
            _oauth2ProviderFactory = oauth2ProviderFactory;
        }
        public async Task<ResponseResult> Handle(GetTokenQuery query, CancellationToken cancellationToken)
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

            // Get the active OAuthToken for this provider
            var providerId = providerdata.Id;
            var activeToken = await _dbContext.OAuthTokenEntries.Where(t => t.ProviderID == providerId && t.IsActive).FirstOrDefaultAsync();
            var provider = _oauth2ProviderFactory.CreateProvider(providerdata);
            // Check if the token is expired
            if (activeToken != null && activeToken.ExpireTime < DateTime.UtcNow)
            {
                // Get a new token using the refresh token
                
                var newToken = await provider.RequestAccessTokenAsync(activeToken.RefreshToken, providerdata.RedirectUri);

                // Set the old token to inactive
                activeToken.IsActive = false;

                // Add the new token to the database
                var newOAuthToken = new OAuthToken
                {
                    AccessToken = newToken.AccessToken,
                    TokenType = newToken.TokenType,
                    ExpiresIn = newToken.ExpiresIn,
                    RefreshToken = newToken.RefreshToken,
                    IssuedAt = DateTime.UtcNow,
                    IsActive = true,
                    State = activeToken.State,
                    Provider = activeToken.Provider,
                    ExpireTime = DateTime.UtcNow.AddSeconds(newToken.ExpiresIn),
                    ProviderID = activeToken.ProviderID
                };
                _dbContext.OAuthTokenEntries.Add(newOAuthToken);
                await _dbContext.SaveChangesAsync();

                // Return the new token
                return new ResponseResult
                {
                    Success = true,
                    Data = newOAuthToken.AccessToken,
                    TotalRecords = 1
                };
            }

            // If there's no active token or it's expired, return the authorization URL
            var authorizationUrl = await provider.GetAuthorizationUrlAsync(activeToken?.State, providerdata.RedirectUri);

            return new ResponseResult
            {
                Success = true,
                Data = authorizationUrl,
                TotalRecords = 1
            };
        }

    }
}
