using Microsoft.AspNetCore.Identity;

namespace IdentityLab.Models
{
	public class MyIdentityUser : IdentityUser
	{


		public string LastName { get; set; }
		public string FirstName { get; set; }



	}
}