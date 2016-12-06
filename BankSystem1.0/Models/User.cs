using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankSystem1._0.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        public ApplicationUser AppUser { get; set; }
        [Required]
        public List<Account> UserAccounts { get; set; }

        public List<Transaction> UserTransactions { get; set; }
        public List<string> UserSavedAccountNumbers { get; set; }

        public DateTime CreationDate { get; set; }
    }
}