using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OkonkwoETrade10.Framework;
using OkonkwoETrade10.REST;
using static OkonkwoETrade10.REST.ETrade10;

namespace OkonkwoETrade10Tests
{
   public partial class ETrade10Test
   {
      #region Default Configuration

      private static EEnvironment m_Environment = EEnvironment.Sandbox;
      private static string AccountID;
      private static string m_ConsumerKey;
      private static string m_ConsumerSecret;
      private static short m_Accounts = 2;

      #endregion

      #region Declarations

      private static bool m_ApiOperationsComplete = false;
      private static string m_Currency = "USD";
      //private static string m_Instrument = InstrumentName.Currency.USDCHF;
      //private static List<Instrument> m_OandaInstruments;
      //private static List<Price> m_OandaPrices;
      private static long m_FirstTransactionID;
      private static long m_LastTransactionID;
      private static string m_LastTransactionTime;
      private static decimal m_TestNumber;

      //protected List<Price> _prices;
      protected static ETrade10 m_ETrade10;
      #endregion

      [ClassInitialize]
      public static void RunApiOperations(TestContext context)
      {
         try
         {
            InitializeApplicationAsync().Wait();

            if (ETrade10.HasServer(EServer.Accounts))
            {
               // first, get accounts
               // this operation adds the test AccountId to Credentials (if it is null)
               Account_GetAccountsList(m_Accounts).Wait();

               // second, check market status
               Initialize_GetMarketStatus().Wait();

               // third, proceed with all other operations
               //await Account_GetAccountDetails();
               //await Account_GetAccountSummary();
               //await Account_GetAccountsInstruments();
               //await Account_GetSingleAccountInstrument();
               //await Account_PatchAccountConfiguration();

               //await Transaction_GetTransaction();
               //await Transaction_GetTransactionsSinceId();

               // important: do this before Orders and Trades tests
               //await Pricing_GetPricing();

               //await Instrument_GetInstrumentCandles();
               //await Instrument_GetInstrumentOrderBook();
               //await Instrument_GetInstrumentPositionBook();

               // test the pricing stream
               if (ETrade10.HasServer(EServer.PricingStream))
               {
                  //Stream_GetStreamingPrices();
               }

               // start transactions stream
               Task transactionsStreamCheck = null;
               if (ETrade10.HasServer(EServer.TransactionsStream))
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

         m_ETrade10 = new ETrade10(null);
         await m_ETrade10.Initialize(credentials);
      }

      private static async Task Initialize_GetMarketStatus()
      {
         bool marketIsHalted = await Utilities.IsMarketHalted();
         m_Results.Verify("00.0", marketIsHalted, "Market is halted.");
         if (marketIsHalted) throw new MarketHaltedException("Unable to continue tests. OANDA Fx market is halted!");
      }

      /// <summary>
      /// Retrieve the list of accounts associated with the account token
      /// </summary>
      /// <param name="listCount"></param>
      private static async Task Account_GetAccountsList(short? listCount = null)
      {
         short count = 0;

         var result = await m_ETrade10.ListAccountsAsync();
         m_Results.Verify("01.0", result.account.Count > 0, "Account list received.");

         string message = "Correct number of accounts received.";
         bool correctCount = true;
         if (listCount.HasValue)
         {
            count++;
            correctCount = result.account.Count == listCount;
            message = $"Correct number of accounts ({result.account.Count}) received.";
         }
         m_Results.Verify("01." + count.ToString(), correctCount, message);

         foreach (var account in result.account)
         {
            count++;
            string description = string.Format("AccountIdKey {0} has correct format.", account.accountId);
            m_Results.Verify("01." + count.ToString(), account.accountIdKey.Split('-').Length == 4, description);
         }

         // ensure the first account has sufficient funds
         //m_ConsumerSecret = m_ConsumerSecret ?? result.OrderBy(r => r.id).First().id;
         //Credentials.SetCredentials(m_Environment, m_ConsumerKey, m_ConsumerSecret);
      }

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
