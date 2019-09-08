using System.Threading.Tasks;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   //https://oauth.net/core/1.0a/
   //https://oauth1.wp-api.org/docs/basics/Auth-Flow.html
   public class ETradeOAuth10 : OkonkwoOAuthBase
   {
      public ETradeOAuth10(OAuthConfig config) : base(config)
      {
      }

      /// <summary>
      /// 6.2.1. Consumer Directs the User to the Service Provider
      /// </summary>
      /// <param name="parameters"></param>
      /// <returns></returns>
      public override string GetAuthorizationUrl(OAuthParameters parameters)
      {
         if (parameters.Binding == OAuthParametersBinding.QueryString)
         {
            string baseUrl = base.GetAuthorizationUrl(parameters);
            //
            return baseUrl.Replace("oauth_consumer_key", "key").Replace("oauth_token", "token");
         }

         return parameters.Url;
      }

      public virtual async Task<AccessTokenInfo> RenewAccessTokenAsync(OAuthParameters parameters)
      {
         var accessTokenInfo = await SendTokenRequestAsync<AccessTokenInfo>("renew-access", parameters);

         _isAuthorized = true;

         return accessTokenInfo;
      }

      public virtual async Task<AccessTokenInfo> RevokeAccessTokenAsync(OAuthParameters parameters)
      {
         var accessTokenInfo = await SendTokenRequestAsync<AccessTokenInfo>("revoke-access", parameters);

         _isAuthorized = false;

         return accessTokenInfo;
      }
   }
}
