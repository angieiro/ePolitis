using ePolitis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePolitis.Controllers
{
    public class EmployeeController : Controller
    {
        private MyModel db = new MyModel();

        //[Authorize]
        //public ActionResult Index(Employee employee)
        //{
        //    return View(employee);
        //}

        [Authorize]
        public ActionResult Index()
        {
            return View(Session["employeeUser"]);
        }

        public ActionResult PersonalInfoCreate(User user)
        {
            Employee currentUser = new Employee();
            currentUser.Email = user.Email;
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;

            return View(currentUser);
        }

        //Update PersonalInfoCreate so as to update changes to existed employees as well
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonalInfoCreate(Employee employee)
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
            return RedirectToAction("Index", currentUser);
        }

        public ActionResult OAEDUploadpage()
        {
            return View();
        }
    }
}