using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BankSystem1._0.Models
{
    public class AccountType
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public float Interest { get; set; }

        public List<User> UsersWithThisAccountType { get; set; }
    }
}
