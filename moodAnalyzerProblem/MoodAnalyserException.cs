using System;
using System.Collections.Generic;
using System.Text;

namespace moodAnalyzerProblem
{
    public class MoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION, NO_FIELD_EXCEPTION
        }

        private ExceptionType exceptionType;
        private string message;

        public MoodAnalyserException(ExceptionType exceptionType, string message)
        {
            this.exceptionType = exceptionType;
        }
            
    }
}
