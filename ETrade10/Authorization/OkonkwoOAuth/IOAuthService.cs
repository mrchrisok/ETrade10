using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public interface IOAuthService
   {
      void Initialize(OAuthConfig config);
      AuthenticationHeaderValue GetOAuthHeader(HttpMethod httpMethod, string url, Dictionary<string, string> parameters);
      string GetOAuthHeaderValue(HttpMethod httpMethod, string url, Dictionary<string, string> parameters);
      //
      Task<RequestTokenInfo> GetRequestTokenAsync(OAuthParameters parameters);
      Task<AccessTokenInfo> GetAccessTokenAsync(OAuthParameters parameters);
      string GetAuthorizationUrl(OAuthParameters parameters);
      Task<AccessTokenInfo> RenewAccessTokenAsync(OAuthParameters tokenParameters);
      Task<AccessTokenInfo> RevokeAccessTokenAsync(OAuthParameters tokenParameters);
   }
}
