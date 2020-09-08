using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class DateRangeRequest
    {
        public string MSISDN { get; set; }
        public string ShortCode { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}