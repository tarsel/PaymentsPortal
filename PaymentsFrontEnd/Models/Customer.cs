using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class Customer
    {
        public int customer_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string msisdn { get; set; }
        public int id_type_id { get; set; }
        public string id_number { get; set; }
        public bool is_test_customer { get; set; }
        public int customer_type_id { get; set; }
        public int user_type_id { get; set; }
        public bool shared_msisdn { get; set; }
        public string user_name { get; set; }
        public bool fully_registered { get; set; }
        public int language_id { get; set; }
        public string email_address { get; set; }
        public int sub_county_id { get; set; }
        public int town_id { get; set; }
        public string registered_by_userName { get; set; }
    }
}