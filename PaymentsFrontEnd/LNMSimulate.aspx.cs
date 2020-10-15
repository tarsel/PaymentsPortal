using PaymentsFrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaymentsFrontEnd
{
    public partial class LNMSimulate : System.Web.UI.Page
    {
        //readonly string baseUrl = "https://payments.airtouch.co.ke:7329/";
        readonly string baseUrl = "https://localhost.airtouch.co.ke:7329/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewAllClients();
                ViewAllStkRequests();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitLNMSimulation(txtShortCode.Text, txtAmount.Text, txtPhoneNumber.Text, txtAccountReference.Text, txtTransactionDesc.Text);
            ViewAllStkRequests();
            ClearFields();
            //  Response.Redirect("~/LNMSimulate.aspx", true);
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientSetting clientSetting = GetClientSettingByClientId(long.Parse(ddlClient.SelectedValue));

            txtShortCode.Text = clientSetting.C2B;
        }

        public ClientSetting GetClientSettingByClientId(long clientId)
        {
            ClientSetting client1 = new ClientSetting();
            try
            {
                using (var client = new HttpClient())
                {
                    Client cust = new Client { ClientId = clientId };

                    client.BaseAddress = new Uri(baseUrl);

                    var response = client.PostAsJsonAsync("api/Mpesa/GetClientSettingByClientId", cust).Result;

                    client1 = response.Content.ReadAsAsync<ClientSetting>().Result;

                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

            return client1;
        }

        public void ViewAllClients()
        {
            List<Client> clients;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    var response = client.GetAsync("api/Mpesa/GetAllClients").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        clients = response.Content.ReadAsAsync<List<Client>>().Result;

                        ddlClient.DataSource = clients;
                        ddlClient.DataTextField = "ClientName";
                        ddlClient.DataValueField = "ClientId";
                        ddlClient.DataBind();

                        ddlClient.Items.Insert(0, new ListItem("<--Select a Client -->", "0"));
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        public void ViewAllStkRequests()
        {
            List<LNMStkResponse> lNMStkResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    var response = client.GetAsync("api/Mpesa/GetAllStkRequests").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        lNMStkResponse = response.Content.ReadAsAsync<List<LNMStkResponse>>().Result;

                        gvDeposits.DataSource = lNMStkResponse;
                        gvDeposits.DataBind();
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        public void SubmitLNMSimulation(string businessShortCode, string amount, string phoneNumber, string accountReference, string transactionDesc)
        {
            using (var client = new HttpClient())
            {
                string msisdn = "254" + phoneNumber.Substring(phoneNumber.Length - 9);

                LipaNaMpesa cust = new LipaNaMpesa { AccountReference = accountReference, Amount = amount, BusinessShortCode = businessShortCode, PhoneNumber = msisdn, TransactionDesc = transactionDesc };

                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    var response = client.PostAsJsonAsync("api/Mpesa/LipaNaMpesa", cust).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.Text = "Kindly check your Phone for the STK Payment!";

                        ViewAllClients();
                    }
                    else
                        lblMessage.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
        }

        public void ClearFields()
        {
            txtTransactionDesc.Text = "";
            txtShortCode.Text = "";
            txtPhoneNumber.Text = "";
            txtAmount.Text = "";
            txtAccountReference.Text = "";
            ddlClient.SelectedItem.Text = "";
        }


    }
}