using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using PaymentsFrontEnd.Models;
using PaymentsFrontEnd.Response;

using Pesapal.APIHelper;

namespace PaymentsFrontEnd
{
    public partial class AirtimePurchase : System.Web.UI.Page
    {
        readonly string baseUrl = "https://localhost.airtouch.co.ke:7329/";
        //string baseUrl = "https://payments.airtouch.co.ke:7329/";
        static string testPaymentUrl = "https://demo.pesapal.com/API/PostPesapalDirectOrderV4";
        static string livePaymentUrl = "https://www.pesapal.com/API/PostPesapalDirectOrderV4";

        static string testProcessPaymentUrl = "https://demo.pesapal.com/api/querypaymentstatus";
        static string liveProcessPaymentUrl = "https://www.pesapal.com/api/querypaymentstatus";

        static string consumerKeyTest = "frpUvtajFr3bSoIksv1hErZrLXAmNWW3";
        static string consumerSecretTest = "s1fVUmD9BlfCsHScT9ZMXI0cLyY=";

        static string consumerKeyLive = "iLKaubC71MjsPSL8KuquVmhPsjUwTFOp";
        static string consumerSecretLive = "njghQdK1IVIGs5yr9zBhrGKpXZI=";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                pnlAirtimePurchase.Visible = false;

                var ipnType = Request["pesapal_notification_type"];
                var transactionTrackingId = Request["pesapal_transaction_tracking_id"];
                var merchantRef = Request["pesapal_merchant_reference"];

                if (transactionTrackingId != null)
                {
                    ProcessTransaction(merchantRef, transactionTrackingId);

                    if (UpdateIpnTransactionStatus(ipnType, transactionTrackingId, merchantRef))
                    {
                        Response.ClearContent();
                        Response.Write(string.Format("pesapal_notification_type={0}&pesapal_transaction_tracking_id={1}&pesapal_merchant_reference={2}", ipnType, transactionTrackingId, merchantRef));
                    }

                    lblMessage.Text = "Airtime Purchase Successfull";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pnlAirtimePurchase.Visible = true;
            pnlAirtimeRequest.Visible = false;
        }

        protected string GetPesapalUrl()
        {
            Uri pesapalPostUri = new Uri(livePaymentUrl);

            Uri pesapalCallBackUri = new Uri("http://197.248.0.20:7330/AirtimePurchase.aspx");/* link to the page on your site users will be redirected to when the payment process has been completed */

            // Setup builder
            IBuilder builder = new APIPostParametersBuilderV2()
                    .ConsumerKey(consumerKeyLive)
                    .ConsumerSecret(consumerSecretLive)
                    .OAuthVersion(EOAuthVersion.VERSION1)
                    .SignatureMethod(ESignatureMethod.HMACSHA1)
                    .SimplePostHttpMethod(EHttpMethod.GET)
                    .SimplePostBaseUri(pesapalPostUri)
                    .OAuthCallBackUri(pesapalCallBackUri);

            // Initialize API helper
            APIHelper<IBuilder> helper = new APIHelper<IBuilder>(builder);

            // Populate line items
            var lineItems = new List<LineItem> { };

            // For each item purchased, add a lineItem.
            // For example, if the user purchased 3 of Item A, add a line item as follows:
            var lineItem = new LineItem
            {
                Particulars = "Airtime"/* description of the item, example: Item A */,
                UniqueId = Guid.NewGuid().ToString() /* some unique id for the item */,
                Quantity = 1 /* quantity (number of items) purchased, example: 3 */,
                UnitCost = long.Parse(txtAmount.Text) /* cost of the item (for 1 item) */
            };

            lineItem.SubTotal = (lineItem.Quantity * lineItem.UnitCost);

            lineItems.Add(lineItem);

            // Do the same for additional items purchased
            string str = txtPhoneNo.Text;
            string phoneNumber = "0" + str.Substring(str.Length - 9);
            // Compose the order
            PesapalDirectOrderInfo webOrder = new PesapalDirectOrderInfo()
            {
                Amount = (lineItems.Sum(x => x.SubTotal)).ToString(),
                Description = "Voip Purchase", /* [required] description of the purchase */
                Type = "MERCHANT",
                Reference = Guid.NewGuid().ToString().Replace("-", "").Trim(),/* [required] a unique id, example: an order number */
                Email = "michaelosimbo@gmail.com",/* [either email or phone number is required] email address of the user making the purchase */
                FirstName = "",/* [optional] user’s first name */
                LastName = "",/* [optional] user’s last name */
                PhoneNumber = phoneNumber, /* [either email or phone number is required] user’s phone number */
                LineItems = lineItems
            };

            SaveOrder(lineItem.Particulars, lineItem.UniqueId, lineItem.Quantity, lineItem.UnitCost, long.Parse(webOrder.Amount), webOrder.Description, webOrder.Type, webOrder.Reference, webOrder.Email, webOrder.FirstName, webOrder.LastName, webOrder.PhoneNumber, lineItem.SubTotal);

            // Post the order to PesaPal, which upon successful verification,
            // will return the string containing the url to load in the iframe
            return helper.PostGetPesapalDirectOrderUrl(webOrder);
        }


        public bool SaveOrder(string particulars, string uniqueId, long quantity, decimal unitCost, long amount, string description, string orderType, string reference, string email, string firstName, string lastName, string phoneNumber, decimal subTotal)
        {
            GenericResponse genericResponse = null;

            using (var client = new HttpClient())
            {
                PurchaseOrder cust = new PurchaseOrder { amount = amount, description = description, email = email, first_name = firstName, last_name = lastName, order_type = orderType, particulars = particulars, phone_number = phoneNumber, quantity = quantity, reference = reference, sub_total = subTotal, uniqueId = uniqueId, unitCost = unitCost };

                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    var response = client.PostAsJsonAsync("api/PesaPal/MakeOrder", cust).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        genericResponse = response.Content.ReadAsAsync<GenericResponse>().Result;

                        lblMessage.Text = "Order Created Successfully!";

                    }
                    else
                        lblMessage.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            return genericResponse.is_successful;
        }


        public bool ProcessTransaction(string reference, string trackingId)
        {
            GenericResponse genericResponse = null;

            using (var client = new HttpClient())
            {
                ProcessTransaction cust = new ProcessTransaction { merchant_ref = reference, transaction_tracking_id = trackingId };

                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    var response = client.PostAsJsonAsync("api/PesaPal/ProcessTransaction", cust).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        genericResponse = response.Content.ReadAsAsync<GenericResponse>().Result;

                        lblMessage.Text = "Transaction Created Successfully!";

                    }
                    else
                        lblMessage.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }

            return genericResponse.is_successful;
        }

        public bool UpdateIpnTransactionStatus(string ipnType, string transactionTrackingId, string merchantRef)
        {
            GenericResponse genericResponse = null;

            using (var client = new HttpClient())
            {
                ProcessTransaction cust = new ProcessTransaction { merchant_ref = merchantRef, transaction_tracking_id = transactionTrackingId, ipn_type = ipnType };

                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    var response = client.PostAsJsonAsync("api/PesaPal/UpdateIpnTransactionStatus", cust).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        genericResponse = response.Content.ReadAsAsync<GenericResponse>().Result;

                        lblMessage.Text = "Transaction Status Created Successfully!";

                    }
                    else
                        lblMessage.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }

            return genericResponse.is_successful;
        }

    }
}