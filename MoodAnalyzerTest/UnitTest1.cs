using Microsoft.VisualStudio.TestTools.UnitTesting;
using moodAnalyzerProblem;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void givenSadMood_Should_Return_Sad()
        {
            MoodAnalyser analyser = new MoodAnalyser("i am  in Sad Mood");
            string mood = analyser.analyzeMood();
            Assert.AreEqual("SAD", mood);
        }
        [TestMethod]
        public void givenHappyMood_Should_Return_Happy()
        {
            MoodAnalyser analyser = new MoodAnalyser("i am  in Happy Mood");
            string mood = analyser.analyzeMood();
            Assert.AreEqual("HAPPY", mood);
        }
        [TestMethod]
        public void givenNullMood_Should_Return_Happy()
        {
            MoodAnalyser analyser = new MoodAnalyser("i am  in Null Mood");
            string mood = analyser.analyzeMood();
            Assert.AreEqual("HAPPY", mood);
        }
        [TestMethod]
        public void givenNullMood_Should_Return_Exception()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.analyzeMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual("Mood is null", e.Message);
            }
        }
        /*[TestMethod]
        public void givenInvalidMood_Should_Return_Exception()
        {
            try
            {
                string message = "";
                MoodAnalyser moodAnalyser = new MoodAnalyser(message);
                string mood = moodAnalyser.analyzeMood();
            }
            catch (MoodAnalyserException e)
            {
                Assert.AreEqual("Mood should not the excepeted", e.Message);
            }
        }*/

        [TestMethod]
        public void GivenMoodAnalyser_className_Should_ReturnMoodAnalyserObject()
        {
            //Arrange
            object expexted = new MoodAnalyser();
            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyser("moodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            //Assert
            expexted.Equals(obj);
        }

        [TestMethod]
        public void GivenMoodAnalyser_withImproperClassName_ShouldThrowException()
        {
            try
            {
                //Arrange
                string className = "Demo.MoodAnalyser";
                string constructor = "MoodAnalyser";
                //Act
                object expected = new MoodAnalyser();
                object obj = MoodAnalyserFactory.CreateMoodAnalyser(className, constructor);
            }
            catch (MoodAnalyserException moodException)
            {
                //Assert
                Assert.AreEqual("No such class present", moodException.Message);
            }
        }

        [TestMethod]
        public void GivenMoodAnalyser_withImproperConstructorName_ShouldThrowException()
        {
            try
            {
                //Arrange
                string className = "MoodAnalyser.MoodAnalyser";
                string constructor = "MoodAnalyzer";
                //Act
                object expected = new MoodAnalyser();
                object obj = MoodAnalyserFactory.CreateMoodAnalyser(className, constructor);
            }
            catch (MoodAnalyserException moodException)
            {
                //Assert
                Assert.AreEqual("No such constructor present", moodException.Message);
            }
        }

        [TestMethod]
        public void GivenModdAalyserClassName_ShouldReturnMoodAnalyserObject_UsingParametrizedConstructor()
        {
            //Arrange
            object excpected = new MoodAnalyser("HAPPY");
            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectwithParaMeterizedConstructor("moodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", "HAPPY");
            //Assert
            excpected.Equals(obj);
        }

        [TestMethod]
        public void GivenModdAalyserImproperClassName_ShouldReturnMoodAnalyserObject_ShouldReturnConstructor()
        {
            try
            {
                //Arrange
                object excpected = new MoodAnalyser("sad");
                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectwithParaMeterizedConstructor("Demonamespace.MoodAnalyse", "MoodAnalyse", "HAPPY");
                //Assert
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("Class not found", exception.Message);
            }
        }

        [TestMethod]
        public void GivenModdAalyserImproperConstructorName_ShouldReturnMoodAnalyserObject_ShouldReturnConstructor()
        {
            try
            {
                //Arrange
                object excpected = new MoodAnalyser("sad");
                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectwithParaMeterizedConstructor("MoodAnalyser.MoodAnalyse", "MoodAnalyseee", "HAPPY");
                //Assert
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("Constructor not found", exception.Message);
            }
        }

    }
}
