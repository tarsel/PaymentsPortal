<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="LNMSimulate.aspx.cs" Inherits="PaymentsFrontEnd.LNMSimulate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- page content -->
    <div class="row">
        <div class="col-lg-7">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Perform STK Simulation (C2B Deposit) <small>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></small></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>

                <div class="ibox-content">
                     <div class="form-group">
                        <asp:DropDownList ID="ddlClient" runat="server" class="form-control" placeholder="Select Client" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtShortCode" runat="server" class="form-control" placeholder="ShortCode" ReadOnly="true" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtAmount" runat="server" class="form-control" placeholder="Amount" ></asp:TextBox>

                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtPhoneNumber" runat="server" class="form-control" placeholder="Phone Number" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtAccountReference" runat="server" class="form-control" placeholder="Account Reference" ></asp:TextBox>

                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtTransactionDesc" runat="server" class="form-control" placeholder="Transaction Description" ></asp:TextBox>

                    </div>

                    <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-3">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" />
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-success" OnClick="btnSubmit_Click" />

                        </div>
                    </div>

                </div>
            </div>

        </div>


        <!-- Grid View to Display the Transactions -->
        <div class="col-lg-12">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>All Deposits in the System! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content">
                    <asp:GridView ID="gvDeposits" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" CellPadding="1" DataKeyNames="LNMCallBackId" CellSpacing="1" AutoGenerateColumns="False" >

                        <Columns>

                            <asp:TemplateField HeaderText="Phone Number">
                          
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNumber" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="MpesaReceiptNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblMpesaReceiptNumber" runat="server" Text='<%# Bind("MpesaReceiptNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Transaction Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblTransactionDate" runat="server" Text='<%# Bind("TransactionDate") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>  

                            <asp:TemplateField HeaderText="Result Desc">
                                <ItemTemplate>
                                    <asp:Label ID="lblResultDesc" runat="server" Text='<%# Bind("ResultDesc") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>                         

                        </Columns>

                    </asp:GridView>

                </div>
            </div>
        </div>


    </div>
</asp:Content>
