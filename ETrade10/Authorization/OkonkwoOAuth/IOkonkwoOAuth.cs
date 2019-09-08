using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public interface IOkonkwoOAuth
   {
      Task<RequestTokenInfo> GetRequestTokenAsync(OAuthParameters parameters);
      Task<AccessTokenInfo> GetAccessTokenAsync(OAuthParameters parameters);
      string GetAuthorizationUrl(OAuthParameters parameters);
      AuthenticationHeaderValue GetOAuthHeader(HttpMethod httpMethod, string url, Dictionary<string, string> parameters);
      string GetOAuthHeaderValue(HttpMethod httpMethod, string url, Dictionary<string, string> parameters);
   }
}
