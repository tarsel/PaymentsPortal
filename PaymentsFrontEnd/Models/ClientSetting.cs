using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class ClientSetting
    {
        public long ClientSettingId { get; set; }
        public long ClientId { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string PassKey { get; set; }
        public string C2B { get; set; }
        public string B2C { get; set; }
    }
}