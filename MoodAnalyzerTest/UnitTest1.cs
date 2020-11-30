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
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Sad Mood");
            string mood = moodAnalyser.analyzeMood();
            Assert.AreEqual("SAD", mood);
        }

        [TestMethod]
        public void givenHappyMood_WhenAnalyzed_ShouldReturnHappy()
        {
            MoodAnalyser moodAnalyser = new MoodAnalyser("I am in Happy Mood");
            string mood = moodAnalyser.analyzeMood();
            Assert.AreEqual("HAPPY", mood);
        }

    }
}
