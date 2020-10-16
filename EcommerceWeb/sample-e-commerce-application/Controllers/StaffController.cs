using sample_e_commerce_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample_e_commerce_application.Controllers
{
    public class StaffController : Controller
    {
        private EcomContext ecomContext = new EcomContext();
        // GET: Staff
        public ActionResult Index()
        {
            List<Staff> AllStaff = ecomContext.Staffs.ToList();
            return View(AllStaff);
        }

        public ActionResult Create()
        {
            ViewBag.StafftDetails = ecomContext.Branches;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff staff)
        {
           // ViewBag.StafftDetails = ecomContext.Staffs;
            ecomContext.Staffs.Add(staff);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Staff staff = ecomContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(staff);
        }

        public ActionResult Edit(String id)
        {
            Staff staff = ecomContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ViewBag.BranchDetails = new SelectList(ecomContext.Branches, "BranchNo", "Street");
            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(String id, Staff updatedstaff)
        {
            Staff staff = ecomContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            staff.StaffNo = updatedstaff.StaffNo;
            staff.Fname = updatedstaff.Fname;
            staff.Lname = updatedstaff.Lname;
            staff.Position = updatedstaff.Position;
            staff.DOB = updatedstaff.DOB;
            staff.Salary = updatedstaff.Salary;
            staff.BranchNoRef = updatedstaff.BranchNoRef;
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Staff employee = ecomContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteEmployee(String id)
        {
            Staff staff = ecomContext.Staffs.SingleOrDefault(x => x.StaffNo == id);
            ecomContext.Staffs.Remove(staff);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}