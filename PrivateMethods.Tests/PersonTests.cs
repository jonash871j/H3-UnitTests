using NUnit.Framework;
using System;
using System.Reflection;

namespace PrivateMethods.Tests
{
	[TestFixture]
	public class PersonTests
    {
		[Test]
		public void IsOld_WhenAgeIs60_ReturnTrue()
		{
			//Arrange
			object[] parameters = { 60, "man" };
			Type personType = ReflectionUtillity.GetTypeInNamespace("Person", "PrivateMethods");
			ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(personType, parameters);
			object personInstance = personConstructor.Invoke(parameters);

			//Act
			bool isOld = (bool)personType
                .GetMethod("IsOld", ReflectionUtillity.DefaultBindingFlags)
                .Invoke(personInstance, null);

            //Assert
            Assert.True(isOld);
        }

		[Test]
		public void IsOld_WhenAgeIsMinus10_ReturnFalseAndAgeShouldBe0()
        {
			//Arrange
			object[] parameters = { -10, "man" };
			Type personType = ReflectionUtillity.GetTypeInNamespace("Person", "PrivateMethods");
			ConstructorInfo personConstructor = ReflectionUtillity.GetConstructorInfoByParameters(personType, parameters);
			object personInstance = personConstructor.Invoke(parameters);

			//Act
			bool isOld = (bool)personType
				.GetMethod("IsOld", ReflectionUtillity.DefaultBindingFlags)
				.Invoke(personInstance, null);
			int age = (int)personType
				.GetField("age", ReflectionUtillity.DefaultBindingFlags)
				.GetValue(personInstance);

			//Assert
			Assert.False(isOld);
			Assert.That(age == 0);
		}
	}
}