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
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);
                    _path = Path.Combine(Server.MapPath("~/Uploads"), _FileName);
                    file.SaveAs(_path);
                }

                var obj = new UsedMachineModels
                {
                    Brand = form["Brand"].ToString(),
                    Harddisk = form["Harddisk"].ToString(),
                    PicturePath = $"/Uploads/{file.FileName}",
                    ModelNo = form["ModelNo"].ToString(),
                    OtherInformation=form["OtherInformation"].ToString(),
                    Processor=form["Processor"].ToString(),
                    Ram=form["Ram"].ToString(),
                    ScreenSize=form["ScreenSize"].ToString(),
                    Type=form["Type"].ToString()

                };

                _db.usedMachines.Add(obj);
                _db.SaveChanges();
            }
            catch(Exception ex)
            {
                errlogger.Error(ex.Message);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Services() 
        {
            return View();
        }
    }
}