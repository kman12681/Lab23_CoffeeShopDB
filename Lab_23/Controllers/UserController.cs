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
        //ActionResult About(Item data) from EF demo today, Users, not items, though.
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

        // old code before connected to database

        //    string firstName = "",
        //    string lastName = "",
        //    string email = "",
        //    int number = 0,
        //    string password = "",
        //    int cupsDay = 0,
        //    string strength = "")
        //{
        //    ViewBag.FirstName = firstName;
        //    ViewBag.LastName = lastName;
        //    ViewBag.Email = email;
        //    ViewBag.Number = number;
        //    ViewBag.Password = password;
        //    ViewBag.CupsDay = cupsDay;
        //    ViewBag.Strength = strength;
        //    return View();
        //}
    }
}