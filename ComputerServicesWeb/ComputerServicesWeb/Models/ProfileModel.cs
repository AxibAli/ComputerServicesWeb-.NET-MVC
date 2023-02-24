using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerServicesWeb.Models
{
    public class ProfileModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicturePath { get; set; }
    }
}