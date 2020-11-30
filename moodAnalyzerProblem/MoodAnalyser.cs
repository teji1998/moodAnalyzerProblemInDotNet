using System;
using System.Collections.Generic;
using System.Text;

namespace moodAnalyzerProblem
{
    public class MoodAnalyser
    {
        private string message;
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string analyzeMood(string message)
        {
            try
            {
                if (this.message.Contains("Sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                return "HAPPY";
            }

        }
    }
}
