using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using Microsoft.AspNet.Identity;

using PaymentsFrontEnd.Models;
using PaymentsFrontEnd.Repository;

namespace PaymentsFrontEnd
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        private MenuRepository menuRepository = new MenuRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var user = authenticationManager.User.Identity.Name;
                var userId = authenticationManager.User.Identity.GetUserId();

                string roleId = menuRepository.GetUserRoleByUserId(userId);

                lblWelcome.Text = user;
                //  lblWelcome1.Text = user;

                GetMenuData(roleId);
            }
        }

        /// This method will return data for menu creation
        public void GetMenuData(string roleId)
        {
            StringBuilder objStr = new StringBuilder();
            List<MenuList> objPmenu = new List<MenuList>();
            List<SubMenuList> objSmenu = new List<SubMenuList>();
            List<MenuAssignment> assign = new List<MenuAssignment>();
            List<MenuAssignment> menuList = new List<MenuAssignment>();
            //  List<ChildSubMenu> objcmenu = new List<ChildSubMenu>();
            //   objcmenu = GetChildSubMenu();
            objPmenu = menuRepository.GetMenu();
            objSmenu = menuRepository.GetSubMenu();
            menuList = menuRepository.GetMenuAssignmentsByRoleId(roleId);


            if (menuList.Count > 0)
            {
                objStr.Append("<ul class='nav side-menu'>");

                var distinctMenuItems = menuList.GroupBy(x => x.MenuId).Select(y => y.First()).ToList();

                foreach (var item in distinctMenuItems)
                {
                    MenuList _pitem = objPmenu.Where(w => w.MenuId == item.MenuId).FirstOrDefault();

                    objStr.Append("<li><a><i class='fa fa-star'></i>" + _pitem.MenuName + "<span class='fa arrow'></span></a>");

                    var subitem = objSmenu.Where(m => m.MenuId == item.MenuId).ToList();

                    objStr.Append("<ul class='nav nav-second-level collapse'>");
                    foreach (var sitem in menuList.Where(w => w.MenuId == item.MenuId))//Sub Menu
                    {
                        SubMenuList _sitem = objSmenu.Where(m => m.SubMenuId == sitem.SubMenuId).FirstOrDefault();

                        objStr.Append("<li><a href='" + _sitem.SubMenuUrl + "'>" + _sitem.SubMenuName + "</a>");

                        objStr.Append("</li>");
                    }
                    objStr.Append("</ul>");
                }

                objStr.Append("</li>");
                objStr.Append("</ul>");

                ltMenus.Text = objStr.ToString();
            }
        }

    }
}

