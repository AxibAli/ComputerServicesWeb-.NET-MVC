using ComputerServicesWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            homeViewModel.usedMachines = _db.usedMachines.Where(x => x.Status == "Active").OrderByDescending(x => x.id).ToList();
            homeViewModel.services = _db.services.Where(x => x.Status == "Active").OrderByDescending(x => x.id).ToList();
            return View(homeViewModel);
        }
        public ActionResult ArabicIndex()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.usedMachines = _db.usedMachines.Where(x => x.ArabicBrand != null && x.Status=="Active").OrderByDescending(x => x.id).ToList();
            homeViewModel.services = _db.services.Where(x => x.ArabicName != null && x.Status=="Active" ).OrderByDescending(x => x.id).ToList();
            return View(homeViewModel);
        }

        public ActionResult Service()
        {
            var model = _db.services.OrderByDescending(x=>x.id).ToList();
            return View(model);
        }


    }
}