using ICA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA1.Controllers
{
    public class RentController : Controller
    {
        // GET: Rent
        private Context rentConext = new Context();
        public ActionResult Index()
        {
            List<Rent> AllRent = rentConext.Rents.ToList();
            return View(AllRent);
        }
        public ActionResult Create()
        {
            ViewBag.staffDetails = rentConext.Staffs;
            ViewBag.branchDetails = rentConext.Branches;
            ViewBag.ownerDetails = rentConext.Owners;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Rent rent)
        {
            ViewBag.staffDetails = rentConext.Staffs;
            ViewBag.branchDetails = rentConext.Branches;
            ViewBag.ownerDetails = rentConext.Owners;
            rentConext.Rents.Add(rent);
            rentConext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String Id)
        {
            Rent rent = rentConext.Rents.SingleOrDefault(x => x.PropertyNo == Id);
            return View(rent);
        }
        public ActionResult Edit(String Id)
        {

            ViewBag.staffDetails = rentConext.Staffs;
            ViewBag.branchDetails = rentConext.Branches;
            ViewBag.ownerDetails = rentConext.Owners;
            Rent rent = rentConext.Rents.SingleOrDefault(x => x.PropertyNo == Id);
            return View(rent);
        }
        [HttpPost]
        public ActionResult Edit(String Id,Rent updatedRent)
        {

            ViewBag.staffDetails = rentConext.Staffs;
            ViewBag.branchDetails = rentConext.Branches;
            ViewBag.ownerDetails = rentConext.Owners;
            Rent rent = rentConext.Rents.SingleOrDefault(x => x.PropertyNo == Id);
            rent.PropertyNo = updatedRent.PropertyNo;
            rent.Street = updatedRent.Street;
            rent.City = updatedRent.City;
            rent.Ptype = updatedRent.Ptype;
            rent.Rooms = updatedRent.Rooms;
            rent.Rents = updatedRent.Rents;
            rentConext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(String Id)
        {
            Rent rent = rentConext.Rents.SingleOrDefault(x => x.PropertyNo == Id);
            return View(rent);
        }
        [HttpPost,ActionName("Index")]
        public ActionResult DeleteRent(String Id)
        { 
            Rent rent = rentConext.Rents.SingleOrDefault(x => x.PropertyNo == Id);
            rentConext.Rents.Remove(rent);
            rentConext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}