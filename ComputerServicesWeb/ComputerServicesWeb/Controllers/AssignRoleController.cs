using ComputerServicesWeb.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ComputerServicesWeb.Controllers
{
    public class AssignRoleController : Controller
    {
        // GET: AssignRole
        ApplicationDbContext _dbcontext = new ApplicationDbContext();

        public ActionResult Index()
        {
            List<SelectListItem> roles=new List<SelectListItem>();
            List<SelectListItem> users=new List<SelectListItem>();

            using (var context = new ApplicationDbContext())
            {
                var Roles = context.Roles;
                var Users = context.Users;

                foreach(var role in Roles)
                {
                    //var name = role.Name;
                    roles.Add(new SelectListItem { Text = role.Name, Value = role.Id });
                }

                foreach(var user in Users)
                {
                    users.Add(new SelectListItem { Text = user.UserName, Value = user.Id });
                }

            }

            ViewBag.RolesList = roles;
            ViewBag.UsersList = users;

            return View();
        }
        
        [HttpPost]
        public ActionResult Assign(FormCollection form)
        {
            
            var role_id = form["RolesList"].ToString();
            var User_id = form["UsersList"].ToString();

            _dbcontext.UserRoles.Add(new IdentityUserRole { RoleId=role_id,UserId=User_id });
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}