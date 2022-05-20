using NUnit.Framework;

namespace PrivateMethods.Tests
{
    [TestFixture]
    public abstract class EmployeeTests
    {
        public abstract object CreateEmployee(string name);

        [Test]
        public void ContainsIllegalChars_WhenNameIsBob_ReturnFalse()
        {
            //Arrange
            object employeeInstance = CreateEmployee("Bob");

            //Act
            bool containsIllegalChars = (bool)employeeInstance.GetType()
                .GetMethod("ContainsIllegalChars", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(employeeInstance, null);
  
            //Assert
            Assert.False(containsIllegalChars);
        }

        [Test]
        public void ContainsIllegalChars_WhenNameIsDollarBob_ReturnTrue()
        {
            //Arrange
            object employeeInstance = CreateEmployee("$Bob");

            //Act
            bool containsIllegalChars = (bool)employeeInstance.GetType()
                .GetMethod("ContainsIllegalChars", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(employeeInstance, null);

            //Assert
            Assert.True(containsIllegalChars);
        }
    }
}
