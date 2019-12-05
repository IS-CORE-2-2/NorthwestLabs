using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Employee_ID { get; set; }
        [Display(Name = "Location")]
        public string Location_ID { get; set; }
        [Display(Name = "Access Level")]
        public int Employee_Access_Level { get; set; }
        [Display(Name = "Employee Last Name")]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Employee_Last_Name { get; set; }
        [Display(Name = "Employee First Name")]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Employee_First_Name { get; set; }
        [Display(Name = "Employee Email")]
        [StringLength(50, ErrorMessage = "Cannot exceed 50 characters")]
        public string Employee_Email{ get; set; }
        [Display(Name = "Employee Password")]
        [StringLength(25, ErrorMessage = "Cannot exceed 25 characters")]
        public string Employee_Password { get; set; }
        [Display(Name = "Employee Position")]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string Employee_Position { get; set; }
    }
}