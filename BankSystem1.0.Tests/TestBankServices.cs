using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem1._0.Controllers;
using Telerik.JustMock;
using BankSystem1._0.Models;
using BankSystem1._0.Repositories;
using System.Web.Mvc;
using System.Collections;

namespace BankSystem1._0.Tests
{
    [TestClass]
    public class TestBankServices
    {

        [TestMethod]
        public void ShouldLockAccount()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=600, ID=2, Locked=false}
            }).MustBeCalled();

            //Act
            var account = _repo.GetAll().First();
            BankServiceController controller = new BankServiceController();
            var result = controller.Lock(account);

            //Assert
            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void ShouldLockAccount()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=600, ID=2, Locked=false}
            }).MustBeCalled();

            //Act
            var account = _repo.GetAll().First();
            BankServiceController controller = new BankServiceController();
            var result = controller.Lock(account);
            //Assert

            Assert.AreEqual(true, result);

        }

        [TestMethod]
        public void ShouldFailToTransfer600FromAccountWithSufficientFundsToAnotherLockedAccount()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=600, ID=2, Locked=false},
                new Account {Balance=1200, ID=5, Locked=true}
            }).MustBeCalled();

            //Act
            var accounts = _repo.GetAll();
            BankServiceController controller = new BankServiceController();
            var result = controller.Transfer(accounts[0], accounts[1], 600);
            //Assert

            Assert.AreEqual(600, result[0].Balance);
            Assert.AreEqual(1200, result[1].Balance);

        }

        [TestMethod]
        public void ShouldSucceedToTransfer600FromAccountWithSufficientFundsToAnotherAccount()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=600, ID=2, Locked=false},
                new Account {Balance=1200, ID=5, Locked=false}
            }).MustBeCalled();

            //Act
            var accounts = _repo.GetAll();
            BankServiceController controller = new BankServiceController();
            var result = controller.Transfer(accounts[0], accounts[1], 600);
            //Assert

            Assert.AreEqual(0, result[0].Balance);
            Assert.AreEqual(1800, result[1].Balance);

        }

        [TestMethod]
        public void ShouldFailToTransfer600FromAccountWithInSufficientFundsToAnotherAccount()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=500, ID=2, Locked=false},
                new Account {Balance=1200, ID=5, Locked=false}
            }).MustBeCalled();

            //Act
            var accounts = _repo.GetAll();
            BankServiceController controller = new BankServiceController();
            var result = controller.Transfer(accounts[0], accounts[1], 600);
            //Assert

            Assert.AreEqual(500, result[0].Balance);
            Assert.AreEqual(1200, result[1].Balance);

        }

        [TestMethod]
        public void ShouldFailToAdd600ToLockedAccount()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=2500, ID=2, Locked=true}
            }).MustBeCalled();

            //Act
            Account account = _repo.GetAll().First();
            BankServiceController controller = new BankServiceController();
            var result = controller.Add(account, 600);

            //Assert
            Assert.AreEqual(2500, result);
        }

        [TestMethod]
        public void ShouldSucceedToAdd600ToAccount()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=2500, ID=2}
            }).MustBeCalled();

            //Act
            Account account = _repo.GetAll().First();
            BankServiceController controller = new BankServiceController();
            var result = controller.Add(account, 600);

            //Assert
            Assert.AreEqual(3100, result);
        }

        [TestMethod]
        public void ShouldFailToWithdraw600FromAccountWithInsufficientFunds()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=25, ID=2, Locked=false}
            }).MustBeCalled();

            //Act
            Account account = _repo.GetAll().First();
            BankServiceController controller = new BankServiceController();
            var result = controller.Withdraw(account, 600);

            //Assert
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void ShouldSucceedToWithdraw600FromAccountWithSufficientFunds()
        {
            //Arrange
            var _repo = Mock.Create<Repository>();
            Mock.Arrange(() => _repo.GetAll()).Returns(new List<Account> {
                new Account {Balance=2500, ID=2}
            }).MustBeCalled();

            //Act
            Account account = _repo.GetAll().First();
            BankServiceController controller = new BankServiceController();
            var result = controller.Withdraw(account, 600);

            //Assert
            Assert.AreEqual(1900, result);
        }
    }
}
