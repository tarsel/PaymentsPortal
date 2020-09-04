using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class LNMStkResponse
    {
        public long LNMCallBackId { get; set; }
        public string MerchantRequestID { get; set; }
        public string CheckoutRequestID { get; set; }
        public string ResultCode { get; set; }
        public string ResultDesc { get; set; }
        public long Amount { get; set; }
        public string MpesaReceiptNumber { get; set; }
        public long TransactionDate { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
    }
}