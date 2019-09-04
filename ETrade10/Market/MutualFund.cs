using System.Collections.Generic;

namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/MutualFund
   /// </summary>
   public class MutualFund
   {
      /// <summary>
      /// The description of the security; for example, company name
      /// </summary>
      public string symbolDescription { get; set; }

      /// <summary>
      /// The identifier for the security
      /// </summary>
      public string cusip { get; set; }

      /// <summary>
      /// The dollar change of the last price from the previous close
      /// </summary>
      public decimal changeClose { get; set; }

      /// <summary>
      /// The official price at the close of the previous trading day
      /// </summary>
      public decimal previousClose { get; set; }

      /// <summary>
      /// An indicator(yes or no) whether or not there is a fee applicable for the security trasanction
      /// </summary>
      public string transactionFee { get; set; }

      /// <summary>
      /// The redemption fee applicable for the security transaction
      /// </summary>
      public string earlyRedemptionFee { get; set; }

      /// <summary>
      /// An indicator to inform if the mutual fund is available for new buy and sell orders
      /// </summary>
      public string availability { get; set; }

      /// <summary>
      /// The minimum initial investment required to purchase the fund
      /// </summary>
      public decimal initialInvestment { get; set; }

      /// <summary>
      /// The minimum subsequent investment amount
      /// </summary>
      public decimal subsequentInvestment { get; set; }

      /// <summary>
      /// The type of fund family the mutual fund belongs to
      /// </summary>
      public string fundFamily { get; set; }

      /// <summary>
      /// The name of the mutual fund
      /// </summary>
      public string fundName { get; set; }

      /// <summary>
      /// The percentage change of the last price from the previous close
      /// </summary>
      public decimal changeClosePercentage { get; set; }

      /// <summary>
      /// The time the last trade was placed
      /// </summary>
      public long timeOfLastTrade { get; set; }

      /// <summary>
      /// The Net Access Value (NAV) is the fund's per share market value; that is, the bid price investors pay to purchase fund shares
      /// </summary>
      public decimal netAssetValue { get; set; }

      /// <summary>
      /// The Public Offering Price (POP) is the price at which shares are sold to public; for funds without sales commission (that is, load), POP is equal to NAV
      /// </summary>
      public decimal publicOfferPrice { get; set; }

      /// <summary>
      /// The expense ratio of the fund after application of expense waivers and reimbursements
      /// </summary>
      public decimal netExpenseRatio { get; set; }

      /// <summary>
      /// The fund's total annual operating expense ratio gross of any fee waivers or expense reimbursements
      /// </summary>
      public decimal grossExpenseRatio { get; set; }

      /// <summary>
      /// The cut-off time for the purchase and redemption of mutual fund shares
      /// </summary>
      public long orderCutoffTime { get; set; }

      /// <summary>
      /// The sales charge for the purchase and redemption of mutual fund shares
      /// </summary>
      public string salesCharge { get; set; }

      /// <summary>
      /// The initial amount needed to purchase mutual fund shares in an IRA account
      /// </summary>
      public decimal initialIraInvestment { get; set; }

      /// <summary>
      /// The minimum amount needed to purchase subsequent mutual fund shares in an IRA account
      /// </summary>
      public decimal subsequentIraInvestment { get; set; }

      /// <summary>
      /// The Total Net Asset Value(NAV)
      /// </summary>
      public NetAsset netAssets { get; set; }

      /// <summary>
      /// The date when the fund started
      /// </summary>
      public long fundInceptionDate { get; set; }

      /// <summary>
      /// The average annual return at the end of the quarter; this is available if fund has been active for more than 10 years
      /// </summary>
      public decimal averageAnnualReturns { get; set; }

      /// <summary>
      /// The seven-day current yield
      /// </summary>
      public decimal sevenDayCurrentYield { get; set; }

      /// <summary>
      /// The annual total return
      /// </summary>
      public decimal annualTotalReturn { get; set; }

      /// <summary>
      /// The weighted average of maturity
      /// </summary>
      public decimal weightedAverageMaturity { get; set; }

      /// <summary>
      /// The average annual return for one year
      /// </summary>
      public decimal averageAnnualReturn1Yr { get; set; }

      /// <summary>
      /// The average annual return for three years
      /// </summary>
      public decimal averageAnnualReturn3Yr { get; set; }

      /// <summary>
      /// The average annual return for five years
      /// </summary>
      public decimal averageAnnualReturn5Yr { get; set; }

      /// <summary>
      /// The average annual return for ten years
      /// </summary>
      public decimal averageAnnualReturn10Yr { get; set; }

      /// <summary>
      /// The highest price at which a security has traded during the past year
      /// </summary>
      public decimal high52 { get; set; }

      /// <summary>
      /// The lowest price at which a security has traded during the past year
      /// </summary>
      public decimal low52 { get; set; }

      /// <summary>
      /// The date when the price was the lowest in the last 52 weeks
      /// </summary>
      public long week52LowDate { get; set; }

      /// <summary>
      /// The date when the price was the highest in the last 52 weeks
      /// </summary>
      public long week52HiDate { get; set; }

      /// <summary>
      /// The exchange name of the fund
      /// </summary>
      public string exchangeName { get; set; }

      /// <summary>
      /// The value of the fund since its beginning
      /// </summary>
      public decimal sinceInception { get; set; }

      /// <summary>
      /// The quarterly average value of the fund since the beginning of fund
      /// </summary>
      public decimal quarterlySinceInception { get; set; }

      /// <summary>
      /// The price of the most recent trade of the security
      /// </summary>
      public decimal lastTrade { get; set; }

      /// <summary>
      /// The annual marketing or distribution fee on the mutual fund
      /// </summary>
      public decimal actual12B1Fee { get; set; }

      /// <summary>
      /// The start date the performance is measured from
      /// </summary>
      public string performanceAsOfDate { get; set; }

      /// <summary>
      /// The start date of the quarter that the performance is measured from
      /// </summary>
      public string qtrlyPerformanceAsOfDate { get; set; }

      /// <summary>
      /// The mutual fund shares redemption properties
      /// </summary>
      public Redemption redemption { get; set; }

      /// <summary>
      /// The Morningstar category for the fund	
      /// </summary>
      public string morningStarCategory { get; set; } // The Morningstar category for the fund

      /// <summary>
      /// The one-year monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturn1Y { get; set; }

      /// <summary>
      /// The three-year monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturn3Y { get; set; }

      /// <summary>
      /// The five-year monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturn5Y { get; set; }

      /// <summary>
      /// The ten-year monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturn10Y { get; set; }

      /// <summary>
      /// The E* TRADE early redemption fee
      /// </summary>
      public string etradeEarlyRedemptionFee { get; set; }

      /// <summary>
      /// The maximum sales charge
      /// </summary>
      public decimal maxSalesLoad { get; set; }

      /// <summary>
      /// The year-to-date monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturnYTD { get; set; }

      /// <summary>
      /// The one-month monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturn1M { get; set; }

      /// <summary>
      /// The three-month monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturn3M { get; set; }

      /// <summary>
      /// The six-month monthly trailing return value
      /// </summary>
      public decimal monthlyTrailingReturn6M { get; set; }

      /// <summary>
      /// The year-to-date quarterly trailing return value
      /// </summary>
      public decimal qtrlyTrailingReturnYTD { get; set; }

      /// <summary>
      /// The one-month quarterly trailing return value
      /// </summary>
      public decimal qtrlyTrailingReturn1M { get; set; }

      /// <summary>
      /// The three-month quarterly trailing return value
      /// </summary>
      public decimal qtrlyTrailingReturn3M { get; set; }

      /// <summary>
      /// The six-month quarterly trailing return value
      /// </summary>
      public decimal qtrlyTrailingReturn6M { get; set; }

      /// <summary>
      /// The deferred sales charge
      /// </summary>
      public List<SaleChargeValues> deferredSalesCharges { get; set; }

      /// <summary>
      /// The front-end sales charge
      /// </summary>
      public List<SaleChargeValues> frontEndSalesCharges { get; set; }

      /// <summary>
      /// The code of the exchange
      /// </summary>
      public string exchangeCode { get; set; }

   }
}
