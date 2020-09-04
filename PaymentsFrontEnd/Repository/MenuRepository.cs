using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

using Dapper;

using PaymentsFrontEnd.Models;

namespace PaymentsFrontEnd.Repository
{
    public class MenuRepository
    {
        private string sqlConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();

        /// Get Data from Menu table        
        public List<MenuList> GetMenu()
        {
            List<MenuList> pi = new List<MenuList>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                pi = connection.Query<MenuList>("SELECT * FROM Menu").ToList();
                connection.Close();
            }
            return pi;
        }

        /// Get data from SubMenu table
        public List<SubMenuList> GetSubMenu()
        {
            List<SubMenuList> pi = new List<SubMenuList>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                pi = connection.Query<SubMenuList>("SELECT * FROM SubMenu").ToList();
                connection.Close();
            }
            return pi;
        }

        public MenuAssignment GetMenuAssignments(string roleId, int subMenuId)
        {
            MenuAssignment pi = null;
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                pi = connection.Query<MenuAssignment>("SELECT * FROM MenuAssignment WHERE RoleId=@RoleId AND SubMenuId=@SubMenuId", new { RoleId = roleId, SubMenuId = subMenuId }).FirstOrDefault();
                connection.Close();
            }
            return pi;
        }

        public List<MenuAssignment> GetMenuAssignmentsByRoleId(string roleId)
        {
            List<MenuAssignment> pi = new List<MenuAssignment>();

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                pi = connection.Query<MenuAssignment>("SELECT * FROM MenuAssignment WHERE RoleId=@RoleId", new { RoleId = roleId }).ToList();
                connection.Close();
            }
            return pi;
        }

        public SubMenuList GetSubMenuBySubMenuId(int subMenuId)
        {
            SubMenuList pi = null;
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                pi = connection.Query<SubMenuList>("SELECT * FROM SubMenu WHERE SubMenuId=@SubMenuId", new { SubMenuId = subMenuId }).FirstOrDefault();
                connection.Close();
            }
            return pi;
        }

        public int CreateMenuAssignment(string roleId, int menuId, int subMenuId)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into MenuAssignment (RoleId,MenuId,SubMenuId) values (@RoleId,@MenuId,@SubMenuId)", new { roleId, menuId, subMenuId });
                connection.Close();
                return affectedRows;
            }
        }

        public int UpdateMenuAssignment(string roleId, int menuId, int subMenuId)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("UPDATE MenuAssignment SET RoleId=@RoleId,MenuId=@MenuId WHERE SubMenuId=@SubMenuId", new { RoleId = roleId, MenuId = menuId, SubMenuId = subMenuId });
                connection.Close();
                return affectedRows;
            }
        }

        public int DeleteMenuAssignment(int menuAssignmentId)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("DELETE from MenuAssignment WHERE MenuAssignmentId=@MenuAssignmentId", new { MenuAssignmentId = menuAssignmentId });
                connection.Close();
                return affectedRows;
            }
        }

        public string GetUserRoleByUserId(string userId)
        {
            string pi;
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                pi = connection.QuerySingleOrDefault<string>("SELECT RoleId FROM AspNetUserRoles WHERE UserId=@UserId", new { UserId = userId });
                connection.Close();
            }
            return pi;
        }

        public int CreateMenu(string menuName)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into Menu (MenuName) values (@MenuName)", new { menuName });
                connection.Close();
                return affectedRows;
            }
        }

        public int CreateSubMenu(string subMenuName, long menuId, string subMenuUrl)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("Insert into SubMenu (SubMenuName,MenuId,SubMenuUrl) values (@SubMenuName,@MenuId,@SubMenuUrl)", new { subMenuName, menuId, subMenuUrl });
                connection.Close();
                return affectedRows;
            }
        }

        public int UpdateMenu(long menuId, string menuName)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("UPDATE Menu SET MenuName=@MenuName WHERE MenuId=@MenuId", new { MenuId = menuId, MenuName = menuName });
                connection.Close();
                return affectedRows;
            }
        }

        public int UpdateSubMenu(long subMenuId, string subMenuName, long menuId, string subMenuUrl)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("UPDATE SubMenu SET SubMenuName=@SubMenuName,MenuId=@MenuId,SubMenuUrl=@SubMenuUrl WHERE SubMenuId=@SubMenuId", new { SubMenuName = subMenuName, MenuId = menuId, SubMenuUrl = subMenuUrl, SubMenuId = subMenuId });

                connection.Close();

                return affectedRows;
            }
        }

        public List<SystemRoles> GetAllRoles()
        {
            List<SystemRoles> record = new List<SystemRoles>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                record = connection.Query<SystemRoles>("SELECT * FROM AspNetRoles").ToList();
                connection.Close();
            }
            return record;
        }

        public List<Users> GetAllUsers()
        {
            List<Users> record = new List<Users>();
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                record = connection.Query<Users>("SELECT * FROM AspNetUsers").ToList();
                connection.Close();
            }
            return record;
        }

        public int UpdateRole(string roleId, string roleName)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("UPDATE AspNetRoles SET Name=@Name WHERE Id=@Id", new { Id = roleId, Name = roleName });
                connection.Close();
                return affectedRows;
            }
        }

        public int UpdateUser(string userId, string userName, string phoneNumber, string email)
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute("UPDATE AspNetUsers SET UserName=@UserName, Email=@Email, PhoneNumber=@PhoneNumber WHERE Id=@Id", new { Id = userId, UserName = userName, Email = email, PhoneNumber = phoneNumber });
                connection.Close();
                return affectedRows;
            }
        }
    }
}