using BankLib.Expcetions;
using BankLib.Services;
using Moq;
using NUnit.Framework;
using System;

namespace BankLib.Tests
{
    [TestFixture]
    public class ATMServiceTests
    {
		[Test]
		public void WithdrawMoney_PinIsCorretAndValidMoneyAmountIsSpecified_ReturnMoney()
		{
			//Arrange
			int accountId = 0;
			int pin = 1234;
			int moneyToWithdraw = 100;
			Mock<IDatabaseSimulationService> databaseSimulationService = new();
			ATMService atmService = new(databaseSimulationService.Object);
			databaseSimulationService
				.Setup(e => e.IsPinValid(accountId, pin))
				.Returns(true);
			databaseSimulationService
				.Setup(e => e.TakeMoneyFromAccount(accountId, moneyToWithdraw))
				.Returns(moneyToWithdraw);

			//Act
			int result = atmService.WithdrawMoney(accountId, pin, moneyToWithdraw);

			//Assert
			Assert.That(result, Is.EqualTo(moneyToWithdraw));
			databaseSimulationService.Verify(s => s.IsPinValid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
			databaseSimulationService.Verify(s => s.TakeMoneyFromAccount(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
		}

		[Test]
		public void WithdrawMoney_PinIsWrongAndValidMoneyAmountIsSpecified_ThrowsException()
		{
			//Arrange
			int accountId = 0;
			int pin = 1234;
			int moneyToWithdraw = 100;
			Mock<IDatabaseSimulationService> databaseSimulationService = new();
			ATMService atmService = new(databaseSimulationService.Object);
			databaseSimulationService
				.Setup(e => e.IsPinValid(accountId, pin))
				.Returns(false);
			databaseSimulationService
				.Setup(e => e.TakeMoneyFromAccount(accountId, moneyToWithdraw))
				.Returns(moneyToWithdraw);

			//Act
			TestDelegate testDelegate = new (() => atmService.WithdrawMoney(accountId, pin, moneyToWithdraw));

			//Assert
			Assert.Throws<InvalidPinException>(testDelegate);
			databaseSimulationService.Verify(s => s.IsPinValid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
			databaseSimulationService.Verify(s => s.TakeMoneyFromAccount(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
		}

		[Test]
		public void WithdrawMoney_PinIsCorrectButThereIsNotEnoughMoneyOnTheAccount_ThrowsException()
		{
			//Arrange
			int accountId = 0;
			int pin = 1234;
			int moneyToWithdraw = 100;
			Mock<IDatabaseSimulationService> databaseSimulationService = new();
			ATMService atmService = new(databaseSimulationService.Object);
			databaseSimulationService
					.Setup(e => e.IsPinValid(accountId, pin))
					.Returns(true);
			databaseSimulationService
				.Setup(e => e.TakeMoneyFromAccount(accountId, moneyToWithdraw))
				.Returns(0);

			//Act
			TestDelegate testDelegate = new(() => atmService.WithdrawMoney(accountId, pin, moneyToWithdraw));

			//Assert
			Assert.Throws<NotEnoughMoneyException>(testDelegate);
			databaseSimulationService.Verify(s => s.IsPinValid(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
			databaseSimulationService.Verify(s => s.TakeMoneyFromAccount(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
		}

		[Test]
		public void WithdrawMoney_PinIsCorrectButSpecifiedMoneyIsZero_ThrowsException()
		{
			//Arrange
			int accountId = 0;
			int pin = 1234;
			int moneyToWithdraw = 0;
			Mock<IDatabaseSimulationService> databaseSimulationService = new();
			ATMService atmService = new(databaseSimulationService.Object);
			databaseSimulationService
					.Setup(e => e.IsPinValid(accountId, pin))
					.Returns(true);
			databaseSimulationService
				.Setup(e => e.TakeMoneyFromAccount(accountId, moneyToWithdraw))
				.Returns(0);

			//Act
			TestDelegate testDelegate = new(() => atmService.WithdrawMoney(accountId, pin, moneyToWithdraw));

			//Assert
			Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
			databaseSimulationService.Verify(s => s.IsPinValid(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
			databaseSimulationService.Verify(s => s.TakeMoneyFromAccount(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
		}
	}
}
