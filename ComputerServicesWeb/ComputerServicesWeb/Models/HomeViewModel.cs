using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerServicesWeb.Models
{
    public class HomeViewModel
    {
        public IEnumerable<UsedMachineModels> usedMachines { get; set; }
        public IEnumerable<ServicesModel> services { get; set; }
    }
}