namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public class RequestTokenInfo : TokenInfo
   {
      public string oauth_callback_confirmed { get; set; }
   }

   public class AccessTokenInfo : TokenInfo
   {
   }

   public abstract class TokenInfo
   {
      public string oauth_token { get; set; }
      public string oauth_token_secret { get; set; }
   }
}
