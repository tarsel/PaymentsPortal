using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class ChildSubMenu
    {
        public int SubParentId { get; set; }
        public string ChildSubMenuName { get; set; }
        public string ChildSubMenuUrl { get; set; }
    }
}