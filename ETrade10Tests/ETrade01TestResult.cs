using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OkonkwoETrade10Tests
{
   public class ETrade10TestResult
   {
      public bool Success { get; set; }
      public string Details { get; set; }
   }

   public class ETrade10TestResults
   {
      #region declarations

      private string m_LastMessage;
      private Dictionary<string, ETrade10TestResult> m_Results = new Dictionary<string, ETrade10TestResult>();
      private Dictionary<string, string> m_MutableMessages = new Dictionary<string, string>();

      #endregion

      #region public properties and methods

      public ReadOnlyDictionary<string, ETrade10TestResult> Items => new ReadOnlyDictionary<string, ETrade10TestResult>(m_Results);

      public ReadOnlyDictionary<string, string> Messages => new ReadOnlyDictionary<string, string>(m_MutableMessages);

      public string LastMessage => m_LastMessage;

      public bool Verify(bool success, string testDescription)
      {
         return Verify(DateTime.UtcNow.ToString(), success, testDescription);
      }

      public bool Verify(string success, string testDescription)
      {
         return Verify(DateTime.UtcNow.ToString(), !string.IsNullOrEmpty(success), testDescription);
      }

      public bool Verify(string key, string success, string testDescription)
      {
         return Verify(key, !string.IsNullOrEmpty(success), testDescription);
      }

      public bool Verify(string key, bool success, string testDescription)
      {
         m_Results.Add(key, new ETrade10TestResult { Success = success, Details = testDescription });

         if (!success)
            Add(key + ": " + success + ": " + testDescription); // add message

         return success;
      }

      public void Add(string key, ETrade10TestResult testResult)
      {
         m_Results.Add(key, testResult);
      }

      public void Add(string message)
      {
         m_LastMessage = message;
         m_MutableMessages.Add(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + ':' + m_MutableMessages.Count, message);
      }
      #endregion
   }
}
