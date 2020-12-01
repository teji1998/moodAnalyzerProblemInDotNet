using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace moodAnalyzerProblem
{
    public class MoodAnalyserFactory
    {
        public static object CreateMoodAnalyser(string className, string constructorName)
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
                }
                catch (ArgumentNullException)
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

            public static object CreateMoodAnalyserObjectwithParaMeterizedConstructor(string className, string constructorName, string message)
            {
                Type type = typeof(MoodAnalyser);
                if (type.Name.Equals(className) || type.FullName.Equals(className))
                {
                    if (type.Name.Equals(constructorName))
                    {
                        ConstructorInfo constructor = type.GetConstructor(new[] { typeof(string) });
                        object instance = constructor.Invoke(new object[] { message });
                        return instance;
                    }
                    else
                    {
                        throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such constructor present");
                    }
                }
                else
                {
                    throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_CLASS, "No such class present");
                }
            }

        public static string InvokeAnalyzeMethod(string message, string methodName)
        {
            try
            {
                Type type = Type.GetType("moodAnalyzerProblem.MoodAnalyser");
                object moodAnalyseObject =MoodAnalyserFactory.CreateMoodAnalyserObjectwithParaMeterizedConstructor("moodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObject, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserException(MoodAnalyserException.ExceptionType.NO_SUCH_METHOD, "No such class present");
            }
        }


    }
}
