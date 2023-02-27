using ComputerServicesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerServicesWeb.Controllers
{

    public class HomeController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var model = _db.usedMachines.ToList();
            return View(model);
        }

        public ActionResult Service()
        {
            return View();
        }

    }
}