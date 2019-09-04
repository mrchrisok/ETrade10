using System.Collections.Generic;

namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/Redemption
   /// </summary>
   public class Redemption
   {
      /// <summary>
      /// The minimum month for redemption of mutual fund shares.
      /// </summary>
      public string minMonth { get; set; }

      /// <summary>
      /// Fee percent charged to user by fund for redemption of mutual fund shares.
      /// </summary>
      public string feePercent { get; set; }

      /// <summary>
      /// If the value is '1' it indicated that the fund is front end load.
      /// </summary>
      public string isFrontEnd { get; set; }

      /// <summary>
      /// Potential values are low, high, and percent.
      /// Low denotes the lower timeline for the particular period of the fund.
      /// High denotes the higher timeline for the particular period of the fund.
      /// Percent denotes the percent that will be charged between the lower and higher timeline for that particular period
      /// </summary>
      public List<Values> frontEndValues { get; set; }

      /// <summary>
      /// If the value is 4, time line is represented in years.
      /// If the value is 3, time line is represented in months.
      /// If the value is 10, time line is represented in days.
      /// </summary>
      public string redemptionDurationType { get; set; }

      /// <summary>
      /// This value indicates whether the fund is back end load function.
      /// </summary>
      public string isSales { get; set; }

      /// <summary>
      /// If the value is 4, time line is represented in years.
      /// If the value is 3, time line is represented in months.
      /// If the value is 10, time line is represented in days.
      /// </summary>
      public string salesDurationType { get; set; }

      /// <summary>
      /// Potential values are low, high, and percent.
      /// Low denotes the lower timeline for the particular period of the fund.
      /// High denotes the higher timeline for the particular period of the fund.
      /// Percent denotes the percent that will be charged between the lower and higher timeline for that particular period.
      /// </summary>
      public List<Values> salesValues { get; set; }
   }
}
