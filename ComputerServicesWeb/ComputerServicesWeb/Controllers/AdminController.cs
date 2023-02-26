using ComputerServicesWeb.Infrastructure;
using ComputerServicesWeb.Models;
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
            string user_id = Session["UserId"].ToString();
            var user_info = _db.Users.Where(m => m.Id == user_id).FirstOrDefault();

            var model = new ProfileModel
            {
                Email= user_info.Email,
                PhoneNumber= user_info.PhoneNumber,
                UserName=user_info.UserName

            };

            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileModel model,HttpPostedFileBase file)
        {
            string _path = "";
            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                _path = Path.Combine(Server.MapPath("~/Uploads"), _FileName);
                file.SaveAs(_path);
            }

            var user = _db.Users.ToList().Where(x=>x.UserName==model.UserName).FirstOrDefault();
            user.UserPicturePath= $"/Uploads/{file.FileName}";
            _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Index");
         }
    }
}