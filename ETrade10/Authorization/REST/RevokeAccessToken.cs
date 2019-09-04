using System;
using System.Net.Http;
using System.Threading.Tasks;
using OkonkwoETrade10.Authorization.OkonkwoOAuth;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This method revokes an access token that was granted for the consumer key. 
      /// Once the token is revoked, it no longer grants access to E*TRADE data. 
      /// We strongly recommend revoking the access token once your application no longer needs access to 
      /// the user’s E*TRADE account. 
      /// In the event of a security compromise, a revoked token is useless to a malicious entity.
      /// https://apisb.etrade.com/docs/api/authorization/revoke_access_token.html
      /// </summary>
      /// <param name="requestTokenInfo"></param>
      /// <param name="verifier"></param>
      /// <returns>an access token</returns>
      protected async Task<AccessTokenInfo> RevokeAccessTokenAsync(RequestTokenInfo requestTokenInfo, string verifier)
      {
         try
         {
            return await OAuthSvc.GetAccessTokenAsync(HttpMethod.Get, requestTokenInfo.oauth_token, requestTokenInfo.oauth_token_secret, verifier);
         }
         catch (Exception ex)
         {
            throw new Exception("RevokeAccessTokenAsync failed: ", ex);
         }
      }
   }
}
