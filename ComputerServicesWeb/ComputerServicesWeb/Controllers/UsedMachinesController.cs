using ComputerServicesWeb.Infrastructure;
using ComputerServicesWeb.Models;
using Microsoft.AspNet.Identity;
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
        log4net.ILog errlogger = log4net.LogManager.GetLogger("ErrorLogFile");

        // GET: UsedMachines
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MachineInformation(FormCollection form, HttpPostedFileBase file)
        {
            try
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
            }
            catch(Exception ex)
            {
                errlogger.Error(ex.Message);
            }
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


        public ActionResult Services() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Services(FormCollection form, HttpPostedFileBase file)
        {
            try
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
            }
            catch (Exception ex)
            {
                errlogger.Error(ex.Message);
            }
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

    }
}