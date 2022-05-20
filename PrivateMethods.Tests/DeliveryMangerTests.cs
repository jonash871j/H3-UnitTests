using NUnit.Framework;
using System;
using System.Reflection;


namespace PrivateMethods.Tests
{
    [TestFixture]
    public class DeliveryManagerTests
    {
        [Test]
        public void PrintInfo_WhenNameIsBob_ReturnImDeliveryManagerBobAndEmpShouldBe2()
        {
            //Arrange
            object[] parameters = { "Bob" };
            Type managerType = ReflectionUtillity.GetTypeInNamespace("DeliveryManager", "PrivateMethods");
            ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(managerType, parameters);
            object managerInstance = personConstructor.Invoke(parameters);

            //Act
            string info = (string)managerType
                .GetMethod("PrintInfo", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(managerInstance, null);
            int empType = (int)managerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(managerInstance);

            //Assert
            Assert.That(info, Is.EqualTo("I'm Delivery Manager Bob "));
            Assert.That(empType, Is.EqualTo(2));
        }

    }
}
