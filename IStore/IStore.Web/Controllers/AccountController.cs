using IStore.BusinessLogic.Services.Interfaces;
using IStore.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace IStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUsersManagementService _usersManagementService;

        public AccountController(IUsersManagementService usersManagementService, ILogger<AccountController> logger)
        {
            _logger = logger;
            _usersManagementService = usersManagementService;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            _logger.LogTrace("Login GET with returnUrl: " + returnUrl);

            return View("Login", new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        //TODO: Think about making it async
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var user = _usersManagementService.GetByEmail(loginViewModel.Email);
            if (user == null || !_usersManagementService.VerifyPassword(loginViewModel.Password, user.PasswordHash))
            {
                _logger.LogWarning("Login failed for " + user.Email);
                return Unauthorized();
            }

            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserRole.Title),
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = loginViewModel.RememberMe });

            return LocalRedirect(loginViewModel.ReturnUrl);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [AllowAnonymous]
        public IActionResult Register(string returnUrl = "/")
        {
            _logger.LogTrace("Registration GET with returnUrl: " + returnUrl);

            return View("Registration", new RegistrationViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegistrationViewModel registrationViewModel)
        {
            //if valid
            if (ModelState.IsValid)
            {
                var newUser = _usersManagementService.CreateNew(
                    registrationViewModel.Credentials,
                    registrationViewModel.Email,
                    registrationViewModel.Password,
                    DateTime.Now,
                    registrationViewModel.About);

                //TODO: check if newUser created successfully

                return RedirectToAction("Login");
            }

            return View("Register");
        }
    }
}
