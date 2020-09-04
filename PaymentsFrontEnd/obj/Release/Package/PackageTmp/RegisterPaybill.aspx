<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RegisterPaybill.aspx.cs" Inherits="PaymentsFrontEnd.RegisterPaybill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- page content -->
   <%-- <div class="row">
        <div class="col-lg-7">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Create Client <small>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></small></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>

                <div class="ibox-content">
                    <div class="row">
                        <div class="col-sm-6">

                            <div class="form-group">
                                <asp:TextBox ID="txtShortCode" runat="server" class="form-control" placeholder="Short Code" CausesValidation="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtResponseType" runat="server" class="form-control" placeholder="Response Type" CausesValidation="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtConfirmationURL" runat="server" class="form-control" placeholder="Confirmation URL" CausesValidation="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtValidationURL" runat="server" class="form-control" placeholder="ValidationURL" CausesValidation="true"></asp:TextBox>
                            </div>

                            <div class="form-group row">
                                <div class="col-md-9 col-sm-9  offset-md-3">
                                    <asp:Button ID="btnCancelClient" runat="server" Text="Cancel" class="btn btn-primary" OnClick="" CausesValidation="false" />
                                    <asp:Button ID="btnCreateClient" runat="server" Text="Submit" class="btn btn-success" OnClick="" />

                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>

        <div class="col-lg-5">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Create Client Set Up</h5>
                    <small>
                        <asp:Label ID="lblMessage1" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></small>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>


                <div class="ibox-content">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlClient" runat="server" class="form-control" placeholder="Select Client"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtConsumerKey" runat="server" class="form-control" placeholder="Consumer Key" CausesValidation="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtConsumerSecret" runat="server" class="form-control" placeholder="Consumer Secret" CausesValidation="true"></asp:TextBox>

                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtPasskey" runat="server" class="form-control" placeholder="Passkey" CausesValidation="true"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtC2B" runat="server" class="form-control" placeholder="C2B Paybill Number" CausesValidation="true"></asp:TextBox>

                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtB2C" runat="server" class="form-control" placeholder="B2C Paybill Number" CausesValidation="true"></asp:TextBox>

                    </div>


                    <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-3">

                            <asp:Button ID="btnCancelClientSetup" runat="server" Text="Cancel" class="btn btn-primary" OnClick="btnCancelClientSetup_Click" />

                            <asp:Button ID="btnCreateClientSetup" runat="server" Text="Generate" class="btn btn-success" OnClick="btnCreateClientSetup_Click" />

                        </div>
                    </div>

                </div>
            </div>

        </div>



        <div class="col-lg-6">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>All Client's in the System! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content" style="overflow: scroll;">
                    <asp:GridView ID="gvClient" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" DataKeyNames="ClientId" AutoGenerateColumns="False" OnRowCancelingEdit="gvClient_RowCancelingEdit" OnRowEditing="gvClient_RowEditing" OnPageIndexChanging="gvClient_PageIndexChanging" OnRowUpdating="gvClient_RowUpdating">
                        <Columns>

                            <asp:TemplateField HeaderText="Client Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblClientName" runat="server" Text='<%# Bind("ClientName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Phone Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Address">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditAddress" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Operations">

                                <EditItemTemplate>
                                    <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Update" class="btn btn-primary" UseSubmitBehavior="false" />
                                    <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" class="btn btn-primary" UseSubmitBehavior="false" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" class="btn btn-primary" Height="25px" UseSubmitBehavior="false" />

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>
            </div>
        </div>



        <div class="col-lg-6">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>All Client Setting's in the System! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content" style="overflow: scroll;">
                    <asp:GridView ID="gvClientSetup" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" DataKeyNames="ClientSettingId" AutoGenerateColumns="False" OnRowCancelingEdit="gvClientSetup_RowCancelingEdit" OnRowEditing="gvClientSetup_RowEditing" OnRowDataBound="gvClientSetup_RowDataBound" OnPageIndexChanging="gvClientSetup_PageIndexChanging" OnRowUpdating="gvClientSetup_RowUpdating">
                        <Columns>

                            <asp:TemplateField HeaderText="Client Name">
                                <EditItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("ClientId") %>' Visible="false">        </asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlClientGrid"></asp:DropDownList>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblClientName1" runat="server" Text='<%# Bind("ClientId") %>' Visible="false">        </asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlClientGrid1" Enabled="false"></asp:DropDownList>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Consumer Key">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditConsumerKey" runat="server" Text='<%# Bind("ConsumerKey") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblConsumerKey" runat="server" Text='<%# Bind("ConsumerKey") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Consumer Secret">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditConsumerSecret" runat="server" Text='<%# Bind("ConsumerSecret") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblConsumerSecret" runat="server" Text='<%# Bind("ConsumerSecret") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PassKey">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditPassKey" runat="server" Text='<%# Bind("PassKey") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPassKey" runat="server" Text='<%# Bind("PassKey") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="C2B">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditC2B" runat="server" Text='<%# Bind("C2B") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblC2B" runat="server" Text='<%# Bind("C2B") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="B2C">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditB2C" runat="server" Text='<%# Bind("B2C") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblB2C" runat="server" Text='<%# Bind("B2C") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Operations">

                                <EditItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CommandName="Update" Text="Update" class="btn btn-primary" UseSubmitBehavior="false" />
                                    <asp:Button ID="Button2" runat="server" CommandName="Cancel" Text="Cancel" class="btn btn-primary" UseSubmitBehavior="false" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Button ID="Button3" runat="server" CommandName="Edit" Text="Edit" class="btn btn-primary" Height="25px" UseSubmitBehavior="false" />

                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>
            </div>
        </div>


    </div>--%>

</asp:Content>
