using sample_e_commerce_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample_e_commerce_application.Controllers
{
    public class OwnerController : Controller
    {
        private EcomContext ecomContext = new EcomContext();
        // GET: Owner
        public ActionResult Index()
        {
            List<Owner> AllOwners = ecomContext.Owners.ToList();
            return View(AllOwners);
        }

        public ActionResult Create()
        {
            ViewBag.OwnerDetails = ecomContext.Owners;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Owner Owner)
        {
            
            ecomContext.Owners.Add(Owner);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Owner owner = ecomContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        public ActionResult Edit(String id)
        {
            Owner owner = ecomContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            //ViewBag.DeptDetails = new SelectList(ecomContext.Owners, "DeptId", "Name");
            return View(owner);
        }
        [HttpPost]
        public ActionResult Edit(String id, Owner updatedOwner)
        {
            Owner owner = ecomContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            owner.OwnerNo = updatedOwner.OwnerNo;
            owner.Fname = updatedOwner.Fname;
            owner.Lname = updatedOwner.Lname;
            owner.Address = updatedOwner.Address;
            owner.TelNo = updatedOwner.TelNo;

            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String id)
        {
            Owner owner = ecomContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteEmployee(String id)
        {
            Owner owner = ecomContext.Owners.SingleOrDefault(x => x.OwnerNo == id);
            ecomContext.Owners.Remove(owner);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}