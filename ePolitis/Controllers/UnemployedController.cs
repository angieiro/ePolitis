using ePolitis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePolitis.Controllers
{
    public class UnemployedController : Controller
    {
        private MyModel db = new MyModel();

        // GET: Unemployed
        public ActionResult Index(Unemployed unemployed)
        {
            return View(unemployed);
        }


        public ActionResult PersonalInfoCreate(User user)
        {
            Unemployed currentUser = new Unemployed();
            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;

            return View(currentUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoCreate(Unemployed unemployed)
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
            return RedirectToAction("Index", currentUser);


        }


        public ActionResult OAEDBenefitFeatures()
        {
            return View();
        }
    }
}