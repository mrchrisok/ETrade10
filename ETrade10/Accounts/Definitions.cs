/// <summary>
/// http://developer.oanda.com/rest-live-v20/account-df/
/// </summary>
namespace OkonkwoETrade10.Accounts
{
   public class AccountFinancingMode
   {
      public const string Daily = "DAILY";
      public const string NoFinancing = "NO_FINANCING";
      public const string SecondBySecond = "SECOND_BY_SECOND";
   }
   public class AccountMode
   {
      public const string Cash = "CASH";
      public const string Margin = "MARGIN";
      public const string PatterDayTrader = "PDT_ACCOUNT";
   }
   public class AccountStatus
   {
      public const string Active = "ACTIVE";
      public const string Closed = "CLOSED";
   }
   public class AccountType
   {
      public const string AMMCHK = "AMMCHK";
      public const string ARO = "ARO";
      public const string BCHK = "BCHK";
      public const string BeneficiaryIRA = "BENFIRA";
      public const string BeneficiaryRothIRA = "BENFROTHIRA";
      public const string BeneficiaryEstateIRA = "BENF_ESTATE_IRA";
      public const string BeneficiaryMinorIRA = "BENF_MINOR_IRA";
      public const string BeneficiaryRothEstateIRA = "BENF_ROTH_ESTATE_IRA";
      public const string BeneficiaryRothMinorIRA = "BENF_ROTH_MINOR_IRA";
      public const string BeneficiaryRothTrustIRA = "BENF_ROTH_TRUST_IRA";
      public const string BeneficiaryTrustIRA = "BENF_TRUST_IRA";
      public const string BrokeredCD = "BRKCD";
      public const string Broker = "BROKER";
      public const string Cash = "CASH";
      public const string CCorp = "C_CORP";
      public const string Contributory = "CONTRIBUTORY";
      public const string CoverdellESA = "COVERDELL_ESA";
      public const string ConversionRothIRA = "CONVERSION_ROTH_IRA";
      public const string CreditCard = "CREDITCARD";
      public const string acct = "COMM_PROP";
      public const string Conservator = "CONSERVATOR";
      public const string Corporation = "CORPORATION";
      public const string CSA = "CSA";
      public const string Custodial = "CUSTODIAL";
      public const string DVP = "DVP";
      public const string Estate = "ESTATE";
      public const string EMPCHK = "EMPCHK";
      public const string EMPMMCA = "EMPMMCA";
      public const string ETCHK = "ETCHK";
      public const string ETMMCHK = "ETMMCHK";
      public const string HEIL = "HEIL";
      public const string Heloc = "HELOC";
      public const string IndividualChecking = "INDCHK";
      public const string Individual = "INDIVIDUAL";
      public const string IndividualK = "INDIVIDUAL_K";
      public const string InvestmentClub = "INVCLUB";
      public const string InvestmentClubCCorp = "INVCLUB_C_CORP";
      public const string InvestmentClubLlcCCorp = "INVCLUB_LLC_C_CORP";
      public const string InvestmentClubLlcPartnership = "INVCLUB_LLC_PARTNERSHIP";
      public const string InvestmentClubLlcSCorp = "INVCLUB_LLC_S_CORP";
      public const string InvestmentClubPartnership = "INVCLUB_PARTNERSHIP";
      public const string InvestmentClubSCorp = "INVCLUB_S_CORP";
      public const string InvestmentClubTrust = "INVCLUB_TRUST";
      public const string IRARollover = "IRA_ROLLOVER";
      public const string Joint = "JOINT";
      public const string JointTenants = "JTTEN";
      public const string JointTenantsWithRightOfSurvivorship = "JTWROS";
      public const string LlcCCorp = "LLC_C_CORP";
      public const string LLcPartnership = "LLC_PARTNERSHIP";
      public const string LLcSCorp = "LLC_S_CORP";
      public const string Llp = "LLP";
      public const string LlpCCorp = "LLP_C_CORP";
      public const string LlpSCorp = "LLP_S_CORP";
      public const string IRA = "IRA";
      public const string IRACertificateOfDeposit = "IRACD";
      public const string MoneyPurchase = "MONEY_PURCHASE";
      public const string Margin = "MARGIN";
      public const string MRCHK = "MRCHK";
      public const string MutualFund = "MUTUAL_FUND";
      public const string NonCustodial = "NONCUSTODIAL";
      public const string NonProfit = "NON_PROFIT";
      public const string Other = "OTHER";
      public const string Partner = "PARTNER";
      public const string Partnership = "PARTNERSHIP";
      public const string PartnershipCCorp = "PARTNERSHIP_C_CORP";
      public const string PartnershipSCorp = "PARTNERSHIP_S_CORP";
      public const string PatternDayTrader = "PDT_ACCOUNT";
      public const string PM_ACCOUNT = "PM_ACCOUNT";
      public const string PREFCD = "PREFCD";
      public const string PREFIRACD = "PREFIRACD";
      public const string ProfitSharing = "PROFIT_SHARING";
      public const string Proprietary = "PROPRIETARY";
      public const string REGCD = "REGCD";
      public const string RothIRA = "ROTHIRA";
      public const string RothIndividualK = "ROTH_INDIVIDUAL_K";
      public const string RothIRAMinors = "ROTH_IRA_MINORS";
      public const string SalaryReductionSimplifiedEmployeePensionIRA = "SARSEPIRA";
      public const string SCorp = "S_CORP";
      public const string SimplifiedEmployeePensionIRA = "SEPIRA";
      public const string SimpleIRA = "SIMPLE_IRA";
      public const string TenantsInCommon = "TIC";
      public const string TRD_IRA_MINORS = "TRD_IRA_MINORS";
      public const string Trust = "TRUST";
      public const string VARCD = "VARCD";
      public const string VARIRACD = "VARIRACD";
   }

   public class DayTraderStatus
   {
      public const string PDTMinEquityRes1XK = "PDT_MIN_EQUITY_RES_1XK";
      public const string NoPDT = "NO_PDT";
   }

   public enum OptionLevel
   {
      NO_OPTIONS,
      LEVEL_1,
      LEVEL_2,
      LEVEL_3,
      LEVEL_4
   }
   public class OptionType
   {
      public const string Call = "CALL";
      public const string Put = "OPTION";
   }
   public class PositionAggregationMode
   {
      public const string AbsoluteSum = "ABSOLUTE_SUM";
      public const string MaximalSide = "MAXIMAL_SIDE";
      public const string NetSum = "NET_SUM";
   }
   public class PositionIndicator
   {
      public const string Type1 = "TYPE1";
      public const string Type2 = "TYPE2";
      public const string Type5 = "TYPE5";
      public const string Undefined = "UNDEFINED";
   }
   public enum QuoteMode
   {
      QuoteRealTime,
      QuoteDelayed,
      QuoteClosing,
      QuoteAfterHoursRealTime,
      QuoteAfterHoursBeforeOpen,
      QuoteAfterHoursClosing,
      None
   }
   public class SecurityType
   {
      public const string Bond = "BOND";
      public const string Equity = "EQ";
      public const string Index = "INDX";
      public const string MutualFund = "MF";
      public const string MoneyMarketFund = "MMF";
      public const string Option = "OPTN";
   }
   public class SortBy
   {
      public const string Symbol = "SYMBOL";
      public const string TypeName = "TYPE_NAME";
      public const string ExchangeName = "EXCHANGE_NAME";
      public const string Currency = "CURRENCY";
      public const string Quantity = "QUANTITY";
      public const string LongOrShort = "LONG_OR_SHORT";
      public const string DateAcquired = "DATE_ACQUIRED";
      public const string PricePaid = "PRICEPAID";
      public const string TotalGain = "TOTAL_GAIN";
      public const string TotalGainPercent = "TOTAL_GAIN_PCT";
      public const string MarketValue = "MARKET_VALUE";
      public const string Bi = "BI";
      public const string Ask = "ASK";
      public const string PriceChange = "PRICE_CHANGE";
      public const string PriceChangePercent = "PRICE_CHANGE_PCT";
      public const string Volume = "VOLUME";
      public const string Week52High = "WEEK_52_HIGH";
      public const string Week52Low = "WEEK_52_LOW";
      public const string EarningsPerShare = "EPS";
      public const string PriceEarningsRatio = "PE_RATIO";
      public const string OPtionType = "OPTION_TYPE";
      public const string StrikePrice = "STRIKE_PRICE";
      public const string Premium = "PREMIUM";
      public const string Expiration = "EXPIRATION";
      public const string DaysGain = "DAYS_GAIN";
      public const string Commission = "COMMISSION";
      public const string MarketCapitalization = "MARKETCAP";
      public const string PreviousClose = "PREV_CLOSE";
      public const string Open = "OPEN";
      public const string DaysRange = "DAYS_RANGE";
      public const string TotalCost = "TOTAL_COST";
      public const string DaysGainPercent = "DAYS_GAIN_PCT";
      public const string PercentOfPortfolio = "PCT_OF_PORTFOLIO";
      public const string LastTradeTime = "LAST_TRADE_TIME";
      public const string BaseSymbolPrice = "BASE_SYMBOL_PRICE";
      public const string Week52Range = "WEEK_52_RANGE";
      public const string LastTrade = "LAST_TRADE";
      public const string SymbolDesc = "SYMBOL_DESC";
      public const string BidSize = "BID_SIZE";
      public const string AskSize = "ASK_SIZE";
      public const string OtherFees = "OTHER_FEES";
      public const string HeldAs = "HELD_AS";
      public const string OptionMultiplier = "OPTION_MULTIPLIER";
      public const string Deliverables = "DELIVERABLES";
      public const string CostPerShare = "COST_PERSHARE";
      public const string Dividend = "DIVIDEND";
      public const string DividendYield = "DIV_YIELD";
      public const string DividendPayDate = "DIV_PAY_DATE";
      public const string EstimatedEarnings = "EST_EARN";
      public const string ExDividendDate = "EX_DIV_DATE";
      public const string TenDayAverageVolume = "TEN_DAY_AVG_VOL";
      public const string Beta = "BETA";
      public const string BidAskSpread = "BID_ASK_SPREAD";
      public const string Marginable = "MARGINABLE";
      public const string Delta52WeekHigh = "DELTA_52WK_HI";
      public const string Delta52WeekLow = "DELTA_52WK_LOW";
      public const string Performance1Month = "PERF_1MON";
      public const string AnnualDividend = "ANNUAL_DIV";
      public const string Performance12Month = "PERF_12MON";
      public const string Performance3Month = "PERF_3MON";
      public const string Performance6Month = "PERF_6MON";
      public const string PreDayVolume = "PRE_DAY_VOL";
      public const string Sv1MonthAverage = "SV_1MON_AVG";
      public const string Sv10DayAverage = "SV_10DAY_AVG";
      public const string Sv20DayAverage = "SV_20DAY_AVG";
      public const string Sv2MonthAverage = "SV_2MON_AVG";
      public const string Sv3MonthAverage = "SV_3MON_AVG";
      public const string Sv4MonthAverage = "SV_4MON_AVG";
      public const string Sv6MonthAverage = "SV_6MON_AVG";
      public const string Delta = "DELTA";
      public const string Gamma = "GAMMA";
      public const string IvPercent = "IV_PCT";
      public const string Theta = "THETA";
      public const string Vega = "VEGA";
      public const string AdjustedNonAdjustedFlag = "ADJ_NONADJ_FLAG";
      public const string DaysExpiration = "DAYS_EXPIRATION";
      public const string OpenInterest = "OPEN_INTEREST";
      public const string IntrinsicValue = "INSTRINIC_VALUE";
      public const string Rho = "RHO";
      public const string TypeCode = "TYPE_CODE";
      public const string DisplaySymbol = "DISPLAY_SYMBOL";
      public const string AfterHoursPercentChange = "AFTER_HOURS_PCTCHANGE";
      public const string PreMarketPercentChange = "PRE_MARKET_PCTCHANGE";
      public const string ExpandCollapseFlag = "EXPAND_COLLAPSE_FLAG";
   }

   //public class AccountView
   //{
   //   public const string Performance = "PERFORMANCE";
   //   public const string Fundamental = "FUNDAMENTAL";
   //   public const string OptionsWatch = "OPTIONSWATCH";
   //   public const string Quick = "QUICK";
   //   public const string Complete = "COMPLETE";
   //}
}
