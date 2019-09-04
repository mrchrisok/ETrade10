using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using OkonkwoETrade10.Accounts;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// This API provides portfolio information for a selected brokerage account.
      /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html
      /// </summary>
      /// <param name="accountIdKey">The unique account key</param>
      /// <returns>Detailed portfolio information for a selected brokerage account.</returns>
      public static async Task<PortfolioResponse> ViewPortfolioAsync(string accountIdKey, PortfolioParameters parameters)
      {
         string uri = ServerUri(EServer.Accounts) + $"{accountIdKey}/porfolio";

         var requestParams = ConvertToDictionary(parameters);
         var headers = new WebHeaderCollection { { HttpRequestHeader.Accept, "application/json" } };

         var response = await MakeRequestAsync<PortfolioResponse, PortfolioErrorResponse>(uri, null, headers, requestParams);

         return response;
      }

      public class PortfolioParameters
      {
         /// <summary>
         /// The number of positions to return in the response. If not specified, defaults to 50. Used for paging
         /// </summary>
         public int count { get; set; }

         /// <summary>
         /// The sort by query. Sorting done based on the column specified.
         /// </summary>
         public string sortBy { get; set; }

         /// <summary>
         /// The sort order. Default DESC.
         /// </summary>
         public string sortOrder { get; set; }

         /// <summary>
         /// The market session. Default: REGULAR.
         /// </summary>
         public string marketSession { get; set; }

         /// <summary>
         /// It gives the total values of the portfolio. Default: false.
         /// </summary>
         public bool totalsRequired { get; set; }

         /// <summary>
         /// The view query. Default: Quick.
         /// </summary>
         public string view { get; set; }
      }
   }

   /// <summary>
   /// The GET success response.
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/PortfolioResponse
   /// </summary>
   public class PortfolioResponse : Response
   {
      /// <summary>
      /// The portfolio totals
      /// </summary>
      public Totals totals { get; set; }

      /// <summary>
      /// The summary of the requested Account.
      /// </summary>
      public List<AccountPortfolio> accountPortfolio { get; set; }
   }

   /// <summary>
   /// The GET error response.
   /// </summary>
   public class PortfolioErrorResponse : ErrorResponse
   {
   }
}
