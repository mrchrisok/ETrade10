using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public interface IOkonkwoOAuth
   {
      Task<RequestTokenInfo> GetRequestTokenAsync(HttpMethod httpMethod, List<string> additionalParameters = null);
      Task<AccessTokenInfo> GetAccessTokenAsync(HttpMethod httpMethod, string requestToken, string requestTokenSecret, string verifier);
      string GetAuthorizationUrl(string requestToken, string callbackUrl = null);
      AuthenticationHeaderValue GetOAuthHeader(HttpMethod httpMethod, string accessToken, string accessTokenSecret, string url, string realm);
      string GetOAuthHeaderValue(HttpMethod httpMethod, string accessToken, string accessTokenSecret, string url, string realm);
   }
}
