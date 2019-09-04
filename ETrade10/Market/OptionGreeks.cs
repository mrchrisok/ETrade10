namespace OkonkwoETrade10.Market
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/market/api-quote-v1.html#/definitions/OptionGreeks
   /// </summary>
   public class OptionGreeks
   {
      /// <summary>
      /// The rho value of the symbol
      /// </summary>
      public decimal rho { get; set; }

      /// <summary>
      /// The vega value of the symbol
      /// </summary>
      public decimal vega { get; set; }

      /// <summary>
      /// The theta value of the symbol
      /// </summary>
      public decimal theta { get; set; }

      /// <summary>
      /// The delta value of the symbol
      /// </summary>
      public decimal delta { get; set; }

      /// <summary>
      /// The gamma value of the symbol
      /// </summary>
      public decimal gamma { get; set; }

      /// <summary>
      /// The Implied Volatility(IV) value of the symbol
      /// </summary>
      public decimal iv { get; set; }

      /// <summary>
      /// The current value of the symbol
      /// </summary>
      public bool currentValue { get; set; }
   }
}
