﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace moodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className,string constructorName)
        {
            string pattern = @"." + constructorName + "$";
            Match output = Regex.Match(className, pattern);
            if (output.Success)
            {
                try
                {
                    Assembly executing = Assembly.GetExecutingAssembly();
                    Type type = Type.GetType(className);
                    return Activator.CreateInstance(type);
                } catch (ArgumentNullException)
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS,
                        "No such class present");
                } 
            }
            else
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such constructor present");
            }

        }
    }
}