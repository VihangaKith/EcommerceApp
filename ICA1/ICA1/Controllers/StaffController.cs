using ICA1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ICA1.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private Context staffContext = new Context();
        public ActionResult Index()
        {
            List<Staff> AllStaff = staffContext.Staffs.ToList();
            return View(AllStaff);
        }
        public ActionResult Create()
        {
            ViewBag.branchDetails = staffContext.Branches;
            //ViewBag.staffDetails = new SelectList(staffContext.Staffs, "StaffNo", "RefBranchNo");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            ViewBag.branchDetails = staffContext.Branches;
            staffContext.Staffs.Add(staff);
            staffContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String id)
        {
            Staff staff = staffContext.Staffs.SingleOrDefault(x=>x.StaffNo==id);
            return View(staff);
        }
        public ActionResult Edit(String Id)
        {
            ViewBag.branchDetails = staffContext.Branches;
            Staff staff = staffContext.Staffs.SingleOrDefault(x => x.StaffNo == Id);
            return View(staff);
        }
        [HttpPost]
        public ActionResult Edit(String Id,Staff updatedStaff)
        {
            ViewBag.branchDetails = staffContext.Branches;
            Staff staff = staffContext.Staffs.SingleOrDefault(x => x.StaffNo == Id);
            staff.StaffNo = updatedStaff.StaffNo;
            staff.Fname = updatedStaff.Fname;
            staff.Lname = updatedStaff.Lname;
            staff.Position = updatedStaff.Position;
            staff.DateofBirth = updatedStaff.DateofBirth;
            staff.Salary = updatedStaff.Salary;
            staffContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(String Id)
        {
            Staff staff = staffContext.Staffs.SingleOrDefault(x => x.StaffNo == Id);
            return View(staff);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult Deletetaff(String Id)
        {
            Staff staff = staffContext.Staffs.SingleOrDefault(x => x.StaffNo == Id);
            staffContext.Staffs.Remove(staff);
            staffContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}