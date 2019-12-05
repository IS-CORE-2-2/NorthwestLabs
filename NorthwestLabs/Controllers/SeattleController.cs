using NorthwestLabs.DAL;
using NorthwestLabs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NorthwestLabs.Controllers
{
    public class SeattleController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Add_Customer()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Customer([Bind(Include = "Customer_ID,Customer_Last_Name,Customer_First_Name,Customer_Address_1,Customer_Address_2,Customer_City,Customer_State,Customer_Zipcode,Customer_Home_Phone,Customer_Cell_Phone,Customer_Email,Customer_Password,Customer_Payment_Info,Customer_Discount,Customer_Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        public ActionResult View_Customers()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customers/Edit/5
        public ActionResult Edit_Customer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Customer([Bind(Include = "Customer_ID,Customer_Last_Name,Customer_First_Name,Customer_Address_1,Customer_Address_2,Customer_City,Customer_State,Customer_Zipcode,Customer_Home_Phone,Customer_Cell_Phone,Customer_Email,Customer_Password,Customer_Payment_Info,Customer_Discount,Customer_Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Orders
        public ActionResult View_Orders()
        {
            return View(db.Order.ToList());
        }


        // GET: Orders/Details/5
        public ActionResult View_Details(int? id)
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

        // GET: 
        public ActionResult Add_Report(int? id)
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

        // POST: 
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add_Report([Bind(Include = "Order_ID,Customer_ID,Order_Date,Date_Received,Due_Date,Order_Rerun_Date,Order_Complete_Date,Order_Comments,Summary_Report,Data_Report")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return View("Added_Report");
            }
            return View(order);
        }
    }
}