using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class UserTypes
    {
        public int user_type_id { get; set; }
        public string user_type_name { get; set; }
        public string user_type_description { get; set; }
        public DateTime date_created { get; set; }
        public string created_by { get; set; }
        public DateTime date_updated { get; set; }
        public string updated_by { get; set; }
    }
}