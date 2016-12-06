using BankSystem1._0.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BankSystem1._0.DataAccess
{
    public class BankContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
    }
}