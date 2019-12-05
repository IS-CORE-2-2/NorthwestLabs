using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Order_Compound")]
    public class Order_Compound
    {
        [Key]
        [Required]
        public int Order_Compound_ID { get; set; }
        [Display(Name = "Order ID")]
        public int Order_ID { get; set; }
        [Display(Name = "Test Number")]
        public int LT_Number { get; set; }
    }
}