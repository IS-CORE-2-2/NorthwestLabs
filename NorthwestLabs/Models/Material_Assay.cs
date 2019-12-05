using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Material_Assay")]
    public class Material_Assay
    {
        [Key]
        [Required]
        public int Material_Assay_ID { get; set; }
        [Required]
        [Display(Name = "Assay ID")]
        public int Assay_ID { get; set; }
        [Required]
        [Display(Name = "Material ID")]
        public int Material_ID { get; set; }
        [Display(Name = "Quantity per assay")]
        public double Quantity_Per_Assay { get; set; }
    }
}