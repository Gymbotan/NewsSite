using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Models;

namespace NewsSite.Controllers
{
    /// <summary>
    /// Account controller class for authorization.
    /// </summary>
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">User Manager.</param>
        /// <param name="signInManager">SignIn Manager</param>
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Calling of login interface.
        /// </summary>
        /// <param name="returnUrl">Url to return after login.</param>
        /// <returns>View for login.</returns>
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        /// <summary>
        /// Authentication.
        /// </summary>
        /// <param name="model">Login data.</param>
        /// <param name="returnUrl">Return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        Response.Cookies.Append("name", user.UserName);
                        //ViewBag.CurrentUserName = userManager.GetUserName(User);
                        return Redirect(returnUrl ?? "/");
                    }
                }

                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(model);
        }
        
        [AllowAnonymous]
        public IActionResult Register(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new RegisterViewModel());
        }

        /// <summary>
        /// Registration of a new User
        /// </summary>
        /// <param name="model">Registering data.</param>
        /// <param name="returnUrl">Return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                // Checking if both inputed passwords are equal
                if (!model.Password.Equals(model.PasswordConfirm))
                {
                    ModelState.AddModelError(nameof(LoginViewModel.Password), "Пароль и его подтверждение не совпадают");
                    return View(model);
                }

                // Create new IdentityUser based on the RegisterViewModel
                IdentityUser user = new IdentityUser
                {
                    UserName = model.UserName,
                    NormalizedUserName = model.UserName.ToUpper(),
                    Email = model.Email,
                    EmailConfirmed = true,
                };

                // Attempt to write this user to a DataBase
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Give to this created user a role "user"
                    await userManager.AddToRoleAsync(user, "user");

                    // If someone already is signed in - sign him out
                    await signInManager.SignOutAsync();

                    // Sign in a new user.
                    var signInResult = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        Response.Cookies.Append("name", user.UserName);
                        //ViewBag.CurrentUserName = userManager.GetUserName(User);
                        return Redirect(returnUrl ?? "/");
                    }
                }

                return Redirect(returnUrl ?? "/");
            }

            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            Response.Cookies.Append("name", string.Empty);
            //ViewBag.CurrentUserName = String.Empty;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
