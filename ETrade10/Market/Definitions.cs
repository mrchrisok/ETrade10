/// <summary>
/// http://developer.oanda.com/rest-live-v20/account-df/
/// </summary>
namespace OkonkwoETrade10.Market
{
   public class MessageType
   {
      public const string Warning = "WARNING";
      public const string Information = "INFO";
      public const string InformationHold = "INFO_HOLD";
      public const string Error = "ERROR";
   }

   public class QuoteDetailFlag
   {
      public const string All = "ALL";
      public const string Fundamental = "FUNDAMENTAL";
      public const string Intraday = "INTRADAY";
      public const string Options = "OPTIONS";
      public const string Week52 = "WEEK_52";
      public const string MutualFund = "MF_DETAIL";
   }
}
