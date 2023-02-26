using ComputerServicesWeb.Infrastructure;
using ComputerServicesWeb.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
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
                Email = user_info.Email,
                PhoneNumber = user_info.PhoneNumber,
                UserName = username,
                ProfilePicturePath = user_info.UserPicturePath

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileModel model, HttpPostedFileBase avatar)
        {

            if (ModelState.IsValid)
            {

                if (Path.GetExtension(avatar.FileName) == ".jpg" || Path.GetExtension(avatar.FileName) == ".jpeg" || Path.GetExtension(avatar.FileName) == ".png")
                {
                    string Filename = Path.GetFileNameWithoutExtension(avatar.FileName);
                    string Extension = Path.GetExtension(avatar.FileName);
                    Filename = Filename + DateTime.Now.ToString("yymmssfff") + Extension;
                    model.ProfilePicturePath = "~/Uploads/UserPictures" + Filename;
                    Filename = Path.Combine(Server.MapPath("~/Uploads/UserPictures"), Filename);
                    avatar.SaveAs(Filename);

                }


            }
            return View();

        }
    }
}