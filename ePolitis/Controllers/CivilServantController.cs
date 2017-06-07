using ePolitis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePolitis.Controllers
{
    public class CivilServantController : Controller
    {
        private MyModel db = new MyModel();

        // GET: CivilServant

        public ActionResult Index()
        {
            UnemploymentRequestList EmployeesApplicants = new UnemploymentRequestList();
            EmployeesApplicants.RequestList = db.UnemploymentRequests.Include("Employee").ToList();
            /*
            foreach (var req in rList)
            {
                req.Employee = db.Employees.SingleOrDefault(e => e.Afm == req.Afm );
                EmployeesApplicants.RequestList.Add(req);
            }
            */
            return View(EmployeesApplicants);
        }
    }
}