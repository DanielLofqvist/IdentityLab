using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityLab.Models
{
	internal class MyIdentityContext : IdentityDbContext<MyIdentityUser>
	{

		public MyIdentityContext(DbContextOptions<MyIdentityContext> options) : base(options)
		{
			var result = Database.EnsureCreated();

		}




	}
}