using ICA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA1.Controllers
{
    public class OwnerController : Controller
    {
        // GET: Owner
        private Context iContex = new Context();
        public ActionResult Index()
        {
            List<Owner> AllOwners = iContex.Owners.ToList();
            return View(AllOwners);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            iContex.Owners.Add(owner);
            iContex.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String Id)
        {
            Owner owner = iContex.Owners.SingleOrDefault(x=>x.OwnerNumber==Id);
            return View(owner);
        }
        public ActionResult Edit(String Id)
        {
            Owner owner = iContex.Owners.SingleOrDefault(x => x.OwnerNumber == Id);
            return View(owner);
        }
        [HttpPost]
        public ActionResult Edit(String Id,Owner UpdatedOwner)
        {
            Owner owner = iContex.Owners.SingleOrDefault(x => x.OwnerNumber == Id);
            owner.OwnerNumber = UpdatedOwner.OwnerNumber;
            owner.Fname = UpdatedOwner.Fname;
            owner.Lname = UpdatedOwner.Lname;
            owner.Address = UpdatedOwner.Address;
            owner.TelNo = UpdatedOwner.TelNo;
            iContex.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(String Id)
        {
            Owner owner = iContex.Owners.SingleOrDefault(x => x.OwnerNumber == Id);
            return View(owner);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteOwner(String Id)
        {
            Owner owner = iContex.Owners.SingleOrDefault(x => x.OwnerNumber == Id);
            iContex.Owners.Remove(owner);
            iContex.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}