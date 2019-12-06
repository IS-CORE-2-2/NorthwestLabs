/*
 *  CUSTOMER CONTROLLER, CONTROLS ALL ROUTES FOR CUTOMER PORTAL
 *  LAST EDITED 12/5/2019
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NorthwestLabs.DAL;
using NorthwestLabs.Models;

namespace NorthwestLabs.Controllers
{
    public class CustomersController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext(); //db variable
        public static int currentCustomer = 0; //this is to keep track of the current customer's ID

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();

            var dbEmail = db.Customer.Where(s => s.Customer_Email == email).FirstOrDefault<Customer>();
            
            string testEmail = dbEmail.Customer_Email;
            string testPass = dbEmail.Customer_Password;

            if (testEmail == email && testPass == password)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                CustomersController.currentCustomer = dbEmail.Customer_ID; //This is to grab the current customer's id and load their personal info
                return RedirectToAction("Customer_Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ListCustomers()
        {
            return View(db.Customer.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details()
        {
            int id = CustomersController.currentCustomer;
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Order_Details(int? id)
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

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_ID,Customer_Last_Name,Customer_First_Name,Customer_Address_1,Customer_Address_2,Customer_City,Customer_State,Customer_Zipcode,Customer_Home_Phone,Customer_Cell_Phone,Customer_Email,Customer_Password,Customer_Payment_Info,Customer_Discount,Customer_Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

 

        // GET: Customers/Edit/5
        public ActionResult Edit()
        {
            int id = CustomersController.currentCustomer;

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
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
        public ActionResult Edit([Bind(Include = "Customer_ID,Customer_Last_Name,Customer_First_Name,Customer_Address_1,Customer_Address_2,Customer_City,Customer_State,Customer_Zipcode,Customer_Home_Phone,Customer_Cell_Phone,Customer_Email,Customer_Password,Customer_Payment_Info,Customer_Discount,Customer_Balance")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Customer_Home");
            }
            return View(customer);
        }

        public ActionResult Create_Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Order([Bind(Include = "Order_ID,Number_Of_Samples,Date_Due,Order_Comments")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.Order_Date = DateTime.Now.ToString();
                order.Customer_ID = CustomersController.currentCustomer;
                db.Order.Add(order);
                db.SaveChanges();
                return RedirectToAction("Shipping_Info");
            }

            return View(order);
        }

        public ActionResult Shipping_Info()
        {
            return View();
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult View_Orders()
        {
            var orders = db.Database.SqlQuery<Order>("SELECT * FROM [Order] WHERE Customer_ID = " + CustomersController.currentCustomer).ToList<Order>();
            return View(orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Customer_Home()
        {
            return View();
        }

        public ActionResult View_Info()
        {
            return View();
        }


        public ActionResult View_Invoices()
        {
            var Customer_Invoices = db.Database.SqlQuery<Invoice>("SELECT * FROM [Invoice] WHERE Customer_ID = " + CustomersController.currentCustomer).ToList<Invoice>();
            return View(Customer_Invoices);
        }
    }
}
