using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class TransactionTypes
    {
        public int transaction_type_id { get; set; }
        public string transaction_type_name { get; set; }
        public string friendly_name { get; set; }
        public int amount { get; set; }
    }
}