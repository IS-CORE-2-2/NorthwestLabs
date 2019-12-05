using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        [Required]
        [Display(Name = "Material ID")]
        public int Material_ID { get; set; }
        [Display(Name = "Material Name")]
        public string Material_Name { get; set; }
        [Display(Name = "Material Quantity")]
        public double Material_Quantity { get; set; }
        [Display(Name = "Material Unit")]
        public string Quantity_Unit { get; set; }
        [Display(Name = "Material Cost")]
        public double Material_Cost { get; set; }
        [Display(Name = "Minimum Req. on Hand")]
        public double Min_On_Hand { get; set; }
    }
}