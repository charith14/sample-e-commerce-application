using sample_e_commerce_application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace sample_e_commerce_application.Controllers
{
    public class RentController : Controller
    {
        private EcomContext ecomContext = new EcomContext();
        // GET: Rent
        public ActionResult Index()
        {
            List<Rent> rent = ecomContext.Rents.ToList();
            return View(rent);
        }

        public ActionResult Create()
        {
            ViewBag.BranchDetails = ecomContext.Branches;
            ViewBag.StaffDetails = ecomContext.Staffs;
            ViewBag.OwnerDetails = ecomContext.Owners;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Rent rent)
        {
           
            ecomContext.Rents.Add(rent);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(String id)
        {
            Rent rent = ecomContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        public ActionResult Delete(String id)
        {
            Rent rent = ecomContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            return View(rent);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteEmployee(String id)
        {
            Rent rent = ecomContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            ecomContext.Rents.Remove(rent);
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(String id)
        {
            Rent rent = ecomContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            ViewBag.BranchDetails = new SelectList(ecomContext.Branches, "BranchNo", "Street");
            ViewBag.StaffDetails = new SelectList(ecomContext.Staffs, "StaffNo", "Fname");
            ViewBag.OwnerDetails = new SelectList(ecomContext.Owners, "OwnerNo", "Fname");
            return View(rent);
        }

        [HttpPost]
        public ActionResult Edit(String id, Rent updatedstaff)
        {
            Rent rent = ecomContext.Rents.SingleOrDefault(x => x.PropertyNo == id);
            rent.PropertyNo = updatedstaff.PropertyNo;
            rent.Street = updatedstaff.Street;
            rent.City = updatedstaff.City;
            rent.Ptype = updatedstaff.Ptype;
            rent.Rooms = updatedstaff.Rooms;
            rent.Rent1 = updatedstaff.Rent1;
            rent.BranchNoRef = updatedstaff.BranchNoRef;
            rent.StaffNoRef = updatedstaff.StaffNoRef;
            rent.OwnerNoRef = updatedstaff.OwnerNoRef;
            ecomContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult city()
        {

            var Allcity = ecomContext.Rents.ToList();


            int x = 0;
            int y = 0;


            foreach (Rent rent in Allcity)
            {
                x = x + 1;

            }

            string[] pos = new string[x];

            foreach (Rent rent in Allcity)
            {
                pos[y] = rent.City;
                y = y + 1;

            }

            var distinctArray = pos.Distinct().ToArray();
            ViewBag.city = distinctArray;


            return View();
        }

        public ActionResult city1(string cy)
        {
            List<Rent> rent = ecomContext.Rents.Where(x => x.City == cy).ToList();
            return View(rent);
        }
    }
}