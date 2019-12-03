using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Test_Tube")]
    public class Test_Tube
    {
        [Key]
        [Required]
        [DisplayName("Test Tube ID")]
        public int Test_Tube_ID { get; set; }
        public string Concentration { get; set; }
        [Required]
        [DisplayName("Assay ID")]
        public int Assay_ID { get; set; }
        [DisplayName("LT Number")]
        [Required]
        public int LT_Number { get; set; }
    }
}