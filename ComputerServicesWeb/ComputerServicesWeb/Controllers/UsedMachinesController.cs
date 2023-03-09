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
            UsedMachineModels obj = new UsedMachineModels();

            obj.Types = new SelectList(_db.types.ToList(), "id", "TypeName");
            obj.ArabicTypes = new SelectList(_db.types.ToList(), "id", "ArabicTypeName");
            return View(obj);
        }
        [HttpPost]
        public ActionResult MachineInformation(FormCollection form, HttpPostedFileBase[] file)
        {

            string _path = "";
            string FileName = "";
            string combinefilenames = "";

            if (file.Length > 0)
            {
                foreach (var item in file)
                {
                    FileName = Path.GetFileNameWithoutExtension(item.FileName);
                    string Extension = Path.GetExtension(item.FileName);

                    FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;


                    _path = Path.Combine(Server.MapPath("~/Uploads"), FileName);
                    item.SaveAs(_path);
                    if (combinefilenames == "")
                    {
                        combinefilenames += "/Uploads/" + FileName;
                    }
                    else
                    {
                        combinefilenames += "," + "/Uploads/" + FileName;
                    }

                }
            }

            var type = 0;

            if (form["ListofType"] != null)
            {
                type = Convert.ToInt32(form["ListofType"]);

            }
            else if (form["ArabicListofType"] != null)
            {
                type = Convert.ToInt32(form["ArabicListofType"]);
            }
            var obj = new UsedMachineModels
            {
                usedmachineId =form["usedmachineId"],
                Brand = form["Brand"].ToString(),
                Harddisk = form["Harddisk"].ToString(),
                PicturePath = combinefilenames,
                ModelNo = form["ModelNo"].ToString(),
                OtherInformation = form["OtherInformation"].ToString(),
                Processor = form["Processor"].ToString(),
                Ram = form["Ram"].ToString(),
                ScreenSize = form["ScreenSize"].ToString(),
                Type = type,
                ArabicBrand = form["ArabicBrand"].ToString(),
                ArabicHarddisk = form["ArabicHarddisk"].ToString(),
                ArabicModelNo = form["ArabicModelNo"].ToString(),
                ArabicOtherInformation = form["ArabicOtherInformation"].ToString(),
                ArabicProcessor = form["ArabicProcessor"].ToString(),
                ArabicRam = form["ArabicRam"].ToString(),
                ArabicScreenSize = form["ArabicScreenSize"].ToString(),
                Status = "Active"

            };

            _db.usedMachines.Add(obj);
            _db.SaveChanges();

            TempData["Message"] = "Post Posted Successfully ";

            return RedirectToAction("GetAllUsedMachines");

        }
        public ActionResult GetAllUsedMachines()
        {
            var model = _db.usedMachines.OrderByDescending(x => x.id).ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult GetAllUsedMachines(int? pageNumber)
        {
            var records = _db.usedMachines.OrderByDescending(x => x.id).ToList().ToPagedList(pageNumber ?? 1, 6);
            return View(records);
        }
        public ActionResult GetusedMachinesById(int usedMachine_ID)
        {
            var model = _db.usedMachines.Where(x => x.id == usedMachine_ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateusedMachine(string data, HttpPostedFileBase[] file)
        {
            UsedMachineModels model = JsonConvert.DeserializeObject<UsedMachineModels>(data);
            string FileName = "";
            string _path = "";
            string combinefilenames = "";


            if (file != null)
            {

                if (file.Length > 0)
                {
                    foreach (var item in file)
                    {
                        FileName = Path.GetFileNameWithoutExtension(item.FileName);
                        string Extension = Path.GetExtension(item.FileName);

                        FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;


                        _path = Path.Combine(Server.MapPath("~/Uploads"), FileName);
                        item.SaveAs(_path);
                        if (combinefilenames == "")
                        {
                            combinefilenames += "/Uploads/" + FileName;
                        }
                        else
                        {
                            combinefilenames += "," + "/Uploads/" + FileName;
                        }

                    }
                

                var usedmachine = _db.usedMachines.Where(x => x.id == model.id).FirstOrDefault();
                    usedmachine.PicturePath = combinefilenames;
                    usedmachine.Brand = model.Brand;
                    usedmachine.Harddisk = model.Harddisk;
                    usedmachine.Type = model.Type;
                    usedmachine.ScreenSize = model.ScreenSize;
                    usedmachine.Ram = model.Ram;
                    usedmachine.Processor = model.Processor;
                    usedmachine.OtherInformation = model.OtherInformation;
                    usedmachine.ModelNo = model.ModelNo;
                    usedmachine.ArabicBrand = model.ArabicBrand;
                    usedmachine.ArabicHarddisk = model.ArabicHarddisk;
                    usedmachine.ArabicScreenSize = model.ArabicScreenSize;
                    usedmachine.ArabicRam = model.ArabicRam;
                    usedmachine.ArabicProcessor = model.ArabicProcessor;
                    usedmachine.ArabicOtherInformation = model.ArabicOtherInformation;
                    usedmachine.ArabicModelNo = model.ArabicModelNo;
                    usedmachine.Status = model.Status;
                    usedmachine.Price = model.Price;

                    _db.Entry(usedmachine).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            else
            {
                var usedmachine = _db.usedMachines.Where(x => x.id == model.id).FirstOrDefault();
                usedmachine.PicturePath = model.existingpicturepath;
                usedmachine.Brand = model.Brand;
                usedmachine.Harddisk = model.Harddisk;
                usedmachine.Type = model.Type;
                usedmachine.ScreenSize = model.ScreenSize;
                usedmachine.Ram = model.Ram;
                usedmachine.Processor = model.Processor;
                usedmachine.OtherInformation = model.OtherInformation;
                usedmachine.ModelNo = model.ModelNo;
                usedmachine.ArabicBrand = model.ArabicBrand;
                usedmachine.ArabicHarddisk = model.ArabicHarddisk;
                usedmachine.ArabicScreenSize = model.ArabicScreenSize;
                usedmachine.ArabicRam = model.ArabicRam;
                usedmachine.ArabicProcessor = model.ArabicProcessor;
                usedmachine.ArabicOtherInformation = model.ArabicOtherInformation;
                usedmachine.Status = model.Status;
                usedmachine.ArabicModelNo = model.ArabicModelNo;
                usedmachine.Price = model.Price;

                _db.Entry(usedmachine).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UsedMachineDelete(int usedMachine_ID)
        {
            var usedMachine = _db.usedMachines.Where(x => x.id == usedMachine_ID).FirstOrDefault();
            _db.usedMachines.Remove(usedMachine);
            _db.SaveChanges();

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AjaxMethodForDropDown(string name)
        {
            List<SelectListItem> dropdown = (from dropdowns in this._db.types.Take(20)
                                             select new SelectListItem
                                             {
                                                 Value = dropdowns.id.ToString(),
                                                 Text = dropdowns.TypeName,

                                             }).ToList();
            return Json(dropdown);
        }

        [HttpPost]
        public JsonResult AjaxMethodForArabicDropDown(string name)
        {
            List<SelectListItem> dropdown = (from dropdowns in this._db.types.Take(20)
                                             select new SelectListItem
                                             {
                                                 Value = dropdowns.id.ToString(),
                                                 Text = dropdowns.ArabicTypeName,

                                             }).ToList();
            return Json(dropdown);
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
                ArabicName = form["ArabicName"].ToString(),
                Description = form["Description"].ToString(),
                ArabicDescription = form["ArabicDescription"].ToString(),
                Status = "Active",
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

        public ActionResult GetServiceById(int service_ID)
        {
            var model = _db.services.Where(x => x.id == service_ID).SingleOrDefault();
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public ActionResult UpdateService(string data, HttpPostedFileBase file)
        {
            ServicesModel model = JsonConvert.DeserializeObject<ServicesModel>(data);
            string FileName = "";
            string _path = "";

            if (file != null)
            {
                if (file.ContentLength > 0)
                {
                    FileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string Extension = Path.GetExtension(file.FileName);
                    FileName = FileName + DateTime.Now.ToString("yymmssfff") + Extension;
                    _path = Path.Combine(Server.MapPath("~/Uploads"), FileName);
                    file.SaveAs(_path);

                    var service = _db.services.Where(x => x.id == model.id).FirstOrDefault();
                    service.PicturePath = $"/Uploads/{FileName}";
                    service.Name = model.Name;
                    service.Description = model.Description;
                    _db.Entry(service).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                }
            }
            else
            {
                var service = _db.services.Where(x => x.id == model.id).FirstOrDefault();
                service.PicturePath = model.existingpicturepath;
                service.Name = model.Name;
                service.Description = model.Description;
                _db.Entry(service).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ServiceDelete(int service_ID)
        {
            var service = _db.services.Where(x => x.id == service_ID).FirstOrDefault();
            _db.services.Remove(service);
            _db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}