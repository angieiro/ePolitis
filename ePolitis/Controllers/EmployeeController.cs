﻿using ePolitis.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePolitis.Controllers
{
    public class EmployeeController : Controller
    {
        private MyModel db = new MyModel();


        [Authorize]
        public ActionResult Index()
        {
            return View(Session["employeeUser"]);
        }

        public ActionResult PersonalInfoCreate(/*User user*/)
        {
            Citizen employeeUser = new Citizen()
            {
                Email = (string)Session["Email"]
            };
            Session.Add("employeeUser", employeeUser);
            //return View(currentUser);
            return View(Session["employeeUser"]);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoCreate(Citizen employee)
        {
            Citizen currentUser = new Citizen();
            
            currentUser.Afm = employee.Afm;
            currentUser.Email = employee.Email;
            currentUser.FirstName = employee.FirstName;
            currentUser.LastName = employee.LastName;
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
            currentUser.City = employee.City;
            currentUser.AreaCode = employee.AreaCode;
            currentUser.County = employee.County;
            currentUser.WorkPhone = employee.WorkPhone;

            db.Citizens.Add(currentUser);
            db.SaveChanges();
            return RedirectToAction("SuccessfulRegister", "Home");
        }

        //Update PersonalInfoCreate so as to update changes to existed employees as well
        public ActionResult PersonalInfoUpdate()
        {
            return View(Session["employeeUser"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoUpdate(Citizen employee)
        {

            Citizen currentUser = db.Citizens.SingleOrDefault(e => e.Email == employee.Email);

            currentUser.Afm = employee.Afm;

            currentUser.FirstName = employee.FirstName;
            currentUser.LastName = employee.LastName;
            //currentUser.Email = employee.Email;
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
            currentUser.City = employee.City;
            currentUser.AreaCode = employee.AreaCode;
            currentUser.County = employee.County;
            currentUser.WorkPhone = employee.WorkPhone;

            Session["employeeUser"] = currentUser;
            db.SaveChanges();
            return RedirectToAction("Index"/*, currentUser*/);
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

        [HttpGet]
        public ActionResult OAEDUploadpage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OAEDUploadpage(HttpPostedFileBase file)
        {
            //Employee currentUser = new Employee();
            //currentUser = (Employee)Session["employeeUser"];

            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/UploadedFiles/"), filename);

                    //currentUser.FileApplicationPath = path;

                    file.SaveAs(path);
                    System.Diagnostics.Debug.WriteLine($"path: {path}");
                    db.SaveChanges();
                }
                ViewBag.Message = "File upload succesfull!!";

                
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }



        }
    }
}