using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NorthwestLabs.Controllers
{
    public class SingaporeController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();
        
        public static int New_LT_Number = 111111;

        // GET: Singapore
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult View_New_Orders()
        {
            var New_Orders = db.Database.SqlQuery<Order>("SELECT * FROM [Order] WHERE Date_Received IS NULL").ToList<Order>();
            return View(New_Orders);
        }

        public ActionResult Create_New_LT(int id)
        {
            db.Database.ExecuteSqlCommand("INSERT INTO Order_Compound Values (" + id + ", " + New_LT_Number + ")");
            string Today = DateTime.Now.ToString();
            db.Database.ExecuteSqlCommand("UPDATE [Order] SET Date_Received = '" + Today + "' WHERE Order_ID = " + id);
            New_LT_Number += 1;
            return RedirectToAction("Add_Compound_Details");
        }

        // GET: Orders/Edit/5
        public ActionResult Add_Price_Quote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Price_Quote([Bind(Include = "Order_ID,Customer_ID,Order_Date,Date_Received,Due_Date,Order_Rerun_Date,Order_Complete_Date,Order_Comments,Order_Quote,Summary_Report,Data_Report")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return View("Added_Price_Quote");
            }
            return View(order);
        }

        // GET: Compound_Sample/Create
        public ActionResult Add_Compound_Details()
        {
            return View();
        }

        // POST: Compound_Sample/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Compound_Details([Bind(Include = "Compound_Sequence_Code,Compound_Name,Appearance,Weight,Weight_Unit,Molecular_Mass,MTD,MTD_Units")] Compound_Sample compound_Sample)
        {
            if (ModelState.IsValid)
            {
                compound_Sample.LT_Number = New_LT_Number;
                compound_Sample.Employee_ID = EmployeesController.Current_Employee_ID;
                db.Compound_Sample.Add(compound_Sample);
                db.SaveChanges();
                return View("Created_Compound");
            }

            return View(compound_Sample);
        }

        public ActionResult Schedule_Test()
        {
            var Unscheduled_Orders = db.Database.SqlQuery<Compound_Sample>("SELECT * FROM [Compound_Sample] WHERE Test_Date_Time IS NULL").ToList<Compound_Sample>();
            return View(Unscheduled_Orders);
        }
        
        // GET: Compound_Sample/Edit/5
        public ActionResult Add_Test_Date(int? id)
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
        public ActionResult Add_Test_Date([Bind(Include = "Compound_Sample_ID,LT_Number,Compound_Sequence_Code,Compound_Name,Employee_ID,Appearance,Weight,Weight_Unit,Molecular_Mass,MTD,MTD_Units,Test_Date_Time,Pass_Fail,Quantitative_Data,Qualitative_Data")] Compound_Sample compound_Sample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compound_Sample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Added_Test_Date");
            }
            return View(compound_Sample);
        }

        // GET: Test_Tube/Create
        public ActionResult Label_Tubes()
        {
            //List<Assay> Assay_Names = db.Database.SqlQuery<Assay>("SELECT * FROM [Assay]").ToList<Assay>();
            
            ViewBag.Assay_Names = db.Assay.ToList();
            return View();
        }

        // POST: Test_Tube/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Label_Tubes([Bind(Include = "Test_Tube_ID,Concentration,Assay_Ident,LT_Number")] Test_Tube test_Tube)
        {
            if (ModelState.IsValid)
            {
                db.Test_Tube.Add(test_Tube);
                db.SaveChanges();
                return RedirectToAction("Tubes_Labeled");
            }

            return View(test_Tube);
        }

        public ActionResult Finish_Test()
        {
            var Unscheduled_Orders = db.Database.SqlQuery<Compound_Sample>("SELECT * FROM [Compound_Sample] WHERE Pass_Fail IS NULL").ToList<Compound_Sample>();
            return View(Unscheduled_Orders);
        }


        // GET: Compound_Sample/Edit/5
        public ActionResult Input_Results(int? id)
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
        public ActionResult Input_Results([Bind(Include = "Compound_Sample_ID,LT_Number,Compound_Sequence_Code,Compound_Name,Employee_ID,Appearance,Weight,Weight_Unit,Molecular_Mass,MTD,MTD_Units,Test_Date_Time,Pass_Fail,Quantitative_Data,Qualitative_Data")] Compound_Sample compound_Sample)
        {
            ////HERE
            if (ModelState.IsValid)
            {
                db.Entry(compound_Sample).State = EntityState.Modified;
                db.SaveChanges();
                return View("Results_Inputted");
            }
            return View(compound_Sample);
        }
    }
}