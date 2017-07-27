using ePolitis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ePolitis.Controllers
{
    public class HomeController : Controller
    {
        private MyModel db = new MyModel();


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
        public ActionResult SignInSubmit(User user)
        {
            User currentUser = db.Users.Find(user.Email);
            if (currentUser == null)
            {
                ViewBag.EmailNotExists = true;
                return View("Register", user);
            }
            if (currentUser.Password == user.Password)
            {
                FormsAuthentication.SetAuthCookie(currentUser.Email, false);
                Session.Add("Email", user.Email);
                //return View("ListIndex");
                if (currentUser.IsCivilServant)
                {
                    Session.Add("user", currentUser);
                    return RedirectToAction("Index", "CivilServant");
                }
                if (currentUser.IsUnemployed)
                {
                    Citizen unemployeeUser = new Citizen();
                    unemployeeUser = db.Citizens.Single(x => x.Email == currentUser.Email);
                    Session.Add("unemployeeUser", unemployeeUser);

                    return RedirectToAction("Index", "Unemployed");

                }
                else
                {
                    Citizen employeeUser = new Citizen();
                    employeeUser = db.Citizens.Single(x => x.Email == currentUser.Email);
                    Session.Add("employeeUser", employeeUser);

                    return RedirectToAction("Index", "Employee");
                }

            }
            else
            {
                ViewBag.NotMatching = true;
                return View("SignIn");
            }

        }

        //Logout Action TO BE checked
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View();
        }

        public ActionResult SuccessfulRegister()
        {
            return View();
        }

    }
}