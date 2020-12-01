using Microsoft.VisualStudio.TestTools.UnitTesting;
using moodAnalyzerProblem;

namespace MoodAnalyzerTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// /
        /// </summary>
        [TestMethod]
        public void GivenSadMood_WhenAnalyzed_ShouldReturnSad()
        {
            MoodAnalyser analyser = new MoodAnalyser("i am  in Sad Mood");
            string mood = analyser.analyzeMood();
            Assert.AreEqual("SAD", mood);
        }
        [TestMethod]
        public void GivenHappyMood_WhenAnalyzed_ShouldReturnHappy()
        {
            MoodAnalyser analyser = new MoodAnalyser("i am  in Happy Mood");
            string mood = analyser.analyzeMood();
            Assert.AreEqual("HAPPY", mood);
        }
        [TestMethod]
        public void GivenNullMood_WhenAnalyzed_ShouldReturnHappy()
        {
            MoodAnalyser analyser = new MoodAnalyser("i am  in Null Mood");
            string mood = analyser.analyzeMood();
            Assert.AreEqual("HAPPY", mood);
        }
        [TestMethod]
        public void GivenNullMood_WhenAnalysed_ShouldReturnException()
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
      
        [TestMethod]
        public void GivenMoodAnalyser_WithCorrectClassName_ShouldReturnMoodAnalyserObject()
        {
            //Arrange
            object expexted = new MoodAnalyser();
            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyser("moodAnalyzerProblem.MoodAnalyser", "MoodAnalyser");
            //Assert
            expexted.Equals(obj);
        }

        [TestMethod]
        public void GivenMoodAnalyser_WithWrongClassName_ShouldThrowException()
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
        public void GivenMoodAnalyser_WithWrongConstructorName_ShouldThrowException()
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
        public void GivenMoodAnalyserClassName_WhenAnalsed_ShouldReturnMoodAnalyserObject()
        {
            //Arrange
            object excpected = new MoodAnalyser("HAPPY");
            //Act
            object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectwithParaMeterizedConstructor("moodAnalyzerProblem.MoodAnalyser", "MoodAnalyser", "HAPPY");
            //Assert
            excpected.Equals(obj);
        }

        [TestMethod]
        public void GivenMoodAnalyserWrongClassName_WhenAnalysed_ShouldReturnsMoodAnalyserObject()
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
                Assert.AreEqual("No such class present", exception.Message);
            }
        }

        [TestMethod]
        public void GivenMoodAnalyserWrongConstructorName_WhenReturnsMoodAnalyserObject_ShouldReturnConstructor()
        {
            try
            {
                //Arrange
                object excpected = new MoodAnalyser("sad");
                //Act
                object obj = MoodAnalyserFactory.CreateMoodAnalyserObjectwithParaMeterizedConstructor("moodAnalyzerProblem.MoodAnalyser", "MoodAnalyseee", "HAPPY");
                //Assert
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("No such constructor present", exception.Message);
            }
        }

        [TestMethod]
        public void GivenHappyMood_UsingReflection_ShouldReturnHappy()
        {
            string expected = "HAPPY";
            string mood = MoodAnalyserFactory.InvokeAnalyzeMethod("i am Happy message", "analyzeMood");
            Assert.AreEqual(expected, mood);
        }

        [TestMethod]
        public void GivenHappyMood_WithWrongMethodName_ShouldThrowMoodAnalyserException()
        {
            try
            {
                string mood = MoodAnalyserFactory.InvokeAnalyzeMethod("This is happy message", "AnalyseMoodddd");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual("No such class present", exception.Message);
            }
        }

        [TestMethod]
        public void GivenHappyMessage_WithReflection_Should_ReturnHappy()
        {
            string result = MoodAnalyserFactory.setField("HAPPY", "message");
            Assert.AreEqual("HAPPY", result);
        }
        [TestMethod]
        public void GivenWrongMessage_WithReflection_Should_ReturnException()
        {
            try
            {
                string result = MoodAnalyserFactory.setField("HAPPY", "messagess");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(exception.Message, "Field is absent");
            }
        }
        [TestMethod]
        public void GivenNullMessage_WithReflection_ShouldReturnException()
        {
            try
            {
                string result = MoodAnalyserFactory.setField(null, "message");
            }
            catch (MoodAnalyserException exception)
            {
                Assert.AreEqual(exception.Message, "Message can't be null");
            }
        }


    }
}
