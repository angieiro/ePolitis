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

        //public ActionResult TestIndex()
        //{
        //    _updateVisits("TestIndex");
        //    var users = db.Users.ToList();

        //    return View(users);
        //}

        //IKA Services
        public ActionResult IKAEkdosiAMA()
        {
            _updateVisits("IKAEkdosiAMA");
            return View();
        }

        public ActionResult IKAEkdosiVivliariouYgeias()
        {
            _updateVisits("IKAEkdosiVivliariouYgeias");
            return View();
        }

        //OAED Services
        public ActionResult OAEDEggrafiMitrwo()
        {
            _updateVisits("OAEDEggrafiMitrwo");
            return View();
        }

        public ActionResult OAEDEpidomaAnergias()
        {
            _updateVisits("OAEDEpidomaAnergias");
            return View();
        }



        public ActionResult Register()
        {
            _updateVisits("Register");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            _updateVisits("Register");
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
            _updateVisits("SignIn");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignInSubmit(User user)
        {

            _updateVisits("SignIn");
            User currentUser = db.Users.Find(user.Email);
            if (currentUser == null)
            {
                ViewBag.EmailNotExists = true;
                return View("Register", user);
            }
            if (currentUser.Password == user.Password)
            {
                FormsAuthentication.SetAuthCookie(currentUser.LastName + currentUser.FirstName, false);
                Session.Add("Email", user.Email);
                //return View("ListIndex");
                if (currentUser.IsUnemployed)
                {
                    Unemployed unemployeeUser = new Unemployed();
                    unemployeeUser = db.Unemployeds.Single(x => x.Email == currentUser.Email);
                    Session.Add("unemployeeUser", unemployeeUser);

                    return RedirectToAction("Index", "Unemployed");

                }
                else
                {
                    Employee employeeUser = new Employee();
                    employeeUser = db.Employees.Single(x => x.Email == currentUser.Email);
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
            _updateVisits("SignOut");
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View();
        }

        private void _updateVisits(string name)
        {
            History h = (History)Session["History"];
            if (h == null)
            {
                h = new History();
                Session["History"] = h;
            }

            h.Visits.Add(name);

        }
    }
}