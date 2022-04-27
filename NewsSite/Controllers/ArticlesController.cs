using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{
    /// <summary>
    /// Services controller class.
    /// </summary>
    public class ArticlesController : Controller
    {
        private readonly DataManager dataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlesController"/> class.
        /// </summary>
        /// <param name="dataManager">DataManager to get access to DB.</param>
        public ArticlesController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        [Authorize]
        /// <summary>
        /// Show main (Index) page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Index(Guid id)
        {
            if (id != default)
            {
                return View("Show", dataManager.Articles.GetArticleById(id));
            }

            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            return View(dataManager.Articles.GetArticles());
        }
    }
}
