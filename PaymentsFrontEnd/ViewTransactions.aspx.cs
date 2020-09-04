using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PaymentsFrontEnd.Models;
using PaymentsFrontEnd.Response;

namespace PaymentsFrontEnd
{
    public partial class ViewTransactions : System.Web.UI.Page
    {
        // readonly string baseUrl = "http://197.248.0.20:7329/";
        readonly string baseUrl = "http://localhost:7329/";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ViewAllClients();
            }
        }


        protected void ddlTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientSetting clientSetting = GetClientSettingByClientId(long.Parse(ddlClient.SelectedValue));

            if (ddlTransactionType.Text == "STK")
            {
                ViewAllStkRequests();
            }
            else if (ddlTransactionType.Text == "C2B")
            {
                ViewAllC2BRequests();
            }

        }

        protected void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            string str = txtPhoneNumber.Text;
            string phoneNumber = "254" + str.Substring(str.Length - 9);


            ClientSetting clientSetting = GetClientSettingByClientId(long.Parse(ddlClient.SelectedValue));

            if (ddlTransactionType.Text == "STK")
            {
                ViewStkByMsidn(phoneNumber);
            }
            else if (ddlTransactionType.Text == "C2B")
            {
                GetC2BTransactionsByMsisdn(phoneNumber);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

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

                        gvTransactions.DataSource = lNMStkResponse;
                        gvTransactions.DataBind();
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

        public void ViewAllC2BRequests()
        {
            List<C2BQueryResponse> c2BQueryResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    var response = client.GetAsync("api/Mpesa/GetAllC2BTransactions").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        c2BQueryResponse = response.Content.ReadAsAsync<List<C2BQueryResponse>>().Result;

                        gvTransactions.DataSource = c2BQueryResponse;
                        gvTransactions.DataBind();
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

        public void GetC2BTransactionsByMsisdn(string msisdn)
        {
            List<C2BQueryResponse> c2BQueryResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    var response = client.GetAsync("api/Mpesa/GetC2BQueryByMsisdn").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        c2BQueryResponse = response.Content.ReadAsAsync<List<C2BQueryResponse>>().Result;

                        gvTransactions.DataSource = c2BQueryResponse;
                        gvTransactions.DataBind();
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
        public void ViewStkByMsidn(string msisdn)
        {
            List<LNMStkResponse> lNMStkResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    var response = client.GetAsync("api/Mpesa/GetStkRequestByMsisdn").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        lNMStkResponse = response.Content.ReadAsAsync<List<LNMStkResponse>>().Result;

                        gvTransactions.DataSource = lNMStkResponse;
                        gvTransactions.DataBind();
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
    }
}