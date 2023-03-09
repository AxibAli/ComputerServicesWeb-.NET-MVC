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
            try
            {
                AdminDashboardModel model = new AdminDashboardModel();

                model.TotalAdmins = _db.Users.Count();
                model.TotalServices = _db.services.Count();
                model.DeactivatedPost = _db.usedMachines.Where(x => x.Status == "Deactivated").Count();
                model.ActivePost = _db.usedMachines.Where(x => x.Status == "Active").Count();
                model.SoldPost = _db.usedMachines.Where(x => x.Status == "Sold").Count();
                model.ToatalPosts = _db.usedMachines.Count();

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult MyProfile()
        {
            try
            {
                string user_id = Session["UserId"].ToString();
                var user_info = _db.Users.Where(m => m.Id == user_id).FirstOrDefault();

                var model = new ProfileModel
                {
                    Email = user_info.Email,
                    PhoneNumber = user_info.PhoneNumber,
                    UserName = user_info.UserName

                };

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfileModel model, HttpPostedFileBase file)
        {
            try
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
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult AddTypes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTypes(FormCollection form)
        {
            try
            {
                var obj = new TypeModel
                {
                    TypeName = form["typename"].ToString(),
                    ArabicTypeName = form["arabictypename"].ToString()

                };

                _db.types.Add(obj);
                _db.SaveChanges();

                TempData["Message"] = "Type Add Successfully ";

                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}