using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {

            if (!ModelState.IsValid)
            {
                return View(register);
            }
            CheckUser checkUser = _userService.CheckUser(register.UserName, register.Email);
            if (checkUser != CheckUser.Ok)
            {
                ViewBag.Check = checkUser;
                return View(register);
            }
            User user = new User()
            {
                Email = register.Email.Trim().ToLower(),
                Password = PasswordHelper.EncodePasswordMD5(register.Password),
                UserName = register.UserName,

            };
            _userService.RegisterUser(user);
            return View("SuccessRegister", register);
        }

        #endregion

        #region Login

        [Route("Login")]
        public IActionResult Login(string returnUrl="/") 
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();  
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login,string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(login);

            if (!_userService.IsExistUser(login.Email, login.Password)) 
            {
                ModelState.AddModelError("Email","User Not Found .....");
                return View(login);
            }

            var claims = new List<Claim>() { 
            new Claim(ClaimTypes.NameIdentifier,login.Email),
            new Claim(ClaimTypes.Name,login.Email)
            };

            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties() 
            {
                IsPersistent = login.RemmemberMe
            };
            HttpContext.SignInAsync(principal,properties);
            return Redirect(returnUrl);
        }
        #endregion

        #region Logout
        public IActionResult Logout() 
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        #endregion
    }
}
