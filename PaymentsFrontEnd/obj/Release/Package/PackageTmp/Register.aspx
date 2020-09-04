<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PaymentsFrontEnd.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="row">
        <div class="col-lg-7">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Register All System Users <small>
                        <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label></small></h5>
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
                                <asp:TextBox ID="UserName" runat="server" class="form-control" placeholder="User Name" ></asp:TextBox>

                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email" ></asp:TextBox>

                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="txtPhoneNo" runat="server" class="form-control" placeholder="Id Number" ></asp:TextBox>

                            </div>


                        </div>

                        <div class="col-sm-6">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlRoles" runat="server" class="form-control" placeholder="Role" ></asp:DropDownList>

                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="Password" TextMode="Password" runat="server" class="form-control" placeholder="Password" ></asp:TextBox>

                            </div>

                            <div class="form-group">
                                <asp:TextBox ID="ConfirmPassword" TextMode="Password" runat="server" class="form-control has-feedback-left" placeholder="ConfirmPassword" ></asp:TextBox>
                            </div>

                            <div class="form-group row">
                                <div class="col-md-9 col-sm-9  offset-md-3">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-primary" />
                                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" OnClick="CreateUser_Click" Text="Register" />

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
                    <h5>Register All System Roles </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>

                <div class="ibox-content">
                    <div class="form-group">
                        <asp:TextBox ID="txtRoleName" runat="server" class="form-control" placeholder="Role Name" ></asp:TextBox>

                    </div>

                    <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-3">
                            <asp:Button ID="btnCancelRole" runat="server" Text="Cancel" class="btn btn-primary" />
                            <asp:Button ID="btnCreateRole" runat="server" class="btn btn-success" OnClick="btnCreateRole_Click" Text="Create Role" />

                        </div>
                    </div>

                </div>
            </div>

        </div>


        <div class="col-lg-6">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>All System Users! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content" style=" overflow: scroll ;">
                    <asp:GridView ID="gvUsers" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvUsers_PageIndexChanging" CellPadding="1" DataKeyNames="Id" CellSpacing="1" AutoGenerateColumns="False" OnRowCancelingEdit="gvUsers_RowCancelingEdit" OnRowEditing="gvUsers_RowEditing" OnRowUpdating="gvUsers_RowUpdating" OnRowDataBound="gvUsers_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="User Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id Number">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditPhoneNo" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPhoneNo" runat="server" Text='<%# Bind("PhoneNumber") %>'></asp:Label>
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

                            <asp:TemplateField HeaderText="Operations">

                                <EditItemTemplate>
                                    <asp:Button ID="Button3" runat="server" CommandName="Update" Text="Update" class="btn btn-primary" UseSubmitBehavior="false" />
                                    <asp:Button ID="Button4" runat="server" CommandName="Cancel" Text="Cancel" class="btn btn-primary" UseSubmitBehavior="false" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Button ID="Button1" runat="server" CommandName="Edit" Text="Edit" class="btn btn-primary" Height="25px" UseSubmitBehavior="false" />
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
                    <h5>All System Roles! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content" style=" overflow: scroll ;">
                    <asp:GridView ID="gvRoles" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" OnPageIndexChanging="gvRoles_PageIndexChanging" CellPadding="1" DataKeyNames="Id" CellSpacing="1" AutoGenerateColumns="False" OnRowCancelingEdit="gvRoles_RowCancelingEdit" OnRowEditing="gvRoles_RowEditing" OnRowUpdating="gvRoles_RowUpdating">
                        <Columns>
                            <asp:TemplateField HeaderText="Role Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditRoleName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblRoleName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Operations">

                                <EditItemTemplate>
                                    <asp:Button ID="Button2" runat="server" CommandName="Update" Text="Update" class="btn btn-primary" UseSubmitBehavior="false" />
                                    <asp:Button ID="Button5" runat="server" CommandName="Cancel" Text="Cancel" class="btn btn-primary" UseSubmitBehavior="false" />
                                </EditItemTemplate>

                                <ItemTemplate>
                                    <asp:Button ID="Button6" runat="server" CommandName="Edit" Text="Edit" class="btn btn-primary" Height="25px" UseSubmitBehavior="false" />
                                </ItemTemplate>

                            </asp:TemplateField>

                        </Columns>

                    </asp:GridView>

                </div>
            </div>
        </div>


    </div>


</asp:Content>
