using System.Collections.Generic;

namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/AccountPortfolio
   /// </summary>
   public class AccountPortfolio
   {
      /// <summary>
      /// Numeric account ID
      /// </summary>
      public string accountId { get; set; }

      /// <summary>
      /// The next account portfolio item
      /// </summary>
      public string next { get; set; }

      /// <summary>
      /// The total number of pages
      /// </summary>
      public int totalNoOfPages { get; set; }

      /// <summary>
      /// The next page number
      /// </summary>
      public string nextPageNo { get; set; }

      /// <summary>
      /// Container for one or more account position elements
      /// </summary>
      public List<Position> position { get; set; }
   }
}
