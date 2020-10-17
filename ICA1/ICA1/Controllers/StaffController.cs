﻿using ICA1.Models;
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
            ViewBag.staffDetails = staffContext.Staffs;
            //ViewBag.staffDetails = new SelectList(staffContext.Staffs, "StaffNo", "RefBranchNo");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            ViewBag.staffDetails = staffContext.Staffs;
            staffContext.Staffs.Add(staff);
            staffContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(String id)
        {
            Staff staff = staffContext.Staffs.SingleOrDefault(x=>x.StaffNo==id);
            return View(staff);
        }

    }
}