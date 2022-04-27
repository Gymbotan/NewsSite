using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="dataManager">DataManager to get access to DB.</param>
        public HomeController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <summary>
        /// Show starting (Index) page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(dataManager.TextFields.GetTextFieldByCodeWord("PageIndex"));
        }

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
