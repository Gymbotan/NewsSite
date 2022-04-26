using Microsoft.AspNetCore.Mvc;
using NewsSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Areas.Admin.Controllers
{
    /// <summary>
    /// Home controller class in "Admin" area.
    /// </summary>
    [Area("Admin")]
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
            return View(dataManager.Articles.GetArticles());
        }
    }
}
