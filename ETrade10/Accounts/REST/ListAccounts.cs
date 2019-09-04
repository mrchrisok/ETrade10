using System.Threading.Tasks;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API returns a list of E*TRADE accounts for the current user.
      /// https://apisb.etrade.com/docs/api/account/api-account-v1.html
      /// </summary>
      /// <returns>The information returned includes account type, mode, and details.</returns>
      public async Task<Accounts.Accounts> ListAccountsAsync()
      {
         string uri = ServerUri(EServer.Accounts) + "list";

         var response = await MakeRequestAsync<AccountListResponse, AccountListErrorResponse>(uri);
         return response.accounts;
      }
   }

   /// <summary>
   /// The GET success response received from the accounts
   /// </summary>
   public class AccountListResponse : Response
   {
      /// <summary>
      /// List of accounts
      /// </summary>
      public Accounts.Accounts accounts;
   }

   /// <summary>
   /// The GET error response received from the accounts
   /// </summary>
   public class AccountListErrorResponse : ErrorResponse
   {
   }
}
