using NUnit.Framework;
using System;
using System.Reflection;

namespace PrivateMethods.Tests
{
    [TestFixture]
    public class DeliveryManagerTests : EmployeeTests
    {
        public override object CreateEmployee(string name)
        {
            object[] parameters = { name };
            Type deliveryManagerType = ReflectionUtillity.GetTypeInNamespace("DeliveryManager", "PrivateMethods");
            ConstructorInfo deliveryManagerConstructor = ReflectionUtillity.GetConstructorInfoByParameters(deliveryManagerType, parameters);
            return deliveryManagerConstructor.Invoke(parameters);
        }

        [Test]
        public void PrintInfo_WhenNameIsBob_ReturnImDeliveryManagerBobAndEmpShouldBe2()
        {
            //Arrange
            object[] parameters = { "Bob" };
            Type deliveryManagerType = ReflectionUtillity.GetTypeInNamespace("DeliveryManager", "PrivateMethods");
            ConstructorInfo deliveryManagerConstructor = ReflectionUtillity.GetConstructorInfoByParameters(deliveryManagerType, parameters);
            object deliveryManagerInstance = deliveryManagerConstructor.Invoke(parameters);

            //Act
            string info = (string)deliveryManagerType
                .GetMethod("PrintInfo", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(deliveryManagerInstance, null);
            int empType = (int)deliveryManagerType
              .GetField("empType", ReflectionUtillity.DefaultBindingFlags)
              .GetValue(deliveryManagerInstance);

            //Assert
            Assert.That(info, Is.EqualTo("I'm Delivery Manager Bob "));
            Assert.That(empType, Is.EqualTo(2));
        }

    }
}
