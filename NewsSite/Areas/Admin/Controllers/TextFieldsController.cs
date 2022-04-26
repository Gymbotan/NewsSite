using Microsoft.AspNetCore.Mvc;
using NewsSite.Domain;
using NewsSite.Domain.Entities;
using NewsSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Areas.Admin.Controllers
{
    /// <summary>
    /// TextFields controller to edit main pages (sections).
    /// </summary>
    [Area("Admin")]
    public class TextFieldsController : Controller
    {
        private readonly DataManager dataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextFieldsController"/> class.
        /// </summary>
        /// <param name="dataManager">DataManager to get access to DB.</param>
        public TextFieldsController(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <summary>
        /// Open view with main page to edit.
        /// </summary>
        /// <param name="codeWord">code word of main page.</param>
        /// <returns>Page's view.</returns>
        public IActionResult Edit(string codeWord)
        {
            var entity = dataManager.TextFields.GetTextFieldByCodeWord(codeWord);
            return View(entity);
        }

        /// <summary>
        /// Save page's data after editing.
        /// </summary>
        /// <param name="model">TextField (main page).</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(TextField model)
        {
            if (ModelState.IsValid)
            {
                dataManager.TextFields.SaveTextField(model);
                return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).CutController());
            }
            return View(model);
        }
    }
}
