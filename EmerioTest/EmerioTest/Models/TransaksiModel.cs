using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmerioTest.Models
{
    public class TransaksiModel
    {
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public DateTime TransactionDate { get; set; }
        public String Description { get; set; }
        public String DebitCreditStatus { get; set; }
        public Decimal Amount { get; set; }

    }
}