using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [Display(Name = "Order ID")]
        public int Order_ID { get; set; }

        [Display(Name = "Customer ID")]
        public int Customer_ID { get; set; }

        [Display(Name = "Order Date")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Order_Date { get; set; }

        [Display(Name = "Desired Number of Samples")]
        public int Number_Of_Samples { get; set; }

        [Display(Name = "Date Received")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Date_Received { get; set; }

        [Display(Name = "Due Date")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Date_Due { get; set; }

        [Display(Name = "Order Rerun Date")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string  Order_Rerun_Date { get; set; }

        [Display(Name = "Order Complete Date")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Order_Complete_Date { get; set; }

        [Display(Name = "Price Quote")]
        public double Order_Quote { get; set; }

        [Display(Name = "Order Comments")]
        [StringLength(100, ErrorMessage = "Cannot exceed 100 characters")]
        public string Order_Comments { get; set; }

        [Display(Name = "Summary Report")]
        public string Summary_Report { get; set; }

        [Display(Name = "Data Report")]
        public string Data_Report { get; set; }
    }
}