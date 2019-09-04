namespace OkonkwoETrade10.Accounts
{
   public class Lending
   {
      public decimal currentBalance { get; set; }   //The current balance on lent funds
      public decimal creditLine { get; set; }   //The lent funds current credit line
      public decimal outstandingBalance { get; set; }   //The outstanding balance on the lent funds
      public decimal minPaymentDue { get; set; } //The minimum balance due on the payback of the lent funds
      public decimal amountPastDue { get; set; }   //The amount past due on the payback of the lent funds
      public decimal availableCredit { get; set; } //The available credit on the lent funds
      public decimal ytdInterestPaid { get; set; }   //The year-to-date interest paid on the lent funds
      public decimal lastYtdInterestPaid { get; set; } //The last year-to-date interest paid on the lent funds
      public long paymentDueDate { get; set; }   //The payment due date on the lent funds
      public long lastPaymentReceivedDate { get; set; } //The date of last payment received on the lent funds
      public decimal paymentReceivedMtd { get; set; }   //The month-to-date total of payments received on lent funds
   }
}
