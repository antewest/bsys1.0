using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankSystem1._0.Repositories;
using BankSystem1._0.Models;

namespace BankSystem1._0.Controllers
{
    public class BankServiceController : Controller
    {
        private BankaccountRepository _repo;

        public BankServiceController(BankaccountRepository repo)
        {
            _repo = repo;
        }

        public BankServiceController()
        {
            _repo = new BankaccountRepository();
        }

        public double Withdraw(Account account, double amount)
        {

            double result = _repo.Withdraw(account, amount);

            return result;

        }

        public ViewResult ViewAccounts()
        {
            return View();
        }

        public double Add(Account account, double p)
        {
            double result = _repo.Add(account, p);

            return result;
        }

        public List<Account> Transfer(Account sender, Account recipient, double amount)
        {
            var result = _repo.Transfer(sender, recipient, amount);

            return result;
        }

        public bool Lock(Account account)
        {
            _repo.Lock(account);

            return account.Locked;
        }
    }
}