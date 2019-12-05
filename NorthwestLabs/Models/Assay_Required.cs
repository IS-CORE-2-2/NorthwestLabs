using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Assay_Required")]
    public class Assay_Required
    {
        [Key]
        [Required]
        [DisplayName("Assay Required ID")]
        public int Assay_Required_ID { get; set; }
        [Required]
        [DisplayName("Assay ID")]
        public int Assay_ID { get; set; }
        [Required]
        [DisplayName("Required Test ID")]
        public string Required_Test_ID { get; set; }
    }
}