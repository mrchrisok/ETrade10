using System;

namespace OkonkwoETrade10.Framework
{
   public class MarketHaltedException : Exception
   {
      public MarketHaltedException(string message) : base(message) { }
   }
}
