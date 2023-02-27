using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerServicesWeb.Models
{
    public class ServicesModel
    {
        public int id { get; set; }
        public string PicturePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}