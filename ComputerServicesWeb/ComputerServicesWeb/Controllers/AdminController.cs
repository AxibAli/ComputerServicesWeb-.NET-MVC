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
            string user_id = Session["UserId"].ToString();

            if (file != null)
            {
                string _path = "";
                string FileName = "";

                if (file.ContentLength > 0)
                {
                    FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string Extension = Path.GetExtension(file.FileName);

                    FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;


                    _path = Path.Combine(Server.MapPath("~/Uploads/UserPictures/"), FileName);
                    file.SaveAs(_path);
                }

                var user = _db.Users.Where(x => x.Id == user_id).FirstOrDefault();
                user.UserPicturePath = $"/Uploads/UserPictures/{FileName}";
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.UserName = model.UserName;

                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                DisplayUserInfo.profile_picture_path = $"/Uploads/UserPictures/{FileName}";
                DisplayUserInfo.email = model.Email;
                DisplayUserInfo.Username = model.UserName;
            }
            else
            {
                var user = _db.Users.Where(x => x.Id == user_id).FirstOrDefault();
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.UserName = model.UserName;
                _db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                DisplayUserInfo.email = model.Email;
                DisplayUserInfo.Username = model.UserName;
            }
            return RedirectToAction("Index");
         }

        public ActionResult AddTypes() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTypes(FormCollection form)
        {
            var obj = new TypeModel
            {
                TypeName = form["typename"].ToString(),

            };

            _db.types.Add(obj);
            _db.SaveChanges();

            TempData["Message"] = "Type Add Successfully ";

            return View();
        }
    }
}