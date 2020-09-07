<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewTransactions.aspx.cs" Inherits="PaymentsFrontEnd.ViewTransactions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="row">
        <div class="col-lg-7">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Filter Transactions <small>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></small></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>

                <div class="ibox-content">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlClient" runat="server" class="form-control" placeholder="Select Client" ></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:DropDownList ID="ddlTransactionType" runat="server" class="form-control" placeholder="Select Transaction Type" OnSelectedIndexChanged="ddlTransactionType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Select Transaction Type" Value="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="STK" Value="1"></asp:ListItem>
                            <asp:ListItem Text="C2B" Value="2"></asp:ListItem>
                            <asp:ListItem Text="B2C" Value="3"></asp:ListItem>
                            <asp:ListItem Text="B2B" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtStartDate" runat="server" class="form-control" placeholder="Start Date"></asp:TextBox>

                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtEndDate" runat="server" class="form-control" placeholder="End Date"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtPhoneNumber" runat="server" class="form-control" placeholder="Phone Number" OnTextChanged="txtPhoneNumber_TextChanged"></asp:TextBox>

                    </div>

                    <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-3">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" />
                            <asp:Button ID="btnSubmit" runat="server" Text="Search" class="btn btn-success" OnClick="btnSubmit_Click" />

                        </div>
                    </div>

                </div>
            </div>

        </div>


        <!-- Grid View to Display the Transactions -->
        <div class="col-lg-12">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>All Transactions in the System! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content">
                    <asp:GridView ID="gvTransactions" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" CellPadding="1" DataKeyNames="LNMCallBackId" CellSpacing="1" AutoGenerateColumns="False">

                        <Columns>

                            <asp:TemplateField HeaderText="PhoneNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ReceiptNo">
                                <ItemTemplate>
                                    <asp:Label ID="lblMpesaReceiptNumber" runat="server" Text='<%# Bind("MpesaReceiptNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Trxn Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblTransactionDate" runat="server" Text='<%# Bind("TransactionDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FirstName">
                                <ItemTemplate>
                                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LastName">
                                <ItemTemplate>
                                    <asp:Label ID="lblLastName" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>

                    </asp:GridView>

                </div>
            </div>
        </div>


    </div>
</asp:Content>
