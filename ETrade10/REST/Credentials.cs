using System.Collections.Generic;
using static OkonkwoETrade10.REST.ETrade10;

namespace OkonkwoETrade10.REST
{
   public class Credentials
   {
      public EEnvironment environment { get; set; }
      public string accountId { get; set; }
      public string userName { get; set; }
      public string password { get; set; }
      public string consumerKey { get; set; }
      public string consumerSecret { get; set; }
      public KeyValuePair<string, string> consumerCookie { get; set; }
      //
      public RequestTokenResponse RequestToken { get; set; }
      public AccessTokenResponse AccessToken { get; set; }
   }
}
