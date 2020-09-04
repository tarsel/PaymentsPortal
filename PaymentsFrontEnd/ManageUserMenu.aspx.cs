using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using PaymentsFrontEnd.Models;
using PaymentsFrontEnd.Repository;


namespace PaymentsFrontEnd
{
    public partial class ManageUserMenu : System.Web.UI.Page
    {
        MenuRepository menuRepository = new MenuRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCheckBoxes();
                PopulateRoles();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            foreach (ListItem item in cbMenu.Items)
            {

                MenuAssignment menuAssignment = menuRepository.GetMenuAssignments(ddlMenuSelect.SelectedValue, int.Parse(item.Value));
                SubMenuList subMenuList = menuRepository.GetSubMenuBySubMenuId(int.Parse(item.Value));

                if (item.Selected == true && menuAssignment == null)
                {
                    menuRepository.CreateMenuAssignment(ddlMenuSelect.SelectedValue, subMenuList.MenuId, int.Parse(item.Value));

                }
                else if (item.Selected == false && menuAssignment != null)
                {
                    menuRepository.DeleteMenuAssignment(menuAssignment.MenuAssignmentId);
                }

            }
        }

        protected void ddlMenuSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckboxsItems(ddlMenuSelect.SelectedValue);
        }

        public void LoadCheckBoxes()
        {
            cbMenu.DataSource = menuRepository.GetSubMenu();
            cbMenu.DataTextField = "SubMenuName";
            cbMenu.DataValueField = "SubMenuId";
            cbMenu.DataBind();
        }

        public void PopulateRoles()
        {
            ddlMenuSelect.DataSource = menuRepository.GetAllRoles();
            ddlMenuSelect.DataTextField = "Name";
            ddlMenuSelect.DataValueField = "Id";
            ddlMenuSelect.DataBind();

            ddlMenuSelect.Items.Insert(0, new ListItem("<---- Select Role ---->", "0"));
        }

        private void CheckboxsItems(string roleId)
        {
            List<MenuAssignment> menuList = menuRepository.GetMenuAssignmentsByRoleId(roleId);

            foreach (ListItem item in cbMenu.Items)
            {
                if (menuList.Count > 0)
                {
                    foreach (var list in menuList)
                    {
                        if (int.Parse(item.Value) == list.SubMenuId)
                        {
                            item.Selected = true;
                        }
                    }
                }
                else
                {
                    item.Selected = false;
                }

            }
        }

    }
}