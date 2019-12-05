using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Invoice")]
    public class Invoice
    {
        [Key]
        [Required]
        [Display(Name = "Invoice ID")]
        public int Invoice_ID { get; set; }
        [Display(Name = "Customer ID")]
        public int Customer_ID { get; set; }
        [Display(Name = "Payment Due")]
        public string Payment_Due { get; set; }
        [Display(Name = "Early Payment")]
        public string Early_Payment { get; set; }
        [Display(Name = "Early Discount")]
        public double Early_Discount { get; set; }
        [Display(Name = "Total Cost")]
        public double Total_Cost { get; set; }
    }
}