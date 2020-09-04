using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class GenericRequest
    {
        public int msisdn { get; set; }
        public string id_number { get; set; }
        public int transaction_type_id { get; set; }
        public int ward_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
    }
}