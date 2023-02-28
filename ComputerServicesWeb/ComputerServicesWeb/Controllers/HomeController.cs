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
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.usedMachines = _db.usedMachines.ToList();
            homeViewModel.services = _db.services.ToList();
            return View(homeViewModel);
        }

        public ActionResult Service()
        {
            var model = _db.services.ToList();
            return View(model);
        }

    }
}