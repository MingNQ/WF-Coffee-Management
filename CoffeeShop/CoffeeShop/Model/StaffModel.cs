using CoffeeShop.Model.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
	public class StaffModel
	{
		#region Fields
		/// <summary>
		/// Id field
		/// </summary>
		private int staffID;

		/// <summary>
		/// Name field
		/// </summary>
		private string staffName;
		
		/// <summary>
		/// Phone Number
		/// </summary>
		private string staffPhoneNumber;

		/// <summary>
		/// Date Of Birth
		/// </summary>
		private DateTime dateOfBirth;

		/// <summary>
		/// Email field
		/// </summary>
		private string email;

		/// <summary>
		/// Role field
		/// </summary>
		private string role;

		/// <summary>
		/// Gender field
		/// </summary>
		private Gender gender;
		#endregion

		#region Properties
		/// <summary>
		/// ID property
		/// </summary>
		public int StaffID { get { return staffID; } set { staffID = value; } }

		/// <summary>
		/// Staff's Name property
		/// </summary>
		public string StaffName { get { return staffName; } set { staffName = value; } }

		/// <summary>
		/// Phone Number property
		/// </summary>
		public string StaffPhoneNumber { get { return staffPhoneNumber; } set { staffPhoneNumber = value; } }

		/// <summary>
		/// Date of Birth property
		/// </summary>
		public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }

		/// <summary>
		/// Email property
		/// </summary>
		public string Email { get { return email; } set { email = value; } }

		/// <summary>
		/// Role property
		/// </summary>
		public string Role { get { return role; } set { role = value; } }

		/// <summary>
		/// Gender property
		/// </summary>
		public Gender Gender { get { return gender; } set { gender = value; } }
		#endregion
	}
}
