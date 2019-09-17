namespace OkonkwoETrade10.Common
{
   public class InstrumentNames
   {
      public class Equities
      {

      }
   }

   public class SecurityNames
   {
      public class Equities
      {
         public const string Google = "GOOG";
      }
      public class ExchangeTradedFunds
      {
         public const string SPDRSP500 = "SPY";
      }
      public class Options
      {

      }
      public class Bonds
      {

      }
      public class MutualFunds
      {

      }
      public class MoneyMarketFunds
      {

      }
   }

   public class MarketSession
   {
      public const string Regular = "REGULAR";
      public const string Extended = "EXTENDED";
   }

   public class QuoteStatus
   {
      public const string RealTime = "REALTIME";
      public const string Delayed = "DELAYED";
      public const string Closing = "CLOSING";
      public const string ExtendedHoursRealtime = "EH_REALTIME";
      public const string ExtendedHoursBeforeOpen = "EH_BEFORE_OPEN";
      public const string ExtendedHoursClosed = "EH_CLOSED";
   }
}
