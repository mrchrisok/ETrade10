namespace OkonkwoETrade10.REST
{
   /// <summary>
   /// In the context of an Order or a Trade, defines whether the units are positive or negative.
   /// </summary>
   public class Direction
   {
      /// <summary>
      /// A long Order is used to to buy units of an Instrument. A Trade is long when it has bought units of an 
      /// Instrument.
      /// </summary>
      public const string Long = "LONG";

      /// <summary>
      /// A short Order is used to to sell units of an Instrument. A Trade is short when it has sold units of an Instrument.
      /// </summary>
      public const string Short = "SHORT";
   }

   public class InstitutionType
   {
      public const string Brokerage = "BROKERAGE";
      public const string GlobalTrading = "GLOBALTRADING";
      public const string NonUS = "NONUS";
      public const string StockPlan = "STOCKPLAN";
      public const string Lending = "LENDING";
      public const string Heloc = "HELOC";
      public const string Heil = "HEIL";
      public const string OnTrack = "ONTRACK";
      public const string Genpact = "GENPACT";
      public const string Auto = "AUTO";
      public const string AutoLoan = "AUTOLOAN";
      public const string Beta = "BETA";
      public const string Loyalty = "LOYALTY";
      public const string SbaSket = "SBASKET";
      public const string CreditCardBalanceTransfer = "CC_BALANCETRANSFER";
      public const string GenpactLead = "GENPACT_LEAD";
      public const string Ganis = "GANIS";
      public const string Mortgage = "MORTGAGE";
      public const string External = "EXTERNAL";
      public const string Futures = "FUTURES";
      public const string Visa = "VISA";
      public const string RJO = "RJO";
      public const string Wdbh = "WDBH";
   }

   public class SortOrder
   {
      public const string Ascending = "ASC";
      public const string Descending = "DESC";
   }
}
