using System;
using System.Collections.Generic;
using System.Text;

namespace moodAnalyzerProblem
{
    public class MoodAnalyserException : Exception
    {
        public enum ExceptionType
        {
            NULL_EXCEPTION, EMPTY_EXCEPTION, NO_FIELD_EXCEPTION, NO_SUCH_METHOD, NO_SUCH_CLASS
        }

        private ExceptionType exceptionType;
        private string message;

        public MoodAnalyserException(ExceptionType exceptionType, string message) :base(message)
        {
            this.exceptionType = exceptionType;
        }
            
    }
}
