using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class SubMenuList
    {
        public int SubMenuId { get; set; }
        public int MenuId { get; set; }
        public string SubMenuName { get; set; }
        public string SubMenuUrl { get; set; }
    }
}