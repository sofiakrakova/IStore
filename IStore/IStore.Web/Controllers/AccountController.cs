using IStore.Data;
using IStore.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Security.Claims;

namespace IStore.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUsersRepository _usersRepository;

        public AccountController(IUsersRepository usersRepository, ILogger<AccountController> logger)
        {
            _logger = logger;
            _usersRepository = usersRepository;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl= "/")
        {
            _logger.LogTrace("Login GET with returnUrl: " + returnUrl);

            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        //TODO: Think about making it async
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            _logger.LogTrace("Login POST");

            var user = _usersRepository.GetByEmail(loginViewModel.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginViewModel.Password, user.PasswordHash))
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

            //Protect against Open Redirection attacks
            return LocalRedirect(loginViewModel.ReturnUrl);
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
