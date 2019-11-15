using System.Collections.Generic;
using Newtonsoft.Json;

namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/AllQuoteDetails
   /// </summary>
   public class AllQuoteDetails
   {
      /// <summary>
      /// Indicates whether an option has been adjusted due to a corporate action (for example, a dividend or stock split)
      /// </summary>
      public bool adjustedFlag { get; set; }

      /// <summary>
      /// Cash amount paid per share over the past year
      /// </summary>
      public decimal annualDividend { get; set; }

      /// <summary>
      /// The current ask price for a security
      /// </summary>
      public decimal ask { get; set; }

      /// <summary>
      /// Code for the exchange reporting the ask price
      /// </summary>
      public string askExchange { get; set; }

      /// <summary>
      /// Number shares or contracts offered by broker or dealer at the ask price
      /// </summary>
      public long askSize { get; set; }

      /// <summary>
      /// The time of the ask; for example, '15:15:43 PDT 03-21-2018'
      /// </summary>
      public string askTime { get; set; }

      /// <summary>
      /// Current bid price for a security
      /// </summary>
      public decimal bid { get; set; }

      /// <summary>
      /// Code for the exchange reporting the bid price
      /// </summary>
      public string bidExchange { get; set; }

      /// <summary>
      /// Number of shares or contracts offered at the bid price
      /// </summary>
      public long bidSize { get; set; }

      /// <summary>
      /// Time of the bid; for example '15:15:43 PDT 03-21-2018'
      /// </summary>
      public string bidTime { get; set; }

      /// <summary>
      /// Dollar change of the last price from the previous close
      /// </summary>
      public decimal changeClose { get; set; }

      /// <summary>
      /// Percentage change of the last price from the previous close
      /// </summary>
      public decimal changeClosePercentage { get; set; }

      /// <summary>
      /// Name of the company or mutual fund(shows up to 40 characters)
      /// </summary>
      public string companyName { get; set; }

      /// <summary>
      /// Number of days before the option expires
      /// </summary>
      public long daysToExpiration { get; set; }

      /// <summary>
      /// Direction of movement; that is, whether the current price is higher or lower than the price of the most recent trade
      /// </summary>
      public string dirLast { get; set; }

      /// <summary>
      /// Cash amount per share of the latest dividend
      /// </summary>
      public decimal dividend { get; set; }

      /// <summary>
      /// Earnings per share on rolling basis(stocks only)
      /// </summary>
      public decimal eps { get; set; }

      /// <summary>
      /// Projected Earnings per share for the next fiscal year(stocks only)
      /// </summary>
      public decimal estEarnings { get; set; }

      /// <summary>
      /// Date(in Epoch time) on which shareholders were entitled to receive the latest dividend
      /// </summary>
      public long exDividendDate { get; set; }

      /// <summary>
      /// Code for the exchange of the last trade
      /// </summary>
      public string exchgLastTrade { get; set; }

      /// <summary>
      /// Financial Status Indicator indicates whether a Nasdaq-listed issuer has failed to submit its regulatory filings on timely basis, failed to meet continuing listing standards, and/or filed for bankruptcy. Codes are: D - Deficient, E - Delinquent, Q - Bankrupt, N - Normal, G - Deficient and Bankrupt, H - Deficient and Delinquent, J - Delinquent and Bankrupt, and K - Deficient, Delinquent, and Bankrupt.
      /// </summary>
      public string fsi { get; set; }
      public decimal high { get; set; } // Highest price at which a security has traded during the current day

      /// <summary>
      /// Highest price at which a security has traded during the past year (52 weeks). For options, this value is the lifetime high.
      /// </summary>
      public decimal high52 { get; set; }

      /// <summary>
      /// Highest ask price for the current trading day
      /// </summary>
      public decimal highAsk { get; set; }

      /// <summary>
      /// Highest bid price for the current trading day
      /// </summary>
      public decimal highBid { get; set; }

      /// <summary>
      /// Price of the most recent trade of a security
      /// </summary>
      public decimal lastTrade { get; set; }

      /// <summary>
      /// Lowest price at which a security has traded during the current day
      /// </summary>
      public decimal low { get; set; }

      /// <summary>
      /// Lowest price at which security has traded during the past year (52 weeks). For options, this value is the lifetime low.	
      /// </summary>
      public decimal low52 { get; set; }

      /// <summary>
      /// Lowest ask price for the current trading day
      /// </summary>
      public decimal lowAsk { get; set; }

      /// <summary>
      /// Lowest bid price for the current trading day
      /// </summary>
      public decimal lowBid { get; set; }

      /// <summary>
      /// Number of transactions involving buying a security from another entity
      /// </summary>
      public long numberOfTrades { get; set; }

      /// <summary>
      /// Price of a security at the current day's market open
      /// </summary>
      public decimal open { get; set; }

      /// <summary>
      /// Total number of options or futures contracts that are not closed or delivered on a particular day
      /// </summary>
      public long openInterest { get; set; }

      /// <summary>
      /// Specifies how the contract treats the expiration date. Possible values are "European" (options can be exercised only on the expiration date) or "American" (options can be exercised any time before they expire).
      /// </summary>
      public string optionStyle { get; set; }

      /// <summary>
      /// Symbol for the underlier(options only)
      /// </summary>
      public string optionUnderlier { get; set; }

      /// <summary>
      /// Exchange code for option underlier symbol; applicable only for options
      /// </summary>
      public string optionUnderlierExchange { get; set; }

      /// <summary>
      /// Official price at the close of the previous trading day
      /// </summary>
      public decimal previousClose { get; set; }

      /// <summary>
      /// Final volume from the previous market session
      /// </summary>
      public long previousDayVolume { get; set; }

      /// <summary>
      /// Exchange code of the primary listing exchange for this instrument
      /// </summary>
      public string primaryExchange { get; set; }

      /// <summary>
      /// Description of the security; for example, the company name or the option description
      /// </summary>
      public string symbolDescription { get; set; }

      /// <summary>
      /// Price at the close of the regular trading session for the current day
      /// </summary>
      public decimal todayClose { get; set; }

      /// <summary>
      /// Total number of shares or contracts exchanging hands
      /// </summary>
      public long totalVolume { get; set; }

      /// <summary>
      /// Uniform Practice Code identifies specific FINRA advisories detailing unusual circumstances; for example, extremely large dividends, when-issued settlement dates, and worthless securities
      /// </summary>
      public long upc { get; set; }

      /// <summary>
      /// Ten-day average trading volume for the security
      /// </summary>
      public long volume10Day { get; set; }

      /// <summary>
      /// List of mulitple deliverables
      /// </summary>
      public List<OptionDeliverable> optionDeliverableList { get; set; }

      /// <summary>
      /// The cash deliverables in case of multiple deliverables
      /// </summary>
      public decimal cashDeliverable { get; set; }

      /// <summary>
      /// The value market capitalization
      /// </summary>
      public decimal marketCap { get; set; }

      /// <summary>
      /// The number of outstanding shares
      /// </summary>
      public decimal sharesOutstanding { get; set; }

      /// <summary>
      /// If requireEarningsDate is true, the next earning date value in mm/dd/yyyy format
      /// </summary>
      public string nextEarningDate { get; set; }

      /// <summary>
      /// A measure of a stock's volatility relative to the primary market index
      /// </summary>
      public decimal beta { get; set; }

      /// <summary>
      /// The dividend yield
      /// </summary>
      public decimal yield { get; set; }

      /// <summary>
      /// The declared dividend
      /// </summary>
      public decimal declaredDividend { get; set; }

      /// <summary>
      /// The dividend payable date
      /// </summary>
      public long dividendPayableDate { get; set; }

      /// <summary>
      /// The option multiplier
      /// </summary>
      public decimal pe { get; set; }

      /// <summary>
      /// The market close bid size
      /// </summary>
      public long marketCloseBidSize { get; set; }

      /// <summary>
      /// The market close ask size
      /// </summary>
      public long marketCloseAskSize { get; set; }

      /// <summary>
      ///  The market close volume
      /// </summary>
      public long marketCloseVolume { get; set; }

      /// <summary>
      /// The date at which the price was the lowest in the last 52 weeks; applicable for stocks and mutual funds
      /// </summary>
      public long week52LowDate { get; set; }

      /// <summary>
      /// The date at which the price was highest in the last 52 weeks; applicable for stocks and mutual funds
      /// </summary>
      public long week52HiDate { get; set; }

      /// <summary>
      /// The intrinsic value of the share
      /// </summary>
      public decimal intrinsicValue { get; set; }

      /// <summary>
      ///  The value of the time premium
      /// </summary>
      public decimal timePremium { get; set; }

      /// <summary>
      /// The option multiplier value
      /// </summary>
      public decimal optionMultiplier { get; set; }

      /// <summary>
      /// The contract size of the option
      /// </summary>
      public decimal contractSize { get; set; }

      /// <summary>
      /// The expiration date of the option
      /// </summary>
      public long expirationDate { get; set; }

      /// <summary>
      /// QuoteDetails when market is in extended hours; appears only for after-hours market and when detailFlag is ALL or all
      /// </summary>
      [JsonProperty("ExtendedHourQuoteDetail")]
      public ExtendedHourQuoteDetail ehQuote { get; set; }

      /// <summary>
      /// The option previous bid price
      /// </summary>
      public decimal optionPreviousBidPrice { get; set; }

      /// <summary>
      /// The option previous ask price
      /// </summary>
      public decimal optionPreviousAskPrice { get; set; }

      /// <summary>
      /// The Options Symbology Initiative(OSI) representation of the option symbol
      /// </summary>
      public string osiKey { get; set; }

      /// <summary>
      /// The time when the last trade was placed
      /// </summary>
      public long timeOfLastTrade { get; set; }

      /// <summary>
      /// Average volume value corresponding to the symbol
      /// </summary>
      public long averageVolume { get; set; }
   }
}
