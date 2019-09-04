using System.Collections.Generic;

namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-account-v1.html#/definitions/Accounts
   /// </summary>
   public class Accounts
   {
      /// <summary>
      /// Display the type, description for each of the user's accounts as well as a detail display for each account.
      /// </summary>
      public List<Account> account { get; set; }
   }
}
