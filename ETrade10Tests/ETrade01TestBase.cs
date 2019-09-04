namespace OkonkwoETrade10Tests
{
   public class ETrade10TestBase
   {
      protected static readonly ETrade10TestResults m_Results;
      protected short m_FailedTests = 0;

      public ETrade10TestResults Results => m_Results;
      public short Failures => m_FailedTests;

      static ETrade10TestBase()
      {
         m_Results = new ETrade10TestResults();
      }
   }
}
