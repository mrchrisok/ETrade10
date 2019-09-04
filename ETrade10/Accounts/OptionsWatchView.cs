namespace OkonkwoETrade10.Accounts
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/account/api-portfolio-v1.html#/definitions/OptionsWatchView
   /// </summary>
   public class OptionsWatchView : AccountView
   {
      /// <summary>
      /// The price of the underlying or base symbol of the option
      /// </summary>
      public string baseSymbolAndPrice { get; set; }

      /// <summary>
      /// The option premium
      /// </summary>
      public decimal premium { get; set; }

      /// <summary>
      /// The bid
      /// </summary>
      public decimal bid { get; set; }

      /// <summary>
      /// The ask
      /// </summary>
      public decimal ask { get; set; }
   }
}
