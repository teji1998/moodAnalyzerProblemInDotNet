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

        public string analyzeMood()
        {
            if (this.message.Contains("Sad"))
                return "SAD";
            else
                return "HAPPY";
        }
    }
}
