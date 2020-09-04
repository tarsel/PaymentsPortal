using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class CustomerTypes
    {
        public int customer_type_id { get; set; }
        public string customer_type_name { get; set; }
        public string customer_type_description { get; set; }
        public DateTime date_created { get; set; }
        public string created_by { get; set; }
        public DateTime date_updated { get; set; }
        public string updated_by { get; set; }
    }
}