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
            var New_Orders = db.Database.SqlQuery<Order>("SELECT * FROM [Order] WHERE Order_Quote IS NOT NULL AND Summary_Report IS NULL ").ToList<Order>();
            return View(New_Orders);
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
                string Today = DateTime.Now.ToString();
                order.Order_Complete_Date = Today;
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return View("Added_Report");
            }
            return View(order);
        }

        // GET: Orders
        public ActionResult Show_Completed_Orders()
        {
            var New_Orders = db.Database.SqlQuery<Order>("SELECT * FROM [Order] WHERE Order_Complete_Date IS NOT NULL AND Invoice_Created IS NULL").ToList<Order>();
            return View(New_Orders);
        }

        public ActionResult Create_Invoice(int? id)
        {
            //find order info
            var dbOrder = db.Order.Where(s => s.Order_ID == id).FirstOrDefault<Order>();
            int customer = dbOrder.Customer_ID;
            double quote = dbOrder.Order_Quote;

            //find customer info
            var dbOrder_Customer = db.Customer.Where(s => s.Customer_ID == customer).FirstOrDefault<Customer>();
            double cust_Discount = dbOrder_Customer.Customer_Discount;
            double early_Discount = 0.05;

            //calc estimated invoice
            double order_Total = quote * (1 - cust_Discount) * (1 - early_Discount);

            //insert into invoice
            db.Database.ExecuteSqlCommand("UPDATE [Order] SET Invoice_Created = 'Y' WHERE Order_ID = " + id);
            db.Database.ExecuteSqlCommand("INSERT INTO Invoice (Customer_ID, Early_Discount, Total_Cost) VALUES(" + customer + ", " + early_Discount + ", " + order_Total + ")");
            return RedirectToAction("Show_Completed_Orders");
        }

        public ActionResult Show_Unapproved_Invoices()
        {
            var New_Invoices = db.Database.SqlQuery<Invoice>("SELECT * FROM [Invoice] WHERE Payment_Due IS NULL").ToList<Invoice>();
            return View(New_Invoices);
        }

        // GET: Invoices/Edit/5
        public ActionResult Approve_Invoice(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoice.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Approve_Invoice([Bind(Include = "Invoice_ID,Customer_ID,Payment_Due,Early_Payment,Early_Discount,Total_Cost")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Show_Unapproved_Invoices");
            }
            return View(invoice);
        }

        public ActionResult View_Assays()
        {
            return View(db.Assay.ToList());
        }

        // GET: Assays/Details/5
        public ActionResult Assay_Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assay.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // GET: Assays/Create
        public ActionResult Create_Assay()
        {
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Assay([Bind(Include = "Assay_ID,Assay_Name,Base_Cost,Assay_Description")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                db.Assay.Add(assay);
                db.SaveChanges();
                return View("Assay_Created");
            }

            return View(assay);
        }

        // GET: Assays/Edit/5
        public ActionResult Edit_Assay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assay assay = db.Assay.Find(id);
            if (assay == null)
            {
                return HttpNotFound();
            }
            return View(assay);
        }

        // POST: Assays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Assay([Bind(Include = "Assay_ID,Assay_Name,Base_Cost,Assay_Description")] Assay assay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assay).State = EntityState.Modified;
                db.SaveChanges();
                return View("Assay_Edited");
            }
            return View(assay);
        }

    }
}