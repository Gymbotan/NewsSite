using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Domain;
using NewsSite.Domain.Entities;
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
        private const int pageSize = 3;
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
        /// Show main (Index) page with articles.
        /// </summary>
        /// <param name="id">Id of a specific article.</param>
        /// <param name="num">Page number.</param>
        /// <returns></returns>
        public ActionResult Index(Guid id, int? num)
        {
            if (id != default)
            {
                return View("Show", dataManager.Articles.GetArticleById(id));
            }
            ViewBag.TextField = dataManager.TextFields.GetTextFieldByCodeWord("PageServices");
            ViewBag.CurrentPageNumber = num ?? 0;
            ViewBag.AmountOfPages = (dataManager.Articles.GetAmountOfArticles() - 1) / pageSize;

            int page = num ?? 0;
            //if (Request.Headers["x-requested-with"] == "XMLHttpRequest")
            //{
            //    return PartialView("_Items", GetItemsPage(page));
            //}
            return View(GetItemsPage(page));
        }

        private IQueryable<Article> GetItemsPage(int page = 1)
        {
            var itemsToSkip = page * pageSize;

            return dataManager.Articles.GetArticles().OrderBy(t => t.Id).Skip(itemsToSkip).
                Take(pageSize);
        }
    }
}
