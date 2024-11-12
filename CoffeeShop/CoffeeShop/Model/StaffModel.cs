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
        private string phoneNumber;
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
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Name can't contain number or special characters")]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Staff name must be between 5 and 50 characters")]
        public string StaffName { get { return staffName; } set { staffName = value; } }


        [DisplayName("Phone Number")]
        [RegularExpression("([0-9]+)", ErrorMessage ="This must be number")]
        [StringLength(12, MinimumLength = 10, ErrorMessage ="Phone number must be between 10 and 12 digits")]
        public string PhoneNumber { get { return phoneNumber; } set { phoneNumber = value; } }

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
        public string Role { get { return role; } set { role = value; } }

        [DisplayName("Gender")]
        public Gender Gender { get { return gender; } set { gender = value; } }

        /// <summary>
        /// Model Navigation
        /// </summary>
        public virtual Avatar Avatar { get; set; }
        #endregion
    }
}
