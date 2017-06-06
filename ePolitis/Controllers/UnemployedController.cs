using ePolitis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ePolitis.Controllers
{
    public class UnemployedController : Controller
    {
        private MyModel db = new MyModel();

        [Authorize]
        public ActionResult Index()
        {

            return View(Session["unemployeeUser"]);
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

        //Update PersonalInfoCreate so as to update changes to existed unemployed users as well
        public ActionResult PersonalInfoUpdate()
        {
            return View(Session["unemployeeUser"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoUpdate(Unemployed unemployed)
        {

            Unemployed currentUser = db.Unemployeds.SingleOrDefault(e => e.Email == unemployed.Email);

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

            Session["unemployeeUser"] = currentUser;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult OAEDBenefitFeatures()
        {
            return View();
        }

        //IKA Services
        public ActionResult IKAEkdosiAMA()
        {
            //_updateVisits("IKAEkdosiAMA");
            return View();
        }

        public ActionResult IKAEkdosiVivliariouYgeias()
        {
            //_updateVisits("IKAEkdosiVivliariouYgeias");
            return View();
        }

        //OAED Services
        public ActionResult OAEDEggrafiMitrwo()
        {
            //_updateVisits("OAEDEggrafiMitrwo");
            return View();
        }

        public ActionResult OAEDEpidomaAnergias()
        {
            //_updateVisits("OAEDEpidomaAnergias");
            return View();
        }
    }
}