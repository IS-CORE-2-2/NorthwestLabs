using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace NorthwestLabs.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [Required]
        [Display(Name = "Customer ID")]
        public int Customer_ID { get; set; }
        [StringLength(15, ErrorMessage = "This field has a maximum of 15 characters.")]
        [Display(Name = "Customer Last Name")]
        public string Customer_Last_Name { get; set; }
        [StringLength(15, ErrorMessage = "This field has a maximum of 15 characters.")]
        [Display(Name = "Customer First Name")]
        public string Customer_First_Name { get; set; }
        [StringLength(50, ErrorMessage = "This field has a maximum of 50 characters.")]
        [Display(Name = "Address (Line 1)")]
        public string Customer_Address_1 { get; set; }
        [StringLength(20, ErrorMessage = "This field has a maximum of 20 characters.")]
        [Display(Name = "Address (Line 2)")]
        public string Customer_Address_2 { get; set; }
        [StringLength(20, ErrorMessage = "This field has a maximum of 20 characters.")]
        [Display(Name = "City")]
        public string Customer_City { get; set; }
        [StringLength(15, ErrorMessage = "This field has a maximum of 15 characters.")]
        [Display(Name = "State")]
        public string Customer_State { get; set; }
        [StringLength(6, ErrorMessage = "This field has a maximum of 6 characters.")]
        [Display(Name = "Zipcode")]
        public string Customer_Zipcode { get; set; }
        [StringLength(15, ErrorMessage = "This field has a maximum of 15 characters.")]
        [Display(Name = "Home Phone")]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Phone number should contain only numbers")]
        public string Customer_Home_Phone { get; set; }
        [StringLength(15, ErrorMessage = "This field has a maximum of 15 characters.")]
        [Display(Name = "Cell Phone")]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Phone number should contain only numbers")]
        public string Customer_Cell_Phone { get; set; }
        [StringLength(40, ErrorMessage = "This field has a maximum of 40 characters.")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Address")]
        public string Customer_Email { get; set; }
        [StringLength(25, ErrorMessage = "This field has a maximum of 25 characters.")]
        [Display(Name = "Password")]
        public string Customer_Password { get; set; }
        [StringLength(50, ErrorMessage = "This field has a maximum of 50 characters.")]
        [Display(Name = "Payment Info")]
        public string Customer_Payment_Info { get; set; }
        [Display(Name = "Customer Discount")]
        public string Customer_Discount { get; set; }
        [Display(Name = "Customer Balance")]
        public string Customer_Balance { get; set; }
        [StringLength(1, ErrorMessage = "This field has a maximum of 1 character.")]
        [Display(Name = "Requested Physical Copy?")]
        public char Physical_Copy { get; set; }
    }
}