<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManageMenu.aspx.cs" Inherits="PaymentsFrontEnd.ManageMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- page content -->
    <div class="row">
        <div class="col-lg-7">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>Create Menu <small>
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
                                <asp:TextBox ID="txtMenuName" runat="server" class="form-control" placeholder="Menu Name" CausesValidation="true" ></asp:TextBox>
                            </div>

                            <div class="form-group row">
                                <div class="col-md-9 col-sm-9  offset-md-3">
                                    <asp:Button ID="btnCancelMenu" runat="server" Text="Cancel" class="btn btn-primary" OnClick="btnCancelMenu_Click" CausesValidation="false" />
                                    <asp:Button ID="btnCreateMenu" runat="server" Text="Submit" class="btn btn-success" OnClick="btnCreateMenu_Click" />

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
                    <h5>Create Sub Menu</h5><small><asp:Label ID="lblMessage1" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></small>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>


                <div class="ibox-content">
                    <div class="form-group">
                        <asp:DropDownList ID="ddlMenu" runat="server" class="form-control" placeholder="Choose Menu"></asp:DropDownList>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtSubMenuName" runat="server" class="form-control" placeholder="Sub Menu Name" CausesValidation="true" ></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtSubMenuUrl" runat="server" class="form-control" placeholder="URL" CausesValidation="true" ></asp:TextBox>

                    </div>


                    <div class="form-group row">
                        <div class="col-md-9 col-sm-9  offset-md-3">
                            <asp:Button ID="btnCancelSubMenu" runat="server" Text="Cancel" class="btn btn-primary" OnClick="btnCancelSubMenu_Click" />
                            <asp:Button ID="btnCreateSubMenu" runat="server" Text="Generate" class="btn btn-success" OnClick="btnCreateSubMenu_Click" />

                        </div>
                    </div>

                </div>
            </div>

        </div>



        <div class="col-lg-6">
            <div class="ibox ">
                <div class="ibox-title">
                    <h5>All Menu's in the System! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content" style=" overflow: scroll ;">
                    <asp:GridView ID="gvMenu" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" DataKeyNames="MenuId" AutoGenerateColumns="False" OnRowCancelingEdit="gvMenu_RowCancelingEdit" OnRowEditing="gvMenu_RowEditing" OnPageIndexChanging="gvMenu_PageIndexChanging" OnRowUpdating="gvMenu_RowUpdating">
                        <Columns>

                            <asp:TemplateField HeaderText="Menu Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditMenuName" runat="server" Text='<%# Bind("MenuName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuName" runat="server" Text='<%# Bind("MenuName") %>'></asp:Label>
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
                    <h5>All Sub Menu's in the System! </h5>
                    <div class="ibox-tools">
                        <a class="collapse-link">
                            <i class="fa fa-chevron-up"></i>
                        </a>

                    </div>
                </div>
                <div class="ibox-content" style=" overflow: scroll ;">
                    <asp:GridView ID="gvSubMenu" runat="server" class="table table-striped" AllowPaging="true" PageSize="10" DataKeyNames="SubMenuId" AutoGenerateColumns="False" OnRowCancelingEdit="gvSubMenu_RowCancelingEdit" OnRowEditing="gvSubMenu_RowEditing" OnRowDataBound="gvSubMenu_RowDataBound" OnPageIndexChanging="gvSubMenu_PageIndexChanging" OnRowUpdating="gvSubMenu_RowUpdating">
                        <Columns>

                            <asp:TemplateField HeaderText="Sub Menu Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditSubMenuName" runat="server" Text='<%# Bind("SubMenuName") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSubMenuName" runat="server" Text='<%# Bind("SubMenuName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Menu Name">
                                <EditItemTemplate>
                                    <asp:Label ID="lblMenuName" runat="server" Text='<%# Bind("MenuId") %>' Visible="false">        </asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlMenuGrid"></asp:DropDownList>

                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuName1" runat="server" Text='<%# Bind("MenuId") %>' Visible="false">        </asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlMenuGrid1" Enabled="false"></asp:DropDownList>

                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sub Menu Url">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEditSubMenuUrl" runat="server" Text='<%# Bind("SubMenuUrl") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSubMenuUrl" runat="server" Text='<%# Bind("SubMenuUrl") %>'></asp:Label>
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


    </div>

</asp:Content>
