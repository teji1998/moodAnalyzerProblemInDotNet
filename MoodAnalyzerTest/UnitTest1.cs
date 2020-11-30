using Microsoft.VisualStudio.TestTools.UnitTesting;
using moodAnalyzerProblem;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void givenSadMood_WhenAnalyzed_ShouldReturnSad()
        {
            string message = "I am Sad Message";
            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            string mood = moodAnalyser.analyzeMood(message);
            Assert.AreEqual("SAD", mood);
        }

        [TestMethod]
        public void givenHappyMood_WhenAnalyzed_ShouldReturnHappy()
        {
            string message = "I am in Happy Mood";
;            MoodAnalyser moodAnalyser = new MoodAnalyser(message);
            string mood = moodAnalyser.analyzeMood(message);
            Assert.AreEqual("HAPPY", mood);
        }

    }
}
