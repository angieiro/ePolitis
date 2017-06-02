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
                    return RedirectToAction("UnemployedPersonalInfoCreate", user);
                }
                else
                {
                    return RedirectToAction("EmployeePersonalInfoCreate", user);

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
                return RedirectToAction("TestIndex", user);
            }
            else
            {
                ViewBag.NotMatching = true;
                return View("SignIn");
            }

        }

        public ActionResult UnemployedPersonalInfoCreate(User user)
        {
            Unemployed currentUser = new Unemployed();
            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;

            return View(currentUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnemployedPersonalInfoCreate(Unemployed unemployed)
        {

            Unemployed currentUser = new Models.Unemployed();

            currentUser.FirstName = unemployed.FirstName;
            currentUser.LastName = unemployed.LastName;
            currentUser.Email = unemployed.Email;
            currentUser.FathersName = unemployed.FathersName;
            currentUser.MothersName = unemployed.MothersName;
            currentUser.Gender = unemployed.Gender;
            currentUser.DateOfBirth = unemployed.DateOfBirth;
            currentUser.Afm = unemployed.Afm;
            currentUser.Ama = unemployed.Ama;
            currentUser.Amka = unemployed.Amka;
            currentUser.BirthLocation = unemployed.BirthLocation;
            currentUser.Country = unemployed.Country;
            currentUser.Nationality = unemployed.Nationality;
            currentUser.IdNumber = unemployed.IdNumber;
            currentUser.PassportNumber = unemployed.PassportNumber;
            currentUser.Phone = unemployed.Phone;
            currentUser.MobilePhone = unemployed.MobilePhone;
            currentUser.AddressStreet = unemployed.AddressStreet;
            currentUser.AddressNumber = unemployed.AddressNumber;
            currentUser.Area = unemployed.Area;
            currentUser.City = unemployed.City;
            currentUser.AreaCode = unemployed.AreaCode;
            currentUser.County = unemployed.County;
            currentUser.AmOaed = unemployed.AmOaed;
            currentUser.CardOaed = unemployed.CardOaed;

            db.Unemployeds.Add(currentUser);
            db.SaveChanges();
            //return View("ListIndex");
            return RedirectToAction("TestIndex");


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployeePersonalInfoCreate(Employee employee)
        {
            Employee currentUser = new Employee();

            currentUser.Afm = employee.Afm;

            currentUser.FirstName = employee.FirstName;
            currentUser.LastName = employee.LastName;
            currentUser.Email = employee.Email;
            currentUser.FathersName = employee.FathersName;
            currentUser.MothersName = employee.MothersName;
            currentUser.Gender = employee.Gender;
            currentUser.DateOfBirth = employee.DateOfBirth;

            currentUser.Ama = employee.Ama;
            currentUser.Amka = employee.Amka;
            currentUser.BirthLocation = employee.BirthLocation;
            currentUser.Country = employee.Country;
            currentUser.Nationality = employee.Nationality;
            currentUser.IdNumber = employee.IdNumber;
            currentUser.PassportNumber = employee.PassportNumber;
            currentUser.Phone = employee.Phone;
            currentUser.MobilePhone = employee.MobilePhone;
            currentUser.AddressStreet = employee.AddressStreet;
            currentUser.AddressNumber = employee.AddressNumber;
            currentUser.Area = employee.Area;
            currentUser.City = employee.City;
            currentUser.AreaCode = employee.AreaCode;
            currentUser.County = employee.County;
            currentUser.WorkPhone = employee.WorkPhone;

            db.Employees.Add(currentUser);
            db.SaveChanges();
            return RedirectToAction("TestIndex");
        }

        public ActionResult EmployeePersonalInfoCreate(User user)
        {
            Employee currentUser = new Employee();
            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;

            return View(currentUser);
        }
        //public ActionResult EmployeePersonalInfoDisplay(Employee user)
        //{
        //    return View(user);
        //}
    }
}