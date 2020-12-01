using System;
using System.Collections.Generic;
using System.Text;

namespace moodAnalyzerProblem
{
    public class MoodAnalyser
    {
        private string message;

        public MoodAnalyser() { }
        public MoodAnalyser(string message)
        {
            this.message = message;
        }

        public string analyzeMood()
        {
            try
            {
                if (this.message.Equals(string.Empty))
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.EMPTY_EXCEPTION, "Mood is empty");
                }
                if (this.message.Contains("Sad"))
                    return "SAD";
                else
                    return "HAPPY";
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NULL_EXCEPTION, "Mood is null");
            }

        }
    }
}
