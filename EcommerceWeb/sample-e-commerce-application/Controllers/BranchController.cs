using sample_e_commerce_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample_e_commerce_application.Controllers
{
    public class BranchController : Controller
    {
        private EcomContext ecomContext = new EcomContext();
        // GET: Owner
        public ActionResult Index()
        {
            List<Branch> AllBranch = ecomContext.Branches.ToList();
            return View(AllBranch);
        }

        public ActionResult Create()
        {
            ViewBag.BranchDetails = ecomContext.Branches;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Branch branch)
        {

            ecomContext.Branches.Add(branch);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Branch branch = ecomContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        public ActionResult Edit(String id)
        {
            Branch branch = ecomContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            //ViewBag.DeptDetails = new SelectList(ecomContext.Owners, "DeptId", "Name");
            return View(branch);
        }
        [HttpPost]
        public ActionResult Edit(String id, Branch updatedBrach)
        {
            Branch branch = ecomContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            branch.BranchNo = updatedBrach.BranchNo;
            branch.Street = updatedBrach.Street;
            branch.City = updatedBrach.City;
            branch.PostCode = updatedBrach.PostCode;
           

            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Branch branch = ecomContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteEmployee(String id)
        {
            Branch branch = ecomContext.Branches.SingleOrDefault(x => x.BranchNo == id);
            ecomContext.Branches.Remove(branch);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Branch()
        {
            List<Branch> AllBranch = ecomContext.Branches.ToList();
            return View(AllBranch);
        }

        public ActionResult Branch1(String id)
        {
            // List<Rent> rent = ecomContext.Rents.Where(x => x.BranchNoRef == id).ToList();

            var rent = ecomContext.Rents.Where(x => x.BranchNoRef == id).ToList().Count();
            ViewBag.count = rent;
            return View();
        }
    }
}