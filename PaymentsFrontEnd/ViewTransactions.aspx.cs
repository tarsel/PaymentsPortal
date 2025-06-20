﻿using System;
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
        //readonly string baseUrl = "https://payments.airtouch.co.ke:7329/";
        readonly string baseUrl = "https://localhost.airtouch.co.ke:7329/";

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

            if (ddlTransactionType.SelectedItem.Text == "STK")
            {
                ViewAllStkRequests();
            }
            else if (ddlTransactionType.SelectedItem.Text == "C2B")
            {
                GetC2BTransactionsByShortCode(clientSetting.C2B);
            }

            txtPhoneNumber.Enabled = true;
        }

        protected void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            string str = txtPhoneNumber.Text;
            string phoneNumber = "254" + str.Substring(str.Length - 9);


            ClientSetting clientSetting = GetClientSettingByClientId(long.Parse(ddlClient.SelectedValue));

            if (ddlTransactionType.SelectedItem.Text == "STK")
            {
                ViewStkByMsidn(phoneNumber);
            }
            else if (ddlTransactionType.SelectedItem.Text == "C2B")
            {
                GetC2BTransactionsByMsisdnAndShortCode(phoneNumber, clientSetting.C2B);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string str = txtPhoneNumber.Text;
            string phoneNumber = "254" + str.Substring(str.Length - 9);
            string startDate = DateTime.Parse(txtStartDate.Text).ToString("yyyyMMddHHmmss");
            string endDate = DateTime.Parse(txtEndDate.Text).ToString("yyyyMMddHHmmss");

            ClientSetting clientSetting = GetClientSettingByClientId(long.Parse(ddlClient.SelectedValue));

            if (ddlTransactionType.SelectedItem.Text == "C2B")
            {
                GetC2BTransactionsByMsisdnShortCodeAndDate(phoneNumber, clientSetting.C2B, startDate, endDate);
            }
            else if (ddlTransactionType.SelectedItem.Text == "STK")
            {
                ViewStkByMsidnAndDate(phoneNumber, startDate, endDate);
            }
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

                        gvStk.DataSource = lNMStkResponse;
                        gvStk.DataBind();
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            gvC2B.Visible = false;
            gvStk.Visible = true;
        }

        public void GetC2BTransactionsByMsisdnShortCodeAndDate(string msisdn, string shortCode, string startDate, string endDate)
        {
            List<C2BQueryResponse> c2BQueryResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    DateRangeRequest lipaNaMpesa = new DateRangeRequest { ShortCode = shortCode, MSISDN = msisdn, EndDate = endDate, StartDate = startDate };

                    client.BaseAddress = new Uri(baseUrl);

                    var response = client.PostAsJsonAsync("api/Mpesa/GetC2BQueryByMsisdnAndCode", lipaNaMpesa).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        c2BQueryResponse = response.Content.ReadAsAsync<List<C2BQueryResponse>>().Result;

                        gvC2B.DataSource = c2BQueryResponse;
                        gvC2B.DataBind();
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            gvC2B.Visible = true;
            gvStk.Visible = false;
        }

        public void GetC2BTransactionsByMsisdnAndShortCode(string msisdn, string shortCode)
        {
            List<C2BQueryResponse> c2BQueryResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    LipaNaMpesa lipaNaMpesa = new LipaNaMpesa { BusinessShortCode = shortCode, PhoneNumber = msisdn };

                    client.BaseAddress = new Uri(baseUrl);

                    var response = client.PostAsJsonAsync("api/Mpesa/GetC2BQueryByMsisdnAndCode", lipaNaMpesa).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        c2BQueryResponse = response.Content.ReadAsAsync<List<C2BQueryResponse>>().Result;

                        gvC2B.DataSource = c2BQueryResponse;
                        gvC2B.DataBind();
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            gvC2B.Visible = true;
            gvStk.Visible = false;
        }


        public void GetC2BTransactionsByShortCode(string shortCode)
        {
            List<C2BQueryResponse> c2BQueryResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    LipaNaMpesa lipaNaMpesa = new LipaNaMpesa { BusinessShortCode = shortCode };

                    client.BaseAddress = new Uri(baseUrl);

                    var response = client.PostAsJsonAsync("api/Mpesa/GetC2BQueryByShortCode", lipaNaMpesa).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        c2BQueryResponse = response.Content.ReadAsAsync<List<C2BQueryResponse>>().Result;

                        gvC2B.DataSource = c2BQueryResponse;
                        gvC2B.DataBind();
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            gvStk.Visible = false;
            gvC2B.Visible = true;
        }

        public void ViewStkByMsidn(string msisdn)
        {
            List<LNMStkResponse> lNMStkResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {

                    LipaNaMpesa lipaNaMpesa = new LipaNaMpesa { PhoneNumber = msisdn };

                    client.BaseAddress = new Uri(baseUrl);

                    var response = client.PostAsJsonAsync("api/Mpesa/GetStkRequestByMsisdn", lipaNaMpesa).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        lNMStkResponse = response.Content.ReadAsAsync<List<LNMStkResponse>>().Result;

                        gvStk.DataSource = lNMStkResponse;
                        gvStk.DataBind();
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            gvStk.Visible = true;
            gvC2B.Visible = false;
        }


        public void ViewStkByMsidnAndDate(string msisdn, string startDate, string endDate)
        {
            List<LNMStkResponse> lNMStkResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                try
                {
                    DateRangeRequest lipaNaMpesa = new DateRangeRequest { StartDate = startDate, EndDate = endDate, MSISDN = msisdn };

                    client.BaseAddress = new Uri(baseUrl);

                    var response = client.PostAsJsonAsync("api/Mpesa/GetStkRequestByMsisdnAndDate", lipaNaMpesa).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        lNMStkResponse = response.Content.ReadAsAsync<List<LNMStkResponse>>().Result;

                        gvStk.DataSource = lNMStkResponse;
                        gvStk.DataBind();
                    }
                    else
                        lblMessage.Text = "System cannot fetch data.";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            gvStk.Visible = true;
            gvC2B.Visible = false;
        }

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTransactionType.Enabled = true;
        }
    }
}