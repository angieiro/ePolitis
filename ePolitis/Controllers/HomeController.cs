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
                    return RedirectToAction("UnemployedPersonalInfoCreate");
                }
                else
                {
                    return RedirectToAction("EmployeePersonalInfoCreate");

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
                return RedirectToAction("TestIndex");
            }
            else
            {
                ViewBag.NotMatching = true;
                return View("SignIn");
            }

        }

        public ActionResult UnemployedPersonalInfoCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnemployedPersonalInfoCreate(Unemployed user)
        {

            Unemployed currentUser = new Models.Unemployed();

            currentUser.FirstName = currentUser.FirstName;
            currentUser.LastName = currentUser.LastName;
            currentUser.Email = currentUser.Email;
            currentUser.FathersName = currentUser.FathersName;
            currentUser.MothersName = currentUser.MothersName;
            currentUser.Gender = currentUser.Gender;
            currentUser.DateOfBirth = currentUser.DateOfBirth;
            currentUser.Afm = currentUser.Afm;
            currentUser.Ama = currentUser.Ama;
            currentUser.Amka = currentUser.Amka;
            currentUser.BirthLocation = currentUser.BirthLocation;
            currentUser.Country = currentUser.Country;
            currentUser.Nationality = currentUser.Nationality;
            currentUser.IdNumber = currentUser.IdNumber;
            currentUser.PassportNumber = currentUser.PassportNumber;
            currentUser.Phone = currentUser.Phone;
            currentUser.MobilePhone = currentUser.MobilePhone;
            currentUser.AddressStreet = currentUser.AddressStreet;
            currentUser.AddressNumber = currentUser.AddressNumber;
            currentUser.Area = currentUser.Area;
            currentUser.City = currentUser.City;
            currentUser.AreaCode = currentUser.AreaCode;
            currentUser.County = currentUser.County;
            currentUser.AmOaed = currentUser.AmOaed;
            currentUser.CardOaed = currentUser.CardOaed;

            db.Unemployeds.Add(currentUser);
            db.SaveChanges();
            //return View("ListIndex");
            return RedirectToAction("TestIndex");


        }

        public ActionResult EmployeePersonalInfoCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeePersonalInfoCreate(Employee user)
        {

            Employee currentUser = new Models.Employee();

            currentUser.FirstName = currentUser.FirstName;
            currentUser.LastName = currentUser.LastName;
            currentUser.Email = currentUser.Email;
            currentUser.FathersName = currentUser.FathersName;
            currentUser.MothersName = currentUser.MothersName;
            currentUser.Gender = currentUser.Gender;
            currentUser.DateOfBirth = currentUser.DateOfBirth;
            currentUser.Afm = currentUser.Afm;
            currentUser.Ama = currentUser.Ama;
            currentUser.Amka = currentUser.Amka;
            currentUser.BirthLocation = currentUser.BirthLocation;
            currentUser.Country = currentUser.Country;
            currentUser.Nationality = currentUser.Nationality;
            currentUser.IdNumber = currentUser.IdNumber;
            currentUser.PassportNumber = currentUser.PassportNumber;
            currentUser.Phone = currentUser.Phone;
            currentUser.MobilePhone = currentUser.MobilePhone;
            currentUser.AddressStreet = currentUser.AddressStreet;
            currentUser.AddressNumber = currentUser.AddressNumber;
            currentUser.Area = currentUser.Area;
            currentUser.City = currentUser.City;
            currentUser.AreaCode = currentUser.AreaCode;
            currentUser.County = currentUser.County;
            currentUser.WorkPhone = currentUser.WorkPhone;

            db.Employees.Add(currentUser);
            db.SaveChanges();
            //return View("ListIndex");
            return RedirectToAction("TestIndex");
        }

        public ActionResult EmployeePersonalInfoDisplay(Employee user)
        {
            return View(user);
        }
    }
}