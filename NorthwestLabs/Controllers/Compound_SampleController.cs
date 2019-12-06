//NOT USED, CREATED TO COPY FUNCTIONS AND CSHTML VIEWS
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthwestLabs.DAL;
using NorthwestLabs.Models;

namespace NorthwestLabs.Controllers
{
    public class Compound_SampleController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: Compound_Sample
        public ActionResult Index()
        {
            return View(db.Compound_Sample.ToList());
        }

        // GET: Compound_Sample/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound_Sample compound_Sample = db.Compound_Sample.Find(id);
            if (compound_Sample == null)
            {
                return HttpNotFound();
            }
            return View(compound_Sample);
        }

        // GET: Compound_Sample/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compound_Sample/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Compound_Sample_ID,LT_Number,Compound_Sequence_Code,Compound_Name,Employee_ID,Appearance,Weight,Weight_Unit,Molecular_Mass,MTD,MTD_Units,Test_Date_Time,Pass_Fail,Quantitative_Data,Qualitative_Data")] Compound_Sample compound_Sample)
        {
            if (ModelState.IsValid)
            {
                db.Compound_Sample.Add(compound_Sample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compound_Sample);
        }

        // GET: Compound_Sample/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound_Sample compound_Sample = db.Compound_Sample.Find(id);
            if (compound_Sample == null)
            {
                return HttpNotFound();
            }
            return View(compound_Sample);
        }

        // POST: Compound_Sample/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Compound_Sample_ID,LT_Number,Compound_Sequence_Code,Compound_Name,Employee_ID,Appearance,Weight,Weight_Unit,Molecular_Mass,MTD,MTD_Units,Test_Date_Time,Pass_Fail,Quantitative_Data,Qualitative_Data")] Compound_Sample compound_Sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compound_Sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compound_Sample);
        }

        // GET: Compound_Sample/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound_Sample compound_Sample = db.Compound_Sample.Find(id);
            if (compound_Sample == null)
            {
                return HttpNotFound();
            }
            return View(compound_Sample);
        }

        // POST: Compound_Sample/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compound_Sample compound_Sample = db.Compound_Sample.Find(id);
            db.Compound_Sample.Remove(compound_Sample);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
