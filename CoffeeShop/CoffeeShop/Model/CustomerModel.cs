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
    public class CustomerModel
    {
        #region Fields
        private string customerID;
        private string customerName;
        private string customerPhone;
        private string customerEmail;       
        private decimal coupon;
        private Gender gender;
        #endregion

        #region Properties
        [DisplayName("ID")]
        public string CustomerID { get { return customerID; } set { customerID = value; } }

        [DisplayName("Customer Name")]
        [Required(ErrorMessage = "Customer name is required")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "The name does not include numbers and special characters")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Customer name must be between 5 and 50 characters")]
        public string CustomerName { get { return customerName; } set { customerName = value; } }

        [DisplayName("Phone Number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "This must be number")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 12 digits")]       
        public string CustomerPhone { get { return customerPhone; } set { customerPhone = value; } }


        [DisplayName("Email")]
        //[RegularExpression(@"^[A-Za-z]+[A-Za-z0-9._%+-]*@gmail\.com$", ErrorMessage = "Email must be entered in the format abc(or abc123)@gmail.com")]
        //[Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CustomerEmail { get { return customerEmail; } set { customerEmail = value; } }  


        [DisplayName("Coupon")]
        public decimal Coupon { get { return coupon; } set { coupon = value; } }


        [DisplayName("Gender")]
        public Gender Gender { get { return gender; } set { gender = value; } }
        #endregion
    }
}
