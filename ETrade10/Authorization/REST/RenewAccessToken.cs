using System;
using System.Net.Http;
using System.Threading.Tasks;
using OkonkwoETrade10.Authorization.OkonkwoOAuth;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// Renews the OAuth access token after two hours or more of inactivity.
      /// https://apisb.etrade.com/docs/api/authorization/renew_access_token.html
      /// </summary>
      /// <param name="requestTokenInfo"></param>
      /// <param name="verifier"></param>
      /// <returns>an access token</returns>
      protected async Task<AccessTokenInfo> RenewAccessTokenAsync(RequestTokenInfo requestTokenInfo, string verifier)
      {
         try
         {
            return await OAuthSvc.GetAccessTokenAsync(HttpMethod.Get, requestTokenInfo.oauth_token, requestTokenInfo.oauth_token_secret, verifier);
         }
         catch (Exception ex)
         {
            throw new Exception("RenewAccessTokenAsync failed: ", ex);
         }
      }
   }
}
