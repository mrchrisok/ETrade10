/// <summary>
/// http://developer.oanda.com/rest-live-v20/order-df/
/// </summary>
namespace OkonkwoETrade10.Order
{
   public class CashMargin
   {
      public const string Cash = "CASH";
      public const string Margin = "MARGIN";
   }

   public class ConditionType
   {
      public const string ContingentGTE = "CONTINGENT_GTE";
      public const string ContingentLTE = "CONTINGENT_LTE";
   }

   public class Currency
   {
      public const string USD = "USD";
      public const string EUR = "EUR";
      public const string GBP = "GBP";
      public const string HKD = "HKD";
      public const string JPY = "JPY";
      public const string CAD = "CAD";
   }

   public class EventName
   {
      public const string Unspecified = "UNSPECIFIED";
      public const string OrderPlaced = "ORDER_PLACED";
      public const string SentToCms = "SENT_TO_CMS";
      public const string SentToMarket = "SENT_TO_MARKET";
      public const string MarketSentAcknowledged = "MARKET_SENT_ACKNOWLEDGED";
      public const string CancelRequested = "CANCEL_REQUESTED";
      public const string OrderModified = "ORDER_MODIFIED";
      public const string OrderSentToBrokerReview = "ORDER_SENT_TO_BROKER_REVIEW";
      public const string SystemRejected = "SYSTEM_REJECTED";
      public const string OrderRejected = "ORDER_REJECTED";
      public const string OrderCancelled = "ORDER_CANCELLED";
      public const string CancelRejected = "CANCEL_REJECTED";
      public const string OrderExpired = "ORDER_EXPIRED";
      public const string OrderExecuted = "ORDER_EXECUTED";
      public const string OrderAdjusted = "ORDER_ADJUSTED";
      public const string OrderReversed = "ORDER_REVERSED";
      public const string ReverseCancellation = "REVERSE_CANCELLATION";
      public const string ReverseExpiration = "REVERSE_EXPIRATION";
      public const string OptionPositionAssigned = "OPTION_POSITION_ASSIGNED";
      public const string OpenOrderAdjusted = "OPEN_ORDER_ADJUSTED";
      public const string CaCancelled = "CA_CANCELLED";
      public const string CaBooked = "CA_BOOKED";
      public const string IpoAllocated = "IPO_ALLOCATED";
      public const string DoneTradeExecuted = "DONE_TRADE_EXECUTED";
      public const string RejectionReversal = "REJECTION_REVERSAL";
   }

   public class ExecutionGuarantee
   {
      public const string ExecutionGuaranteeUnspecified = "EG_QUAL_UNSPECIFIED";
      public const string ExecutionGuaranteeQualified = "EG_QUAL_QUALIFIED";
      public const string ExecutionGuaranteeNotInForce = "EG_QUAL_NOT_IN_FORCE";
      public const string ExecutionGuaranteeNotAMarketOrder = "EG_QUAL_NOT_A_MARKET_ORDER";
      public const string ExecutionGuaranteeNotAnEligibleSecurity = "EG_QUAL_NOT_AN_ELIGIBLE_SECURITY";
      public const string ExecutionGuaranteeInvalidOrderType = "EG_QUAL_INVALID_ORDER_TYPE";
      public const string ExecutionGuaranteeSizeNotQualified = "EG_QUAL_SIZE_NOT_QUALIFIED";
      public const string ExecutionGuaranteeOutsideGuaranteedPeriod = "EG_QUAL_OUTSIDE_GUARANTEED_PERIOD";
      public const string ExecutionGuaranteeIneligibleGateway = "EG_QUAL_INELIGIBLE_GATEWAY";
      public const string ExecutionGuaranteeIneligibleDueToIpo = "EG_QUAL_INELIGIBLE_DUE_TO_IPO";
      public const string ExecutionGuaranteeIneligibleDueToSelfDirected = "EG_QUAL_INELIGIBLE_DUE_TO_SELF_DIRECTED";
      public const string ExecutionGuaranteeIneligibleDueToChangeOrder = "EG_QUAL_INELIGIBLE_DUE_TO_CHANGEORDER";
   }

   public class OrderAction
   {
      public const string Buy = "BUY";
      public const string Sell = "SELL";
      public const string BuyToCover = "BUY_TO_COVER";
      public const string SellShort = "SELL_SHORT";
      public const string BuyOpen = "BUY_OPEN";
      public const string BuyClose = "BUY_CLOSE";
      public const string SellOpen = "SELL_OPEN";
      public const string SellClose = "SELL_CLOSE";
      public const string Exchange = "EXCHANGE";
   }

   public class OrderExchange
   {
      public const string Auto = "AUTO";
      public const string Amex = "AMEX";
      public const string Box = "BOX";
      public const string Cboe = "CBOE";
      public const string Ise = "ISE";
      public const string Nomura = "NOM";
      public const string Nyse = "NYSE";
      public const string Phoenix = "PHX";
   }

   public class OrderStatus
   {
      public const string Open = "OPEN";
      public const string Executed = "EXECUTED";
      public const string Cancelled = "CANCELLED";
      public const string IndividualFills = "INDIVIDUAL_FILLS";
      public const string CancelRequested = "CANCEL_REQUESTED";
      public const string Expired = "EXPIRED";
      public const string Rejected = "REJECTED";
      public const string Partial = "PARTIAL";
      public const string OptionExercise = "OPTION_EXERCISE";
      public const string OptionAssignment = "OPTION_ASSIGNMENT";
      public const string DoNotExercise = "DO_NOT_EXERCISE";
      public const string DoneTradeExecuted = "DONE_TRADE_EXECUTED";
   }

   public class OrderTerm
   {
      public const string GoodUntilCancel = "GOOD_UNTIL_CANCEL";
      public const string GoodForDay = "GOOD_FOR_DAY";
      public const string GoodTillDate = "GOOD_TILL_DATE";
      public const string ImmediateOrCancel = "IMMEDIATE_OR_CANCEL";
      public const string FillOrKill = "FILL_OR_KILL";
   }

   public class OrderType
   {
      public const string Equity = "EQ";
      public const string Option = "OPTN";
      public const string Spreads = "SPREADS";
      public const string BuyWrites = "BUY_WRITES";
      public const string Butterfly = "BUTTERFLY";
      public const string IronButterfly = "IRON_BUTTERFLY";
      public const string Condor = "CONDOR";
      public const string IronCondor = "IRON_CONDOR";
      public const string MutualFund = "MF";
      public const string MoneyMarketFund = "MMF";
      public const string Bond = "BOND";
      public const string Contingent = "CONTINGENT";
      public const string OneCancelsAll = "ONE_CANCELS_ALL";
      public const string OneTriggersAll = "ONE_TRIGGERS_ALL";
      public const string OneTriggesOneCancelsOther = "ONE_TRIGGERS_OCO";
      public const string OptionExercise = "OPTION_EXERCISE";
      public const string OptionAssignment = "OPTION_ASSIGNMENT";
      public const string OptionExpired = "OPTION_EXPIRED";
      public const string DoNotExercise = "DO_NOT_EXERCISE";
      public const string Bracketed = "BRACKETED";
   }

   public class PositionQuantity
   {
      public const string EntirePosition = "ENTIRE_POSITION";
      public const string Cash = "CASH";
      public const string Margin = "MARGIN";
   }

   public class QuotePrice
   {
      public const string Ask = "ASK";
      public const string Bid = "BID";
      public const string Last = "LAST";
   }

   public class PriceType
   {
      public const string Market = "MARKET";
      public const string Limit = "LIMIT";
      public const string Stop = "STOP";
      public const string StopLimit = "STOP_LIMIT";
      public const string TrailingStopConstantByLowerTrigger = "TRAILING_STOP_CNST_BY_LOWER_TRIGGER";
      public const string UpperTriggerByTrailingStopConstant = "UPPER_TRIGGER_BY_TRAILING_STOP_CNST";
      public const string TrailingStopPercentByLowerTrigger = "TRAILING_STOP_PRCT_BY_LOWER_TRIGGER";
      public const string UpperTriggerByTrailingStopPercent = "UPPER_TRIGGER_BY_TRAILING_STOP_PRCT";
      public const string TrailingStopConstant = "TRAILING_STOP_CNST";
      public const string TrailingStopPercent = "TRAILING_STOP_PRCT";
      public const string HiddenStop = "HIDDEN_STOP";
      public const string HiddenStopByLowerTrigger = "HIDDEN_STOP_BY_LOWER_TRIGGER";
      public const string UpperTriggerByHiddenStop = "UPPER_TRIGGER_BY_HIDDEN_STOP";
      public const string NetDebit = "NET_DEBIT";
      public const string NetCredit = "NET_CREDIT";
      public const string NetEven = "NET_EVEN";
      public const string MarketOnOpen = "MARKET_ON_OPEN";
      public const string MarketOnClose = "MARKET_ON_CLOSE";
      public const string LimitOnOpen = "LIMIT_ON_OPEN";
      public const string LimitOnClose = "LIMIT_ON_CLOSE";
   }

   public class ProfitInvestOption
   {
      public const string Reinvest = "REINVEST";
      public const string Deposit = "DEPOSIT";
      public const string CurrentHolding = "CURRENT_HOLDING";
   }

   public class QuantityType
   {
      public const string Quantity = "QUANTITY";
      public const string Dollary = "DOLLAR";
      public const string AllIOwn = "ALL_I_OWN";
   }

   public class SecurityType
   {
      public const string Equity = "EQ";
      public const string Option = "OPTN";
      public const string Bond = "BOND";
      public const string MutualFund = "MF";
      public const string MoneyMarketFund = "MMF";
   }

   public class TransactionType
   {
      public const string Atnm = "ATNM";
      public const string Buy = "BUY";
      public const string Sell = "SELL";
      public const string SellShort = "SELL_SHORT";
      public const string BuyToCover = "BUY_TO_COVER";
      public const string MutualFundExchange = "MF_EXCHANGE";
   }
}
