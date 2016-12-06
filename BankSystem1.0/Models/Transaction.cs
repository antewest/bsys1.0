using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BankSystem1._0.Models
{
    public class Transaction
    {
        [Key]
        public int ID { get; set; }

        public DateTime TimeOfApproval { get; set; }

        [Required]
        public Account FromAccount { get; set; }
        [Required]
        public Account ToAccount { get; set; }

        public string Note { get; set; }
        public double Amount { get; set; }
    }
}
