using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using ETrade10Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OkonkwoETrade10.Accounts;
using OkonkwoETrade10.Authorization.OkonkwoOAuth;
using OkonkwoETrade10.Common;
using OkonkwoETrade10.Framework;
using OkonkwoETrade10.REST;
using static OkonkwoETrade10.REST.ETrade10;

namespace OkonkwoETrade10Tests
{
   public class ETrade10TestConfiguration
   {
      // put this in the container
   }

   public partial class ETrade10Test
   {
      #region Default Configuration

      private static EEnvironment m_Environment = EEnvironment.Production;
      private static short m_NumberOfAccounts = 4;

      private static Accounts m_Accounts;


      #endregion

      #region Declarations

      private static bool m_ApiOperationsComplete = false;
      private static string m_Currency = "USD";
      private static string m_Security = SecurityNames.Equities.Google;
      private static long m_TestTransactionID = 19274101224905;
      private static long m_LastTransactionID;
      private static string m_LastTransactionTime;
      private static decimal m_TestNumber;

      //protected List<Price> _prices;
      protected static ETrade10 m_ETrade10;
      #endregion

      [ClassInitialize]
      public static async Task RunApiOperations(TestContext context)
      {
         try
         {
            await InitializeApplicationAsync();

            if (m_ETrade10.HasServer(EServer.Accounts))
            {
               await Market_GetMarketStatus();

               // accounts
               await Account_ListAccounts(m_NumberOfAccounts);
               await Account_GetAccountBalances();
               await Account_ListTransactions();
               await Account_ListTransactionDetails();
               //await Account_ViewPortfolio();

               //await Transaction_GetTransaction();
               //await Transaction_GetTransactionsSinceId();

               // important: do this before Orders and Trades tests
               //await Pricing_GetPricing();

               //await Instrument_GetInstrumentCandles();
               //await Instrument_GetInstrumentOrderBook();
               //await Instrument_GetInstrumentPositionBook();

               // test the pricing stream
               if (m_ETrade10.HasServer(EServer.PricingStream))
               {
                  //Stream_GetStreamingPrices();
               }

               // start transactions stream
               Task transactionsStreamCheck = null;
               if (m_ETrade10.HasServer(EServer.TransactionsStream))
               {
                  //transactionsStreamCheck = Stream_GetStreamingTransactions();
               }

               // create stream traffic
               //await Order_RunOrderOperations();
               //await Trade_RunTradeOperations();
               //await Position_RunPositionOperations();

               // stop transactions stream 
               if (transactionsStreamCheck != null)
               {
               }

               // review the traffic
               //await Transaction_GetTransactionsByDateRange();
               //await Transaction_GetTransactionsByIdRange();
               //await Account_GetAccountChanges();
            }
         }
         catch (MarketHaltedException ex)
         {
            throw ex;
         }
         catch (Exception ex)
         {
            throw new Exception("An unhandled error occured during execution of ETrade10 operations.", ex);
         }
         finally
         {
            m_ApiOperationsComplete = true;
         }
      }

      /// <summary>
      /// Reads the api key from a supplied file name
      /// </summary>
      /// <returns></returns>
      private static async Task InitializeApplicationAsync(string fileName = null)
      {
         // reading this from a file for now
         // should be read from db or secure key vault for production

         string environment = m_Environment.ToString();
         fileName = fileName ?? $@"C:\Users\Osita\SourceCode\GitHub\ETrade10\etrade{environment}.credentials.json";

         Credentials credentials = null;
         try
         {
            using (var sr = new StreamReader(fileName))
            {
               // an ETrade account is required to generate a valid consumer key and secret
               // for info, go to: https://developer.etrade.com/home

               string jsonCredentials = await sr.ReadToEndAsync();
               credentials = JsonConvert.DeserializeObject<Credentials>(jsonCredentials);
               credentials.environment = m_Environment;
            }
         }
         catch (Exception ex)
         {
            throw new ApplicationException("Could not read api credentials.", ex);
         }

         m_ETrade10 = new ETrade10(MEFLoader.Container.GetExport<IOAuthService>(), null);
         await m_ETrade10.Initialize(credentials);
      }

      /// <param name="symbol"></param>
      /// <returns></returns>
      private static async Task Market_GetMarketStatus()
      {
         var symbols0 = new[] { m_Security };

         var symbols1 = new[] { m_Security,
            "CDW", "ONCE", "BAC", "KEYS", "ALL", "HON", "VUG", "ALV", "UL", "GS", "JPM", "ROKU", "MGM", "OXY",
            "CNC", "ULTA", "XLF", "CEC", "VOO", "BSX", "FB", "X", "SNAP", "KKR", "GLD", "PVH", "USO", "MASI",
            "GPN", "CHW", "IBM", "CVX", "TRP", "JNJ", "DDS", "MSI", "GOOG", "CAT", "SQ", "ADSK", "TXG", "AMN",
            "MHK", "CLF", "PEP", "PM", "BR", "BYND", "BMA", "RIO", "CB", "WMT", "AVLR", "GE", "CDNS", "LRCK",
            "AAPL", "AMD", "C", "CRM", "DIS", "F", "ROK", "FDX", "MSFT", "ZOOM", "KLAC", "NFLX", "UPS", "WFC"
         };

         bool marketIsHalted = await m_ETrade10.IsMarketHalted(new[] { m_Security });
         m_Results.Verify("00.0", marketIsHalted, "Market is halted.");

         //if (marketIsHalted)
         //   throw new MarketHaltedException($"Unable to continue tests. Test security {m_Security} is halted!");
      }

      #region Account operations

      /// <summary>
      /// Retrieve the list of accounts associated with the account token
      /// </summary>
      /// <param name="listCount"></param>
      private static async Task Account_ListAccounts(short? listCount = null)
      {
         short count = 0;

         m_Accounts = await m_ETrade10.ListAccountsAsync();
         m_Results.Verify("01.0", m_Accounts.account.Count > 0, "Account list received.");

         string message = "Correct number of accounts received.";
         bool correctCount = true;
         if (listCount.HasValue)
         {
            count++;
            correctCount = m_Accounts.account.Count == listCount;
            message = $"Correct number of accounts ({m_Accounts.account.Count}) received.";
         }
         m_Results.Verify("01." + count.ToString(), correctCount, message);

         foreach (var account in m_Accounts.account)
         {
            count++;

            var accountIdLength = account.accountId.Length;
            var accountIdKeyLength = account.accountIdKey.Length;
            string description = $"AccountIdKey {account.accountIdKey} has correct format.";
            m_Results.Verify("01." + count.ToString(), accountIdKeyLength > accountIdLength, description);
         }

         // ensure the first account has sufficient funds
         //m_ConsumerSecret = m_ConsumerSecret ?? result.OrderBy(r => r.id).First().id;
         //Credentials.SetCredentials(m_Environment, m_ConsumerKey, m_ConsumerSecret);
      }

      private static async Task Account_GetAccountBalances(short? listCount = null)
      {
         var accountIdKey = m_Accounts.account[0].accountIdKey;
         var parameters = new BalanceParameters();
         var result = await m_ETrade10.GetAccountBalancesAsync(accountIdKey, new BalanceParameters());
         m_Results.Verify("02.0", result.Computed?.netCash > 0, "Account balance received.");
      }

      private static async Task Account_ListTransactions()
      {
         var accountIdKey = m_Accounts.account[0].accountIdKey;
         var parameters = new TransactionListParameters()
         {
            startDate = DateTime.UtcNow.AddYears(-2).ToString("MMddyyyy")
         };
         var result = await m_ETrade10.ListTransactionsAsync(accountIdKey, parameters);
         m_Results.Verify("03.0", result?.transactions.Count > 0, "Account transactions received.");
         m_Results.Verify("03.1", result?.transactions.Count > 0, "Account transactions received.");
         m_Results.Verify("03.2", result?.transactions.Count > 0, "Account transactions received.");
      }

      private static async Task Account_ListTransactionDetails()
      {
         var accountIdKey = m_Accounts.account[0].accountIdKey;
         var parameters = new TransactionDetailsParameters();
         var result = await m_ETrade10.ListTransactionDetailsAsync(accountIdKey, m_TestTransactionID, parameters);
         m_Results.Verify("04.0", result != null, "Transaction details received.");
         m_Results.Verify("04.1", result?.accountId != null, "Transaction id received.");
         m_Results.Verify("04.2", result?.description != null, "Transaction description received.");
         m_Results.Verify("04.3", result?.transactionDate != null, "Transaction time received.");
      }

      #endregion

      #region Utilities
      /// <summary>
      /// Convert DateTime object to a string of the indicated format
      /// </summary>
      /// <param name="time">A DateTime object</param>
      /// <param name="format">Format type (RFC3339 or UNIX only</param>
      /// <returns>A date-time string</returns>
      private static string ConvertDateTimeToAcceptDateFormat(DateTime time, AcceptDatetimeFormat format = AcceptDatetimeFormat.RFC3339)
      {
         // look into doing this within the JsonSerializer so that objects can use DateTime instead of string

         if (format == AcceptDatetimeFormat.RFC3339)
            return XmlConvert.ToString(time, "yyyy-MM-ddTHH:mm:ssZ");
         else if (format == AcceptDatetimeFormat.Unix)
            return ((int)time.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();
         else
            throw new ArgumentException($"The value ({(short)format}) of the format parameter is invalid.");
      }

      /// <summary>
      /// Computes and returns the next test characteristic (whole number)
      /// </summary>
      /// <returns></returns>
      private static string GetTestNumber(bool incrementCharacteristic = false)
      {
         if (incrementCharacteristic)
            m_TestNumber = Math.Truncate(m_TestNumber) + 1;
         else
            m_TestNumber = m_TestNumber + (decimal).001;

         return m_TestNumber.ToString("0.000");
      }

      #endregion
   }
}
