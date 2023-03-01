using ComputerServicesWeb.Infrastructure;
using ComputerServicesWeb.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerServicesWeb.Controllers
{
    [CustomAuthFilter]
    public class UsedMachinesController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        #region Used Machines
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MachineInformation(FormCollection form, HttpPostedFileBase file)
        {
         
                string _path = "";
                string FileName = "";

                if (file.ContentLength > 0)
                {
                    FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string Extension = Path.GetExtension(file.FileName);

                    FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;


                    _path = Path.Combine(Server.MapPath("~/Uploads"), FileName);
                    file.SaveAs(_path);
                }

                var obj = new UsedMachineModels
                {
                    Brand = form["Brand"].ToString(),
                    Harddisk = form["Harddisk"].ToString(),
                    PicturePath = $"/Uploads/{FileName}",
                    ModelNo = form["ModelNo"].ToString(),
                    OtherInformation=form["OtherInformation"].ToString(),
                    Processor=form["Processor"].ToString(),
                    Ram=form["Ram"].ToString(),
                    ScreenSize=form["ScreenSize"].ToString(),
                    Type=form["Type"].ToString()

                };

                _db.usedMachines.Add(obj);
                _db.SaveChanges();
           
                TempData["Message"] = "Post Posted Successfully ";
           
            return RedirectToAction("GetAllUsedMachines");
        }

        public ActionResult GetAllUsedMachines() 
        {
            var model = _db.usedMachines.OrderByDescending(x=>x.id).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult GetAllUsedMachines(int? pageNumber)
        {
            var records = _db.usedMachines.OrderByDescending(x => x.id).ToList().ToPagedList(pageNumber ?? 1, 6);
            return View(records);
        }

        public JsonResult GetusedMachinesById(int usedMachines_ID)
        {
            var model = _db.usedMachines.Where(x => x.id == usedMachines_ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateusedMachine(UsedMachineModels data)
        {

            


            return Json( JsonRequestBehavior.AllowGet);


        }

        #endregion

        #region Services Actions
        public ActionResult Services() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Services(FormCollection form, HttpPostedFileBase file)
        {
          
                string _path = "";
                string FileName = "";
                if (file.ContentLength > 0)
                {
                    FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string Extension = Path.GetExtension(file.FileName);

                    FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;


                    _path = Path.Combine(Server.MapPath("~/Uploads"), FileName);
                    file.SaveAs(_path);
                }

                var obj = new ServicesModel
                {
                    Name = form["Name"].ToString(),
                    Description = form["Description"].ToString(),
                    PicturePath = $"/Uploads/{FileName}",
                };

                _db.services.Add(obj);
                _db.SaveChanges();
            
          
            return RedirectToAction("GetAllServices");
        }

        public ActionResult GetAllServices() 
        {
            var model = _db.services.OrderByDescending(x => x.id).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult GetAllServices(int? pageNumber)
        {
            var records = _db.services.OrderByDescending(x => x.id).ToList().ToPagedList(pageNumber ?? 1, 6);
            return View(records);
        }

        public ActionResult ServiceDelete()
        {
            return View();
        }

        public ActionResult ServiceEdit()
        {
            return View();
        }
        #endregion

    }
}