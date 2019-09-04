namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/CompleteView
   /// </summary>
   public class CompleteView : AccountView
   {
      public bool priceAdjustedFlag { get; set; } // The  price adjusted flag
      public decimal price { get; set; } // The  current market price
      public decimal adjPrice { get; set; } // The  adjusted price
      public decimal change { get; set; } // The change
      public decimal changePct { get; set; } // The  change percentage
      public decimal prevClose { get; set; } // The  previous close
      public decimal adjPrevClose { get; set; } // The  adjusted previous close
      public decimal volume { get; set; } // The volume
      public decimal adjLastTrade { get; set; } // The  adjusted last trade
      public string symbolDescription { get; set; } // The  symbol description
      public decimal perform1Month { get; set; } // The one- month performance
      public decimal perform3Month { get; set; } // The three- month performance
      public decimal perform6Month { get; set; } // The six- month performance
      public decimal perform12Month { get; set; } // The 12- month performance
      public long prevDayVolume { get; set; } // The previous day's volume	
      public long tenDayVolume { get; set; } //   The 10 day average volume
      public decimal beta { get; set; } // The beta
      public decimal sv10DaysAvg { get; set; } // The 10 day average  stochastic volatility
      public decimal sv20DaysAvg { get; set; } // The 20  day average  stochastic volatility
      public decimal sv1MonAvg { get; set; } //   The one month average stochastic volatility
      public decimal sv2MonAvg { get; set; } //   The two month average stochastic volatility
      public decimal sv3MonAvg { get; set; } //   The three month average stochastic volatility
      public decimal sv4MonAvg { get; set; } //   The four month average stochastic volatility
      public decimal sv6MonAvg { get; set; } //   The six month average stochastic volatility
      public decimal week52High { get; set; } // The 52  week high
      public decimal week52Low { get; set; } // The 52  week low
      public string week52Range { get; set; } // The 52 week range
      public decimal marketCap { get; set; } //   The market cap
      public string daysRange { get; set; } // The day's range	
      public decimal delta52WkHigh { get; set; } //   The high for the 52 week high/low delta calculation
      public decimal delta52WkLow { get; set; } // The low for the 52 week high/low delta calculation
      public string currency { get; set; } // The currency
      public string exchange { get; set; } // The exchange
      public bool marginable { get; set; } // The sum available for margin
      public decimal bid { get; set; } // The bid
      public decimal ask { get; set; } // The ask
      public decimal bidAskSpread { get; set; } // The  bid ask spread
      public long bidSize { get; set; } //   The size of the bid
      public long askSize { get; set; } //   The size of the ask
      public decimal open { get; set; } // The open
      public decimal delta { get; set; } // The delta
      public decimal gamma { get; set; } // The gamma
      public decimal ivPct { get; set; } // The Implied Volatility(IV) percentage
      public decimal rho { get; set; } // The rho
      public decimal theta { get; set; } // The theta
      public decimal vega { get; set; } // The vega
      public decimal premium { get; set; } // The premium
      public int daysToExpiration { get; set; } //  The days remaining until expiration
      public decimal intrinsicValue { get; set; } // The intrinsic value
      public decimal openInterest { get; set; } //   The open interest
      public bool optionsAdjustedFlag { get; set; } // The  options adjusted flag
      public string deliverablesStr { get; set; } // The deliverables
      public decimal optionMultiplier { get; set; } // The option multiplier
      public string baseSymbolAndPrice { get; set; } // The price of the underlying or base symbol
      public decimal estEarnings { get; set; } // The estimated earnings
      public decimal eps { get; set; } //   The earnings per share
      public decimal peRatio { get; set; } //   The Price to Earnings(P/E) ratio
      public decimal annualDividend { get; set; } // The annual dividend
      public decimal dividend { get; set; } //   The dividend
      public decimal divYield { get; set; } //   The dividend yield
      public long divPayDate { get; set; } //   The date of the dividend pay
      public long exDividendDate { get; set; } //   The extended dividend date
      public string cusip { get; set; } // The CUSIP number
   }
}
