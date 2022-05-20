using NUnit.Framework;
using System;
using System.Reflection;

namespace PrivateMethods.Tests
{
    [TestFixture]
    public class ManagerTests
    {
        [Test]
        public void ContainsIllegalChars_WhenNameIsBob_ReturnFalseAndEmpTypeShouldBe1()
        {
            //Arrange
            object[] parameters = { "Bob" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = personConstructor.Invoke(parameters);

            //Act
            bool containsIllegalChars = (bool)managerType
                .GetMethod("ContainsIllegalChars", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.False(containsIllegalChars);
            Assert.That(empType, Is.EqualTo(1));
        }

        [Test]
        public void ContainsIllegalChars_WhenNameIsPete_ReturnFalseAndEmpTypeShouldBe2()
        {
            //Arrange
            object[] parameters = { "Pete" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = personConstructor.Invoke(parameters);

            //Act
            bool containsIllegalChars = (bool)managerType
                .GetMethod("ContainsIllegalChars", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.False(containsIllegalChars);
            Assert.That(empType, Is.EqualTo(2));
        }

        [Test]
        public void ContainsIllegalChars_WhenNameIsPete_ReturnFalseAndEmpTypeShouldBe3()
        {
            //Arrange
            object[] parameters = { "Jonas" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = personConstructor.Invoke(parameters);

            //Act
            bool containsIllegalChars = (bool)managerType
                .GetMethod("ContainsIllegalChars", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.False(containsIllegalChars);
            Assert.That(empType, Is.EqualTo(3));
        }

        [Test]
        public void ContainsIllegalChars_WhenNameIsDollarPutin_ReturnTrueAndEmpTypeShouldBe0()
        {
            //Arrange
            object[] parameters = { "$Putin" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = personConstructor.Invoke(parameters);

            //Act
            bool containsIllegalChars = (bool)managerType
                .GetMethod("ContainsIllegalChars", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.True(containsIllegalChars);
            Assert.That(empType, Is.EqualTo(0));
        }

        [Test]
        public void PrintInfo_WhenNameIsPutin_ThrowExceptionAndEmpTypeShouldBe0()
        {
            //Arrange
            object[] parameters = { "Putin" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = personConstructor.Invoke(parameters);

            //Act
            TestDelegate testDelegate = new(() =>
            {
                try
                {
                    managerType
                      .GetMethod("PrintInfo", ReflectionUtillity.DefaultBindingFlags)
                      .Invoke(managerInstance, null);
                }
                catch (TargetInvocationException ex)
                {
                    throw ex.InnerException; // Throws PrintInfo's ArgumentException
                }
            });
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.Throws<ArgumentException>(testDelegate);
            Assert.That(empType, Is.EqualTo(0));
        }
    }
}
