using Microsoft.AspNetCore.Mvc;
using NewsSite.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models.ViewComponents
{
    /// <summary>
    /// ViewComponent of a sidebar.
    /// </summary>
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager dataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="SidebarViewComponent"/> class.
        /// </summary>
        /// <param name="context">DB context.</param>
        public SidebarViewComponent(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        /// <summary>
        /// Send data (3 last news/articles) to the "Default" View.
        /// </summary>
        /// <returns></returns>
        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult)View("Default", dataManager.Articles.GetLastArticles(3)));
        }
    }
}
