using BankSystem1._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem1._0.Repositories
{
    public interface Repository
    {
        List<Account> GetAll();
    }
}
