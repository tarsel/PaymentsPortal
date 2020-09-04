<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageUserMenu.aspx.cs" Inherits="PaymentsFrontEnd.ManageUserMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <!-- page content -->
    <div class="row">
        <div class="col-lg-7">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Assign Menu's to Roles<small>
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></small></h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>

                <div class="ibox-content">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlMenuSelect" runat="server" class="form-control" OnSelectedIndexChanged="ddlMenuSelect_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </div>

                    <div class="clearfix"></div>
                    <div class="form-group">
                        <asp:CheckBoxList ID="cbMenu" runat="server" RepeatLayout="OrderedList" Width="432px"></asp:CheckBoxList>
                    </div>

                    <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-3">
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" />
                            <asp:Button ID="btnSubmit" runat="server" Text="Update" class="btn btn-success" OnClick="btnSubmit_Click" />

                        </div>
                    </div>

                </div>
            </div>

        </div>

    </div>


</asp:Content>
