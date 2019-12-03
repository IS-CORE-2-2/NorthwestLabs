using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Compound_Sample")]
    public class Compound_Sample
    {
        [Key]
        public int LT_Number { get; set; }
        [Key]
        [Display(Name = "Compound Sequence Code")]
        public int Compound_Sequence_Code { get; set; }
        [Display(Name = "Compound Name")]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Compound_Name { get; set; }
        [Display(Name = "Employee_ID")]
        public int Employee_ID { get; set; }
        [Display(Name = "Appearance")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Appearance { get; set; }
        [Display(Name = "Weight")]
        public float Weight { get; set; }
        [Display(Name = "Weight Units")]
        [StringLength(5, ErrorMessage = "Cannot exceed 5 characters")]
        public string Weight_Unit { get; set; }
        [Display(Name = "Molecular Mass")]
        public float Molecular_Mass { get; set; }
        [Display(Name = "Maximum Tolerated Dose")]
        public float MTD { get; set; }
        [Display(Name = "Maximum Tolerated Dose Units")]
        [StringLength(5, ErrorMessage = "Cannot exceed 5 characters")]
        public string MTD_Units { get; set; }
        [Display(Name = "Test Date and Time")]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Test_Date_Time { get; set; }
        [Display(Name = "Pass/Fail")]
        [StringLength(1, ErrorMessage = "Cannot exceed 1 character")]
        public string Pass_Fail { get; set; }
        [Display(Name = "Quantitative Data")]
        [StringLength(1000, ErrorMessage = "Cannot exceed 1000 characters")]
        public string Quantitative_Data { get; set; }
        [Display(Name = "Qualitative Data")]
        [StringLength(1000, ErrorMessage = "Cannot exceed 1000 characters")]
        public string Qualitative_Data { get; set; }
    }
}