using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public string Location_ID { get; set; }
        [Display(Name = "Location")]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Location_Name { get; set; }
    }
}