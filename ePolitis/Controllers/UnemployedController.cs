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
            Citizen currentUser = new Citizen()
            {
                Email = user.Email
            };
            return View(currentUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoCreate(Citizen unemployed)
        {

            Citizen currentUser = new Models.Citizen()
            {
                Email = unemployed.Email,
                FirstName = unemployed.FirstName,
                LastName = unemployed.LastName,
                FathersName = unemployed.FathersName,
                MothersName = unemployed.MothersName,
                Gender = unemployed.Gender,
                DateOfBirth = unemployed.DateOfBirth,
                Afm = unemployed.Afm,
                Ama = unemployed.Ama,
                Amka = unemployed.Amka,
                BirthLocation = unemployed.BirthLocation,
                Country = unemployed.Country,
                Nationality = unemployed.Nationality,
                IdNumber = unemployed.IdNumber,
                PassportNumber = unemployed.PassportNumber,
                Phone = unemployed.Phone,
                MobilePhone = unemployed.MobilePhone,
                AddressStreet = unemployed.AddressStreet,
                AddressNumber = unemployed.AddressNumber,
                City = unemployed.City,
                AreaCode = unemployed.AreaCode,
                County = unemployed.County,
                AmOaed = unemployed.AmOaed,
                CardOaed = unemployed.CardOaed
            };

            db.Citizens.Add(currentUser);
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
        public ActionResult PersonalInfoUpdate(Citizen unemployed)
        {

            Citizen currentUser = db.Citizens.SingleOrDefault(e => e.Email == unemployed.Email);
            currentUser.FirstName = unemployed.FirstName;
            currentUser.LastName = unemployed.LastName;
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