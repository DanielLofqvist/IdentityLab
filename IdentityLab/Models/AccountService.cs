using IdentityLab.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IdentityLab.Models
{
	public class AccountService
	{
		private readonly UserManager<MyIdentityUser> userManager;
		private readonly SignInManager<MyIdentityUser> signInManager;
		private string userId;

		public AccountService(
			UserManager<MyIdentityUser> userManager,
			SignInManager<MyIdentityUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		//public AccountService(IHttpContextAccessor accessor)
		//{
		//	userId = userManager.GetUserId(accessor.HttpContext.User);


		//}


		public async Task<SignInResult> TrySignInUser(RegisterVM vM)
		{

			var user = await userManager.FindByIdAsync(userId);

			var result = await signInManager.PasswordSignInAsync(
				user.UserName,
				user.PasswordHash,
				isPersistent:false,
				lockoutOnFailure:false
				
				);
			return result;

		}


		public async Task<IdentityResult> TryCreateUserAsync(RegisterVM vm)
		{
			var result = await userManager.CreateAsync(new MyIdentityUser
			{
				UserName = vm.Username,
				FirstName = vm.FirstName,
				LastName = vm.LastName,


			}, vm.Password);

			if (result.Succeeded)
				await signInManager.PasswordSignInAsync(vm.Username, vm.Password, false, false);

			return result;

		}









	}
}

