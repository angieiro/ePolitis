using ePolitis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePolitis.Controllers
{
    public class HomeController : Controller
    {
        private MyModel db = new MyModel();

        public ActionResult TestIndex()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        //IKA Services
        public ActionResult IKAEkdosiAMA()
        {
            return View();
        }

        public ActionResult IKAEkdosiVivliariouYgeias()
        {
            return View();
        }

        //OAED Services
        public ActionResult OAEDEggrafiMitrwo()
        {
            return View();
        }

        public ActionResult OAEDEpidomaAnergias()
        {
            return View();
        }



        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (db.Users.Find(user.Email) == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                if (user.IsUnemployed)
                {
                    return RedirectToAction("PersonalInfoCreate", "Unemployed", user);
                }
                else
                {
                    return RedirectToAction("PersonalInfoCreate", "Employee", user);

                }

            }
            else
            {
                ViewBag.EmailExists = true;
                return View(user);
            }
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            User currentUser = db.Users.Find(user.Email);
            if (currentUser == null)
            {
                ViewBag.EmailNotExists = true;
                return View("Register", user);
            }
            if (currentUser.Password == user.Password)
            {
                Session.Add("Email", user.Email);
                //return View("ListIndex");
                if (user.IsUnemployed)
                {
                    Unemployed unemployeeUser = new Unemployed();
                    unemployeeUser = db.Unemployeds.Single(x => x.Email == user.Email);
                    return RedirectToAction("Index", "Employee", unemployeeUser);
                }
                else
                {
                    Employee employeeUser = new Employee();
                    employeeUser = db.Employees.Single(x => x.Email == user.Email);
                    return RedirectToAction("Index", "Unemployed", employeeUser);

                }

            }
            else
            {
                ViewBag.NotMatching = true;
                return View("SignIn");
            }

        }
        
    }
}