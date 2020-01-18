using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityLab.Models;
using IdentityLab.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityLab.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService service;

        public AccountController(AccountService service)
        {
            this.service = service;
        }

        [Route("user/profile")]
        public IActionResult Index()
        {
            return Content($"You are logged in as {User.Identity.Name}");
        }



        [Route("")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [Route("")]
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterVM vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            // Call service to create user
            var result = await service.TryCreateUserAsync(vm);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, result.Errors.First().Description);
                return View(vm);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}