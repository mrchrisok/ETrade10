using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OkonkwoETrade10.Authorization.OkonkwoOAuth;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OkonkwoETrade10.REST
{
   public partial class ETrade10
   {
      /// <summary>
      /// OAuth - 6.2.2. Service Provider Authenticates the User and Obtains Consent |
      /// ETrade - https://apisb.etrade.com/docs/api/authorization/authorize.html
      /// </summary>
      /// <param name="requestTokenInfo"></param>
      /// <returns></returns>
      protected async Task<AuthorizeResponse> AuthorizeApplicationAsync()
      {
         return await Task.Run(() =>
         {
            var parameters = new OAuthParameters()
            {
               HttpMethod = HttpMethod.Get,
               Url = GetServer(EServer.Authorize),
               Binding = OAuthParametersBinding.QueryString,
               Values = new Dictionary<string, string>() { { "oauth_token", Credentials.RequestToken.oauth_token } }
            };

            using (WebDriver)
            {
               try
               {
                  // login to account
                  WebDriver.Navigate().GoToUrl(OAuthSvc.GetAuthorizationUrl(parameters));
                  FindDriverElement("input", name: "USER").SendKeys(Credentials.userName);
                  FindDriverElement("input", name: "PASSWORD").SendKeys(Credentials.password);
                  var whiteListCookie = new Cookie(Credentials.consumerCookie.Key, Credentials.consumerCookie.Value);
                  WebDriver.Manage().Cookies.AddCookie(whiteListCookie);
                  FindDriverElement("button", id: "logon_button").Submit();

                  // agree to terms
                  FindDriverElement("input", name: "submit", value: "Accept").Submit();

                  // get & return the authorization code
                  string authorizationCode = FindDriverElement("input").GetAttribute("value");
                  return new AuthorizeResponse() { oauth_verifier = authorizationCode };
               }
               catch (Exception ex)
               {
                  throw new Exception("AuthorizeApplicationAsync failed: ", ex);
               }
            }
         });
      }

      private IWebElement FindDriverElement(string tagName, string id = "", string name = "", string value = "")
      {
         WaitForLoad(WebDriver);

         IEnumerable<IWebElement> elements = WebDriver.FindElements(By.TagName(tagName));
         IWebElement foundElement = null;

         if (elements?.Count() > 0)
         {
            if (elements.Count() == 1 && id == "" && name == "" && value == "")
               return elements.First();

            bool foundDriverElement(string parameterName, string parameterValue)
            {
               try
               {
                  var findElements = elements.Where(el => el.GetAttribute(parameterName).Equals(parameterValue));
                  if (findElements.Count() > 1)
                     elements = findElements;
                  else if (findElements.Count() == 1)
                     foundElement = findElements.First();
               }
               catch { }

               return foundElement != null;
            };

            if (id != "" && foundDriverElement("id", id))
               return foundElement;

            if (name != "" && foundDriverElement("name", name))
               return foundElement;

            if (value != "" && foundDriverElement("value", value))
               return foundElement;
         }

         string elementNotFoundMessage = $"Unique element (tagName: {tagName}, id: {id}, name: {name}, value: {value}) not found.";
         throw new Exception(elementNotFoundMessage);
      }

      private static void WaitForLoad(IWebDriver driver, int timeoutSec = 15)
      {
         IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
         WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, timeoutSec));
         wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
         Task.Delay(50).Wait(); // wait a bit
      }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class AuthorizeResponse : Response
   {
      /// <summary>
      /// The verification code to be used by the user to authenticate with the third-party application.
      /// </summary>
      public string oauth_verifier { get; set; }
   }

   /// <summary>
   /// The GET success response
   /// </summary>
   public class AuthorizeErrorResponse : ErrorResponse
   {

   }
}
