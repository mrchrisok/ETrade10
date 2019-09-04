namespace OkonkwoETrade10.Order
{
   /// <summary>
   /// https://apisb.etrade.com/docs/api/order/api-order-v1.html#/definitions/Disclosure
   /// </summary>
   public class Disclosure
   {
      /// <summary>
      /// The disclosure flag value
      /// </summary>
      public bool ehDisclosureFlag { get; set; }

      /// <summary>
      /// The AH disclosure flag value
      /// </summary>
      public bool ahDisclosureFlag { get; set; }

      /// <summary>
      /// The conditional disclosure flag value
      /// </summary>
      public bool conditionalDisclosureFlag { get; set; }

      /// <summary>
      /// The advanced order disclosure flag value
      /// </summary>
      public bool aoDisclosureFlag { get; set; }

      /// <summary>
      /// The mutual fund FL consent flag value
      /// </summary>
      public bool mfFLConsent { get; set; }

      /// <summary>
      /// The mutual fund EO consent flag value
      /// </summary>
      public bool mfEOConsent { get; set; }
   }
}
