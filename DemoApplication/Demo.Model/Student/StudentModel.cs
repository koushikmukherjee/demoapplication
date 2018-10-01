using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Demo.Entity;
using Demo.Service;
using System.Web.Mvc;
using Demo.Utility;

namespace Demo.Model
{
    public class StudentModel
    {
        
        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please provide proper email address")]
        [Remote("CheckDuplicateEmail", "Student", AdditionalFields = "UserID", ErrorMessage = "Email address already exists.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mobile number is required.")]
        [Display(Name = "Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Mobile number should contain only numbers")]
        [Remote("CheckDuplicateMobile", "Student",AdditionalFields = "UserID", ErrorMessage = "Mobile number already exists.")]
        public string Mobile { get; set; }

        public Guid UserID { get; set; }

        public bool? isDeleted { get; set; }

        public List<Student> lstStudent { get; set; }

    }
}
