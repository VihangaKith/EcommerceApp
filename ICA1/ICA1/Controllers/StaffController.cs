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
            List<Staff> distictPosition = staffContext.Staffs.GroupBy(x => x.Position).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.Position = new SelectList(distictPosition, "Position", "Position");
            return View(AllStaff);
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            List<Staff> distictPosition = staffContext.Staffs.GroupBy(x => x.Position).Select(x => x.FirstOrDefault()).ToList();
            ViewBag.Position = new SelectList(distictPosition, "Position", "Position");

            String pos = form["PosDropDown"]?.ToString();

            if (pos == null)
            {
                List<Staff> filterStaff = staffContext.Staffs.ToList();
                return View(filterStaff);
            }
            else
            {
                List<Staff> filterStaff = staffContext.Staffs.Where(x => x.Position == pos).ToList();
                return View(filterStaff);
            }
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