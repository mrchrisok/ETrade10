using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OkonkwoETrade10.REST;
using static OkonkwoETrade10.REST.ETrade10;

namespace OkonkwoETrade10App
{
   internal class Program
   {
      private static ETrade10 _ETrade10;
      private static EEnvironment m_Environment;
      private static void Main(string[] args)
      {
         WriteNewLine("Hello trader! Welcome to OkonkwoETrade10");

         AuthorizeApplication().Wait();

         PutOnATrade().Wait();

         Console.ReadKey();
      }

      private const string INSTRUMENT = "SPX";

      private static async Task AuthorizeApplication()
      {
         WriteNewLine("Setting your ETrade10 credentials ...");

         _ETrade10 = new ETrade10(null);

         await _ETrade10.Initialize(GetCredentials(null));

         WriteNewLine("Nice! Application is authorized.");
      }

      private static Credentials GetCredentials(string fileName)
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

               string jsonCredentials = sr.ReadToEnd();
               credentials = JsonConvert.DeserializeObject<Credentials>(jsonCredentials);
               credentials.environment = m_Environment;

               return JsonConvert.DeserializeObject<Credentials>(jsonCredentials);
            }
         }
         catch (Exception ex)
         {
            throw new Exception("Could not read api credentials.", ex);
         }
      }

      #region trading
      private static async Task PutOnATrade()
      {
         WriteNewLine($"Checking to see if {INSTRUMENT} is open for trading ...");

         // first, check the market status for the INSTRUMENT
         // if it is tradeable, we'll try to make some money :)
         if (!(await OkonkwoETrade10.Framework.Utilities.IsMarketHalted(INSTRUMENT)))
         {
            WriteNewLine($"{INSTRUMENT} is open and rockin', so let's start trading!");

            long? tradeID = await PlaceMarketOrder();

            if (tradeID.HasValue)
            {
               // we have an open trade.
               // give it some time to make money :)
               await Task.Delay(10000);

               WriteNewLine("Okay, we've waited 10 seconds. Closing trade now ...");

               // now, let' close the trade and collect our profits! .. hopefully
               //TradeCloseResponse closeResponse = null;
               //try
               //{
               //   var parameters = new TradeCloseParameters() { units = "ALL" };
               //   closeResponse = await Rest20.PutTradeCloseAsync(AccountID, tradeID.Value, parameters);
               //}
               //catch
               //{
               //   WriteNewLine("Oops. The trade can't be closed. Something went wrong. :(");
               //}

               //if (closeResponse != null)
               //{
               //   WriteNewLine("Nice! The trade is closed.");

               //   var profit = closeResponse.orderFillTransaction.pl;
               //   WriteNewLine($"Our profit was USD {profit}");

               //   if (profit > 0)
               //      WriteNewLine($"Nice work! You are an awesome trader.");
               //   else
               //   {
               //      WriteNewLine($"Looks like you need to learn some money-making strategies. :(");
               //      WriteNewLine($"Keep studying, learning, but most of all .. keep trading!!");
               //   }
               //}
            }
            else
            {
               WriteNewLine($"Looks like something went awry with the trade. you need to learn some money-making strategies. :(");
            }
         }
         else
         {
            WriteNewLine("Sorry, Oanda markets are closed or Euro market is not tradeable.");
            WriteNewLine("Try again another time.");
         }
      }

      private static async Task<long?> PlaceMarketOrder(string side = "buy")
      {
         return 2;

         //WriteNewLine($"Creating a {INSTRUMENT} market BUY order ...");

         //var parameters = new PlaceOrderRequest() { instruments = new List<string>() { INSTRUMENT } };
         //var oandaInstrument = (await Rest20.GetAccountInstrumentsAsync(AccountID, parameters)).First();
         //long orderUnits = side == "buy" ? 10 : -10;

         //var request = new PlaceOrderRequest(oandaInstrument)
         //{
         //   units = orderUnits
         //};

         //PlaceOrderResponse response = null;
         //try
         //{
         //   response = await _ETrade10.PlaceOrderAsync(AccountID, request);
         //   WriteNewLine("Congrats! You've put on a trade! Let it run! :)");
         //}
         //catch (Exception ex)
         //{
         //   var errorResponse = ErrorResponseFactory.Create(ex.Message);

         //   WriteNewLine("Oops. Order creation failed.");
         //   WriteNewLine($"The failure message is: {errorResponse.errorMessage}.");
         //   WriteNewLine("Try again later.");
         //}

         //return response?.orderFillTransaction?.tradeOpened?.tradeID;
      }
      #endregion

      private static void WriteNewLine(string message)
      {
         Console.WriteLine($"\n{message}");
      }
   }
}
