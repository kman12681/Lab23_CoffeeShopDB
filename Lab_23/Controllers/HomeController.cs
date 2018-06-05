using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Lab_23.Models;


namespace Lab_23.Controllers
{
    public class HomeController : Controller
    {        

        public ActionResult Index()
        {
            CoffeeEntities orm = new CoffeeEntities();

            ViewBag.Items = orm.Items.ToList();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        
        
    }
}