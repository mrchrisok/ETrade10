namespace OkonkwoETrade10.Framework
{
   public class Utilities
   {
      /// <summary>
      /// Determines if trading is halted for the provided instrument.
      /// </summary>
      /// <param name="symbol">Instrument to check if halted. Default is SPX.</param>
      /// <returns>True if trading is halted, false if trading is not halted.</returns>
      //   public static async Task<bool> IsMarketHalted(string symbol = "SPX")
      //   {
      //      //var accountID = Authorization.GetCredentials().AccountId;
      //      var symbols = new List<string>() { symbol };

      //      var quotes = await ETrade10.GetQuotesAsync(symbols);

      //      bool isTradeable = false;
      //      //bool hasBids = false, hasAsks = false;

      //      if (quotes?.messages != null)
      //      {
      //         isTradeable = quotes.quoteData[0].quoteStatus == QuoteStatus.RealTime;
      //         //hasBids = quotes.quoteData[0]..Count > 0;
      //         //hasAsks = quotes[0].asks.Count > 0;
      //      }

      //      //return !(isTradeable && hasBids && hasAsks);
      //      return !(isTradeable);
      //   }
   }
}
