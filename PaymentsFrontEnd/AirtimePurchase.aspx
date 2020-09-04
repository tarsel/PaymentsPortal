<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AirtimePurchase.aspx.cs" Inherits="PaymentsFrontEnd.AirtimePurchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlAirtimeRequest" runat="server">
        
    <!-- page content -->
    <div class="row">
        <div class="col-lg-7">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Buy Airtime Here <small>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></small></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>

                <div class="ibox-content">
                    <div class="form-group">
                        <asp:TextBox ID="txtPhoneNo" runat="server" class="form-control" placeholder="Phone Number"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtAmount" runat="server" class="form-control" placeholder="Amount"></asp:TextBox>

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
    </div>
    </asp:Panel>

    <asp:Panel ID="pnlAirtimePurchase" runat="server">
        <iframe src="<%=GetPesapalUrl()%>" width="100%" height="620px" frameborder="0" scrolling="auto" />
    </asp:Panel>

    <asp:Panel ID="pnlProcessPayment" runat="server" Visible="false">


    </asp:Panel>

</asp:Content>
