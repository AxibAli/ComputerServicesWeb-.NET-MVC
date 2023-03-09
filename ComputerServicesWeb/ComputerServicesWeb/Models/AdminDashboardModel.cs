using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerServicesWeb.Models
{
    public class AdminDashboardModel
    {
        public int ToatalPosts { get; set; }
        public int SoldPost { get; set; }
        public int ActivePost { get; set; }
        public int DeactivatedPost { get; set; }
        public int TotalServices { get; set; }
        public int TotalAdmins { get; set; }
    }
}