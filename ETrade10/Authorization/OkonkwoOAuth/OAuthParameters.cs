using System.Collections.Generic;
using System.Net.Http;

namespace OkonkwoETrade10.Authorization.OkonkwoOAuth
{
   public enum OAuthParametersBinding
   {
      Header,
      Body,
      QueryString
   }

   public class OAuthParameters
   {
      public HttpMethod HttpMethod { get; set; }
      public string Url { get; set; }
      public Dictionary<string, string> Values { get; set; }
      public OAuthParametersBinding Binding { get; set; }
   }
}
