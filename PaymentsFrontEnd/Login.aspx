<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PaymentsFrontEnd.Login1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:PlaceHolder runat="server" ID="LoginStatus" Visible="false">
        <p>
            <asp:Literal runat="server" ID="StatusText" />
            <asp:Label ID="lblLoginError" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>

        </p>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server" ID="LoginForm" Visible="false">
        <div class="form-group">
            <asp:TextBox runat="server" ID="UserName" class="form-control" placeholder="Username" required="" />
        </div>

        <div class="form-group">
            <asp:TextBox runat="server" ID="Password" TextMode="Password" class="form-control" placeholder="Password" required="" />
        </div>

        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary block full-width m-b" Text="Log In" BorderStyle="Solid" OnClick="SignIn" />

        <a href="#">
            <small>Forgot password?</small>
        </a>

        <p class="text-muted text-center">
            <small>Do not have an account?</small>
        </p>
        <a class="btn btn-sm btn-white btn-block" href="register.html">Create an account</a>

    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server" ID="LogoutButton" Visible="false">
        <div>
            <div>
                <asp:Button runat="server" OnClick="SignOut" Text="Log out" class="btn btn-primary block full-width m-b" />
            </div>
        </div>
    </asp:PlaceHolder>

  
</asp:Content>
