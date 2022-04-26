using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Domain;
using NewsSite.Domain.Entities;
using NewsSite.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Areas.Admin.Controllers
{
    /// <summary>
    /// Articles Controller that allows you to edit articles.
    /// </summary>
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private readonly DataManager dataManager;
        private readonly IWebHostEnvironment hostingEnvironment;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlesController"/> class.
        /// </summary>
        /// <param name="dataManager">DataManager to get access to DB.</param>
        /// <param name="hostingEnvironment">hosting environment.</param>
        public ArticlesController(DataManager dataManager, IWebHostEnvironment hostingEnvironment)
        {
            this.dataManager = dataManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// Open view with article to edit.
        /// </summary>
        /// <param name="id">Article's id.</param>
        /// <returns>Article's view.</returns>
        public IActionResult Edit(Guid id)
        {
            var entity = id == default ? new Article() : dataManager.Articles.GetArticleById(id);
            return View(entity);
        }

        /// <summary>
        /// Save article after editing.
        /// </summary>
        /// <param name="model">Article foe editing.</param>
        /// <param name="titleImageFile">Image file.</param>
        /// <returns>Redirect to Index page.</returns>
        [HttpPost]
        public IActionResult Edit(Article model, IFormFile titleImageFile)
        {
            if (ModelState.IsValid)
            {
                if (titleImageFile != null)
                {
                    model.TitleImagePath = titleImageFile.FileName;
                    using (var stream = new FileStream(Path.Combine(hostingEnvironment.WebRootPath, "images/", titleImageFile.FileName), FileMode.Create))
                    {
                        titleImageFile.CopyTo(stream);
                    }
                }
                dataManager.Articles.SaveArticle(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }

        /// <summary>
        /// Delete article by it's id.
        /// </summary>
        /// <param name="id">article's id.</param>
        /// <returns>Redirect to Index page.</returns>
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            dataManager.Articles.DeleteArticle(id);
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
        }
    }
}
