using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_23.Models;
using System.Data.Entity;

namespace Lab_23.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Register(User data)
        {
            CoffeeEntities orm = new CoffeeEntities();

            if (ModelState.IsValid)
            {
                try
                {
                    orm.Users.Add(data);
                    orm.SaveChanges();
                    ViewBag.Message = $"{data.firstName} has been registered.";
                }
                catch (Exception e)
                {

                    ViewBag.Message = $"Something went wrong: {e.Message}";
                }
            }
            else
            {
                ViewBag.Message = $"Invalid entry, nothing added to database.";
            }

            return View();
        }

        
    }
}