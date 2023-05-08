﻿using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Providers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Application
{
    public interface IOAuth2Provider
    {
        Task<string> GetAuthorizationUrlAsync(string state, string redirectUri);
        Task<TokenResponse> RequestAccessTokenAsync(string code, string redirectUri);
        Task<UserInfoResponse> GetUserInfoAsync(string accessToken);
        Task<TokenResponse> RefreshAccessTokenAsync(string refreshToken);
    }

    public class OAuth2ProviderFactory
    {
        public IOAuth2Provider CreateProvider(OAuth2ProviderSettings settings)
        {
            return new GenericOAuth2Provider(settings);
        }

        private class GenericOAuth2Provider : IOAuth2Provider
        {
            private readonly OAuth2ProviderSettings _settings;

            public GenericOAuth2Provider(OAuth2ProviderSettings settings)
            {
                _settings = settings;
            }
            /// <summary>
            /// Return URL to use for getting code
            /// </summary>
            /// <param name="state">
            ///  In the GetAuthorizationUrlAsync method, the state parameter is a random string generated by your application to protect against CSRF (Cross-Site Request Forgery) attacks. It is used to ensure that the response from the OAuth2 provider is associated with the request your application made. When the provider redirects the user back to your application, the state value should be the same as what you initially sent. You should compare these values to make sure they match before processing the response.
            /// </param>
            /// <param name="redirectUri"></param>
            /// <returns></returns>
            public async Task<string> GetAuthorizationUrlAsync(string state, string redirectUri)
            {
                return await Task.Run(() =>
                {
                    var queryParams = new Dictionary<string, string>
            {
                {"client_id", _settings.ClientId},
                {"redirect_uri", redirectUri},
                {"response_type", "code"},
                {"scope", string.Join(" ", _settings.Scopes)},
                {"state", state}
            };

                    return QueryHelpers.AddQueryString(_settings.AuthorizationEndpoint, queryParams);
                });
            }


            public async Task<TokenResponse> RequestAccessTokenAsync(string code, string redirectUri)
            {
                using var httpClient = new HttpClient();

                var requestContent = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("client_id", _settings.ClientId),
                new KeyValuePair<string, string>("client_secret", _settings.ClientSecret),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("grant_type", "authorization_code")
            });

                var response = await httpClient.PostAsync(_settings.TokenEndpoint, requestContent);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to request access token");
                }

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TokenResponse>(content);
            }
            public async Task<TokenResponse> RefreshAccessTokenAsync(string refreshToken)
            {
                using var httpClient = new HttpClient();

                var requestContent = new FormUrlEncodedContent(new[]
                {
            new KeyValuePair<string, string>("client_id", _settings.ClientId),
            new KeyValuePair<string, string>("client_secret", _settings.ClientSecret),
            new KeyValuePair<string, string>("refresh_token", refreshToken),
            new KeyValuePair<string, string>("grant_type", "refresh_token")
        });

                var response = await httpClient.PostAsync(_settings.TokenEndpoint, requestContent);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to refresh access token");
                }

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<TokenResponse>(content);
            }
            public async Task<UserInfoResponse> GetUserInfoAsync(string accessToken)
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await httpClient.GetAsync(_settings.UserinfoEndpoint);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to request user info");
                }

                var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonConvert.DeserializeObject<UserInfoResponse>(content);
            }
        }
    }
}
