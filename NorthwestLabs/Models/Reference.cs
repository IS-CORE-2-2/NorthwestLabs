using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Reference")]
    public class Reference
    {
        [Key]
        [Display(Name = "Reference ID")]
        public int Reference_ID { get; set; }
        [Display(Name = "Assay ID")]
        public int Assay_ID { get; set; }
        [Display(Name = "Literature Reference")]
        public string Literature_Reference { get; set; }
    }
}