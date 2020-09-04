using System;
using System.Web.UI.WebControls;

using PaymentsFrontEnd.Repository;

namespace PaymentsFrontEnd
{
    public partial class ManageMenu : System.Web.UI.Page
    {
        private MenuRepository menuRepository = new MenuRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateMenuDropDown();
                populateMenuGridView();
                populateSubMenuGridView();
            }
        }

        protected void btnCreateMenu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMenuName.Text) || txtMenuName.Text == null)
            {
                lblMessage.Text = "Menu is Empty!";
            }
            else
            {

                if (menuRepository.CreateMenu(txtMenuName.Text) > 0)
                {
                    lblMessage.Text = "(" + txtMenuName.Text + ") Created Successfully!";
                    populateMenuGridView();
                }
                else
                {
                    lblMessage.Text = "Menu Not Created!";
                }
            }
        }

        protected void btnCancelMenu_Click(object sender, EventArgs e)
        {
            txtMenuName.Text = "";
        }

        protected void btnCancelSubMenu_Click(object sender, EventArgs e)
        {
            txtSubMenuName.Text = "";
            txtSubMenuUrl.Text = "";
        }

        protected void btnCreateSubMenu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubMenuName.Text) || txtSubMenuName.Text == null)
            {
                lblMessage1.Text = "Sub Menu is Empty!";
            }
            else if (string.IsNullOrEmpty(txtSubMenuUrl.Text) || txtSubMenuUrl.Text == null)
            {
                lblMessage1.Text = "Sub Menu Url is Empty!";
            }
            else
            {
                if (menuRepository.CreateSubMenu(txtSubMenuName.Text, long.Parse(ddlMenu.SelectedValue), txtSubMenuUrl.Text) > 0)
                {
                    lblMessage1.Text = "(" + txtSubMenuName.Text + ") Created Successfully!";
                    populateSubMenuGridView();
                }
                else
                {
                    lblMessage1.Text = "Sub Menu Not Created!";
                }
            }
        }

        protected void gvMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMenu.EditIndex = -1;
            populateMenuGridView();
        }

        protected void gvMenu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMenu.EditIndex = e.NewEditIndex;
            populateMenuGridView();
        }

        protected void gvMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMenu.PageIndex = e.NewPageIndex;
            populateMenuGridView();
        }

        protected void gvMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            TextBox txtEditMenuName = gvMenu.Rows[e.RowIndex].FindControl("txtEditMenuName") as TextBox;

            int menuId = Convert.ToInt16(gvMenu.DataKeys[e.RowIndex].Values["MenuId"].ToString());

            if (menuRepository.UpdateMenu(menuId, txtEditMenuName.Text) > 0)
            {
                lblMessage.Text = "Menu Updated Successfully!";
                gvMenu.EditIndex = -1;
                populateMenuGridView();
            }
            else
            {
                lblMessage.Text = "Menu Not Updated!";
            }
        }

        public void populateMenuDropDown()
        {
            ddlMenu.DataSource = menuRepository.GetMenu();
            ddlMenu.DataTextField = "MenuName";
            ddlMenu.DataValueField = "MenuId";
            ddlMenu.DataBind();

            ddlMenu.Items.Insert(0, new ListItem("<--Select Menu-->", "0"));
        }

        protected void gvSubMenu_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSubMenu.EditIndex = -1;
            populateSubMenuGridView();
        }

        protected void gvSubMenu_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSubMenu.EditIndex = e.NewEditIndex;
            populateSubMenuGridView();
        }

        protected void gvSubMenu_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string menuName = null;

                    //check if is in edit mode
                    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                    {
                        DropDownList ddlMenuGrid = (DropDownList)e.Row.FindControl("ddlMenuGrid");
                        //Bind Menu data to dropdownlist
                        ddlMenuGrid.DataTextField = "MenuName";
                        ddlMenuGrid.DataValueField = "MenuId";
                        ddlMenuGrid.DataSource = menuRepository.GetMenu();
                        ddlMenuGrid.DataBind();

                        ddlMenuGrid.Items.Insert(0, new ListItem("<--Select Menu-->", "0"));

                        //Select the Menu Name in DropDownList
                        menuName = (e.Row.FindControl("lblMenuName") as Label).Text;
                        ddlMenuGrid.Items.FindByValue(menuName).Selected = true;
                    }
                    else
                    {
                        DropDownList ddlMenuGrid1 = (DropDownList)e.Row.FindControl("ddlMenuGrid1");

                        ddlMenuGrid1.DataSource = menuRepository.GetMenu();
                        ddlMenuGrid1.DataTextField = "MenuName";
                        ddlMenuGrid1.DataValueField = "MenuId";
                        ddlMenuGrid1.DataBind();

                        ddlMenuGrid1.Items.Insert(0, new ListItem("<--Select Menu-->", "0"));

                        //Select the Sub County of Customer in DropDownList
                        menuName = (e.Row.FindControl("lblMenuName1") as Label).Text;
                        ddlMenuGrid1.Items.FindByValue(menuName).Selected = true;
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        protected void gvSubMenu_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSubMenu.PageIndex = e.NewPageIndex;
            populateSubMenuGridView();
        }

        protected void gvSubMenu_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                TextBox txtEditSubMenuName = gvSubMenu.Rows[e.RowIndex].FindControl("txtEditSubMenuName") as TextBox;
                TextBox txtEditSubMenuUrl = gvSubMenu.Rows[e.RowIndex].FindControl("txtEditSubMenuUrl") as TextBox;
                DropDownList ddlMenuGrid = gvSubMenu.Rows[e.RowIndex].FindControl("ddlMenuGrid") as DropDownList;

                int subMenuId = Convert.ToInt16(gvSubMenu.DataKeys[e.RowIndex].Values["SubMenuId"].ToString());

                if (menuRepository.UpdateSubMenu(subMenuId, txtEditSubMenuName.Text, long.Parse(ddlMenuGrid.SelectedValue), txtEditSubMenuUrl.Text) > 0)
                {
                    lblMessage.Text = "Menu Updated Successfully!";
                    gvSubMenu.EditIndex = -1;
                    populateSubMenuGridView();
                }
                else
                {
                    lblMessage.Text = "Menu Not Updated!";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void populateMenuGridView()
        {
            gvMenu.DataSource = menuRepository.GetMenu();
            gvMenu.DataBind();
        }

        private void populateSubMenuGridView()
        {
            gvSubMenu.DataSource = menuRepository.GetSubMenu();
            gvSubMenu.DataBind();
        }
    }
}