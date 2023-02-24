using ComputerServicesWeb.Infrastructure;
using ComputerServicesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerServicesWeb.Controllers
{
    [CustomAuthFilter]
    public class AdminController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MyProfile()
        {
            string username = Session["UserName"].ToString();
            var user_info = _db.Users.Where(m => m.UserName == username).FirstOrDefault();

            var model = new ProfileModel
            {
                Email= user_info.Email,
                PhoneNumber= user_info.PhoneNumber,
                UserName=username

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileModel model)
        {

            return View();
        }
    }
}