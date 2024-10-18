using CoffeeShop.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{

	public class StaffModel
	{
        #region Fields

        private string staffID;
        private string staffName;
        private int phoneNumber;
        private DateTime dateOfBirth;
        private string email;
        private string role;
        private Gender gender;

        #endregion

        #region Properties 

        [DisplayName("Staff ID")]
        public string StaffID { get { return staffID; } set { staffID = value; } }
        
        [DisplayName("Staff Name")]
        [Required(ErrorMessage ="Staff name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Staff name must be between 5 and 50 characters")]
        public string StaffName { get { return staffName; } set { staffName = value; } }


        [DisplayName("Phone Number")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Staff name must be between 5 and 50 characters")]
        public int PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage ="Date is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }

        [DisplayName("Email")]
        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get { return email; } set { email = value; } }

        [DisplayName("Role")]
        [Required(ErrorMessage ="Role is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage ="Role must be between 5 and 20 characters")]
        public string Role { get { return role; } set { role = value; } }

        [DisplayName("Gender")]
        [Required(ErrorMessage ="Gender is required")]
        public Gender Gender { get { return gender; } set { gender = value; } }

        #endregion
    }
}
