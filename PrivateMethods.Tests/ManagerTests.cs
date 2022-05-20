using NUnit.Framework;
using System;
using System.Reflection;

namespace PrivateMethods.Tests
{
    [TestFixture]
    public class ManagerTests : EmployeeTests
    {
        public override object CreateEmployee(string name)
        {
            object[] parameters = { name };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo managerConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            return managerConstructor.Invoke(parameters);
        }

        [Test]
        public void PrintInfo_WhenNameIsBob_ReturnSpecificMessageAndEmpTypeShouldBe1()
        {
            //Arrange
            object[] parameters = { "Bob" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo managerConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = managerConstructor.Invoke(parameters);

            //Act
            string message = (string)managerType
                .GetMethod("PrintInfo", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.That(message, Is.EqualTo("I'm Manager Bob . I'm serious badass"));
            Assert.That(empType, Is.EqualTo(1));
        }

        [Test]
        public void PrintInfo_WhenNameIsPete_ReturnSpecificMessageAndEmpTypeShouldBe2()
        {
            //Arrange
            object[] parameters = { "Pete" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo managerConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = managerConstructor.Invoke(parameters);

            //Act
            string message = (string)managerType
                .GetMethod("PrintInfo", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.That(message, Is.EqualTo("I'm Manager Pete . I'm pretty ok"));
            Assert.That(empType, Is.EqualTo(2));
        }

        [Test]
        public void PrintInfo_WhenNameIsPete_ReturnSpecificMessageAndEmpTypeShouldBe3()
        {
            //Arrange
            object[] parameters = { "Peter" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo managerConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = managerConstructor.Invoke(parameters);

            //Act
            string message = (string)managerType
                .GetMethod("PrintInfo", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.That(message, Is.EqualTo("I'm Manager Peter . I'm really nice"));
            Assert.That(empType, Is.EqualTo(3));
        }

        [Test]
        public void PrintInfo_WhenNameIsPutin_ThrowExceptionAndEmpTypeShouldBe0()
        {
            //Arrange
            object[] parameters = { "Putin" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("Manager", "PrivateMethods");
            ConstructorInfo managerConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = managerConstructor.Invoke(parameters);

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
