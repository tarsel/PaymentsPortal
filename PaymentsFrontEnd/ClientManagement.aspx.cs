using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PaymentsFrontEnd.Models;

namespace PaymentsFrontEnd
{
    public partial class ClientManagement : System.Web.UI.Page
    {
        //readonly string baseUrl = "https://payments.airtouch.co.ke:7329/";
        readonly string baseUrl = "https://localhost.airtouch.co.ke:7329/";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllClients();
                GetAllClientSettings();
                ViewAllClients();
            }
        }

        protected void btnCancelClient_Click(object sender, EventArgs e)
        {
            ClearClient();
        }

        protected void btnCreateClient_Click(object sender, EventArgs e)
        {
            CreateNewClient();
            GetAllClients();
            ClearClient();
        }

        protected void btnCancelClientSetup_Click(object sender, EventArgs e)
        {
            ClearClientSetting();
        }

        protected void btnCreateClientSetup_Click(object sender, EventArgs e)
        {
            CreateNewClientSetting();
            GetAllClientSettings();
            ClearClientSetting();
        }

        protected void gvClient_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClient.EditIndex = -1;
            GetAllClients();
        }

        protected void gvClient_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClient.EditIndex = e.NewEditIndex;
            GetAllClients();
        }

        protected void gvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClient.PageIndex = e.NewPageIndex;
            GetAllClients();
        }

        protected void gvClient_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //var user = authenticationManager.User.Identity.Name;

            TextBox txtEditClientName = gvClient.Rows[e.RowIndex].FindControl("txtEditClientName") as TextBox;
            TextBox txtEditPhoneNumber = gvClient.Rows[e.RowIndex].FindControl("txtEditPhoneNumber") as TextBox;
            TextBox txtEditEmail = gvClient.Rows[e.RowIndex].FindControl("txtEditEmail") as TextBox;
            TextBox txtEditAddress = gvClient.Rows[e.RowIndex].FindControl("txtEditAddress") as TextBox;

            long clientId = Convert.ToInt16(gvClient.DataKeys[e.RowIndex].Values["ClientId"].ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                Client cust = new Client { ClientId = clientId, ClientName = txtEditClientName.Text, PhoneNumber = txtEditPhoneNumber.Text, Address = txtEditAddress.Text, Email = txtEditEmail.Text };

                try
                {
                    var response = client.PostAsJsonAsync("api/Mpesa/UpdateClient", cust).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.Text = "The Client: (" + txtEditClientName.Text + ") has been Updated Successfully!";
                    }
                    else
                        lblMessage.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }

            gvClient.EditIndex = -1;
            GetAllClients();

        }

        protected void gvClientSetup_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvClientSetup.EditIndex = -1;
            GetAllClientSettings();
        }

        protected void gvClientSetup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvClientSetup.EditIndex = e.NewEditIndex;
            GetAllClientSettings();
        }

        protected void gvClientSetup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                List<Client> clients;


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);

                    try
                    {
                        var customerTypeResponse = client.GetAsync("api/Mpesa/GetAllClients").Result;
                        if (customerTypeResponse.IsSuccessStatusCode)
                        {
                            clients = customerTypeResponse.Content.ReadAsAsync<List<Client>>().Result;

                            //check if is in edit mode
                            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                            {
                                DropDownList ddlClientGrid = (DropDownList)e.Row.FindControl("ddlClientGrid");
                                //Bind subcategories data to dropdownlist
                                ddlClientGrid.DataSource = clients;
                                ddlClientGrid.DataTextField = "ClientName";
                                ddlClientGrid.DataValueField = "ClientId";
                                ddlClientGrid.DataBind();

                                ddlClientGrid.Items.Insert(0, new ListItem("<-- Select Client -->", "0"));

                                //Select the Sub County of Customer in DropDownList
                                string lblClientName = (e.Row.FindControl("lblClientName") as Label).Text;
                                ddlClientGrid.Items.FindByValue(lblClientName).Selected = true;
                            }
                            else
                            {
                                DropDownList ddlClientGrid1 = (e.Row.FindControl("ddlClientGrid1") as DropDownList);

                                ddlClientGrid1.DataSource = clients;
                                ddlClientGrid1.DataTextField = "ClientName";
                                ddlClientGrid1.DataValueField = "ClientId";
                                ddlClientGrid1.DataBind();

                                ddlClientGrid1.Items.Insert(0, new ListItem("<--Select Client -->", "0"));

                                //Select the Sub County of Customer in DropDownList
                                string lblClientName1 = (e.Row.FindControl("lblClientName1") as Label).Text;
                                ddlClientGrid1.Items.FindByValue(lblClientName1).Selected = true;
                            }
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

        protected void gvClientSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClient.PageIndex = e.NewPageIndex;
            GetAllClientSettings();
        }

        protected void gvClientSetup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //var user = authenticationManager.User.Identity.Name;

            TextBox txtEditConsumerKey = gvClientSetup.Rows[e.RowIndex].FindControl("txtEditConsumerKey") as TextBox;
            TextBox txtEditConsumerSecret = gvClientSetup.Rows[e.RowIndex].FindControl("txtEditConsumerSecret") as TextBox;
            TextBox txtEditPassKey = gvClientSetup.Rows[e.RowIndex].FindControl("txtEditPassKey") as TextBox;
            TextBox txtEditC2B = gvClientSetup.Rows[e.RowIndex].FindControl("txtEditC2B") as TextBox;
            TextBox txtEditB2C = gvClientSetup.Rows[e.RowIndex].FindControl("txtEditB2C") as TextBox;
            DropDownList ddlClientGrid = gvClientSetup.Rows[e.RowIndex].FindControl("ddlClientGrid") as DropDownList;

            long clientSettingId = Convert.ToInt16(gvClientSetup.DataKeys[e.RowIndex].Values["ClientSettingId"].ToString());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                ClientSetting cust = new ClientSetting { ClientId = long.Parse(ddlClientGrid.SelectedValue), B2C = txtEditB2C.Text, C2B = txtEditC2B.Text, ClientSettingId = clientSettingId, ConsumerKey = txtEditConsumerKey.Text, ConsumerSecret = txtEditConsumerSecret.Text, PassKey = txtEditPassKey.Text };

                try
                {
                    var response = client.PostAsJsonAsync("api/Mpesa/UpdateClientSetting", cust).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage1.Text = "The Client Set Up has been Updated Successfully!";
                    }
                    else
                        lblMessage1.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage1.Text = ex.Message;
                }
            }

            gvClientSetup.EditIndex = -1;
            GetAllClientSettings();
        }

        public void GetAllClients()
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

                        gvClient.DataSource = clients;
                        gvClient.DataBind();
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

        public void GetAllClientSettings()
        {
            List<ClientSetting> clientSetting;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);

                try
                {
                    var response = client.GetAsync("api/Mpesa/GetAllClientSettings").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        clientSetting = response.Content.ReadAsAsync<List<ClientSetting>>().Result;

                        gvClientSetup.DataSource = clientSetting;
                        gvClientSetup.DataBind();
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

        public void CreateNewClient()
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || txtEmail.Text == null) { lblMessage.Text = "Email is Empty!"; }
            else if (string.IsNullOrEmpty(txtAddress.Text) || txtAddress.Text == null) { lblMessage.Text = "Address is Empty!"; }
            else if (string.IsNullOrEmpty(txtClientName.Text) || txtClientName.Text == null) { lblMessage.Text = "Client Name is Empty!"; }
            else if (string.IsNullOrEmpty(txtPhoneNumber.Text) || txtPhoneNumber.Text == null) { lblMessage.Text = "Phone Number is Empty!"; }
            else
            {
                using (var client = new HttpClient())
                {
                    Client client1 = new Client { Address = txtAddress.Text, ClientName = txtClientName.Text, Email = txtEmail.Text, PhoneNumber = txtPhoneNumber.Text };

                    client.BaseAddress = new Uri(baseUrl);

                    try
                    {
                        bool result = GetClientByPhoneNumber(txtPhoneNumber.Text);

                        if (result == false)
                        {
                            var response = client.PostAsJsonAsync("api/Mpesa/SaveClient", client1).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                lblMessage.Text = "Client Created Successfully!";
                            }
                            else
                                lblMessage.Text = "";
                        }
                        else
                        {
                            lblMessage.Text = "The Client with Phone Number: (" + txtPhoneNumber.Text + ") Already Exists!";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblMessage.Text = ex.Message;
                    }
                }
            }
        }

        public void CreateNewClientSetting()
        {
            if (ddlClient.SelectedIndex == 0)
            {
                lblMessage.Text = "Kindly select the drop down list!";
            }
            else if (string.IsNullOrEmpty(txtC2B.Text) || txtC2B.Text == null) { lblMessage.Text = "C2B is Empty!"; }
            else if (string.IsNullOrEmpty(txtConsumerKey.Text) || txtConsumerKey.Text == null) { lblMessage.Text = "Consumer Key is Empty!"; }
            else if (string.IsNullOrEmpty(txtConsumerSecret.Text) || txtConsumerSecret.Text == null) { lblMessage.Text = "Consumer Secret  is Empty!"; }
            else if (string.IsNullOrEmpty(txtPasskey.Text) || txtPasskey.Text == null) { lblMessage.Text = "Passkey is Empty!"; }
            else
            {
                using (var client = new HttpClient())
                {
                    ClientSetting clientSetting = new ClientSetting { B2C = txtB2C.Text, C2B = txtC2B.Text, ConsumerKey = txtConsumerKey.Text, ConsumerSecret = txtConsumerSecret.Text, PassKey = txtPasskey.Text, ClientId = int.Parse(ddlClient.SelectedValue) };

                    client.BaseAddress = new Uri(baseUrl);

                    try
                    {
                        var response = client.PostAsJsonAsync("api/Mpesa/SaveClientSetting", clientSetting).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            lblMessage.Text = "Client Created Successfully!";
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
        }

        public bool GetClientByPhoneNumber(string phoneNumber)
        {
            bool result = false;
            Client client1;
            try
            {
                using (var client = new HttpClient())
                {
                    LipaNaMpesa cust = new LipaNaMpesa { PhoneNumber = phoneNumber };

                    client.BaseAddress = new Uri(baseUrl);

                    var response = client.PostAsJsonAsync("api/Mpesa/GetClientByPhoneNumber", cust).Result;

                    client1 = response.Content.ReadAsAsync<Client>().Result;

                    if (client1 != null)
                    {
                        lblMessage.Text = "Client Exists!";

                        result = true;
                    }
                    else
                        result = false;
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }

            return result;
        }

        public void ClearClient()
        {
            txtAddress.Text = "";
            txtClientName.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
        }

        public void ClearClientSetting()
        {
            txtPasskey.Text = "";
            txtConsumerSecret.Text = "";
            txtConsumerKey.Text = "";
            txtC2B.Text = "";
            txtB2C.Text = "";
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

    }
}