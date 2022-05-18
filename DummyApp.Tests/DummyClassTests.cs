using NUnit.Framework;

namespace DummyLib.Tests
{
    [TestFixture]
    public class DummyClassTests
    {
        [Test]
        public void IsAllowed_WhenUsernameIsAdmin_ReturnTrue()
        {
            //Arrange
            DummyClass dummyClass = new DummyClass();

            //Act
            bool result = dummyClass.IsAllowed("admin");

            //Assert
            Assert.True(result);
        }

        [Test]
        public void IsAllowed_WhenUsernameIsDummy_ReturnFalse()
        {
            //Arrange
            DummyClass dummyClass = new DummyClass();

            //Act
            bool result = dummyClass.IsAllowed("dummy");

            //Assert
            Assert.False(result);
        }

        [Test]
        public void AbsNumber_WhenNumberIsMinus100_ReturnPlus100()
        {
            //Arrange
            DummyClass dummyClass = new DummyClass();

            //Act
            double result = dummyClass.AbsNumber(-100);

            //Assert
            Assert.IsTrue(result == 100);
        }

        [Test]
        public void SignNumber_WhenNumberIsMinus100_ReturnMinus1()
        {
            //Arrange
            DummyClass dummyClass = new DummyClass();

            //Act
            double result = dummyClass.SignNumber(-100);

            //Assert
            Assert.True(result == -1);
        }
    }
}
