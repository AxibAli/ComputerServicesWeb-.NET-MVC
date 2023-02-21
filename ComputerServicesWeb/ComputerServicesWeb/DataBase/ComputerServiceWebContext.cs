using ComputerServicesWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ComputerServicesWeb.DataBase
{
    public class ComputerServiceWebContext:DbContext
    {
        public ComputerServiceWebContext():base("DefaultConnection")
        {

        }
    }
}