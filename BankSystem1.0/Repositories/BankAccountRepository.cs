using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankSystem1._0.Models;
using Microsoft.AspNet.Identity;

namespace BankSystem1._0.Repositories
{
    public class BankaccountRepository : Repository
    {
        //used for account-related actions such as performing transactions, showing individual transactions?

        public Account Lock(Account account)
        {
            account.Locked = true;

            return account;
        }

        public List<Account> Transfer(Account sender, Account recipient, double amount)
        {
            if (!sender.Locked && !recipient.Locked)
            {
                if (sender.Balance - amount >= 0)
                {
                    sender.Balance -= amount;
                    recipient.Balance += amount;
                }
            }

            return new List<Account> { sender, recipient };
        }

        public double Withdraw(Account account, double amount)
        {

            return (account.Balance - amount >= 0 && !account.Locked) ? (account.Balance -= amount) : account.Balance;

            //if (account.Balance - amount >= 0 && !account.Locked)
            //    account.Balance -= amount;

            //return account.Balance;
        }

        public double Add(Account account, double amount)
        {
            //if (!account.Locked)
            //{
            //    account.Balance += amount;
            //}

            return !account.Locked ? (account.Balance += amount) : account.Balance;
        }

        public List<Account> GetAll()
        {
            //todo : Return All Users bankAccounts
            
            return null;
        }
    }
}