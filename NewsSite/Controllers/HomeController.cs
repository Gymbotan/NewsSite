using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    /// <summary>
    /// Home controller class.
    /// </summary>
    public class HomeController : Controller
    {
        private readonly DataManager dataManager;
        private readonly UserManager<IdentityUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="dataManager">DataManager to get access to DB.</param>
        public HomeController(DataManager dataManager, UserManager<IdentityUser> userManager)
        {
            this.dataManager = dataManager;
            this.userManager = userManager;
        }

        /// <summary>
        /// Show starting (Index) page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if (!string.IsNullOrWhiteSpace(userManager.GetUserName(User)))
            {
                Response.Cookies.Append("name", userManager.GetUserName(User));
            }
            //ViewBag.CurrentUserName = userManager.GetUserName(User);
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }

        [Authorize]
        /// <summary>
        /// Show contacts page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Contacts()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageContacts"));
        }

        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, 
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30)});
            return LocalRedirect(returnUrl);
        }
    }
}
