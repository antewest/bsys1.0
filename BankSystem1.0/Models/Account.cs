using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankSystem1._0.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public AccountType Type { get; set; }

        [Required]
        public User Owner { get; set; }

        public DateTime CreationDate { get; set; }
        public double Amount { get; set; }

        public bool Locked { get; set; }
        public DateTime UnlockDate {get;set;}

        public List<Transaction> Transactions { get; set; }

    }
}