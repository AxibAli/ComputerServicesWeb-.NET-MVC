using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerServicesWeb.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}