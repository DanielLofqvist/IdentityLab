using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLab.Models.ViewModels
{
	public class RegisterVM
	{
		[Required(ErrorMessage = "Enter a username")]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Enter a password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Display(Name = "Last name")]
		public string LastName { get; set; }
		//public string Email { get; set; }










	}
}
