using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        [Required]
        [DisplayName("Assay ID")]
        public int Assay_ID { get; set; }
        [Required]
        [DisplayName("Assay Name")]
        public string Assay_Name { get; set; }
        [DisplayName("Base Cost")]
        public double Base_Cost { get; set; }
        [DisplayName("Description")]
        public string Assay_Description { get; set; }
    }
}