using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class MenuAssignment
    {
        public int MenuAssignmentId { get; set; }
        public string RoleId { get; set; }
        public int MenuId { get; set; }
        public int SubMenuId { get; set; }
    }
}