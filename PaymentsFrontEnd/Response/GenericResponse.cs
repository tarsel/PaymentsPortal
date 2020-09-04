using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Response
{
    public class GenericResponse
    {
        public bool is_successful { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }
    }

}