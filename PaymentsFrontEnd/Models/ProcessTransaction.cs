using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class ProcessTransaction
    {
        public string ipn_type { get; set; }
        public string transaction_tracking_id { get; set; }
        public string merchant_ref { get; set; }
    }

}