using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class PurchaseOrder
    {
        public string particulars { get; set; }
        public string uniqueId { get; set; }
        public long quantity { get; set; }
        public decimal unitCost { get; set; }
        public long amount { get; set; }
        public string description { get; set; }
        public string order_type { get; set; }
        public string reference { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_number { get; set; }
        public decimal sub_total { get; set; }
    }

}