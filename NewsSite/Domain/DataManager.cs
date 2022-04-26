using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Domain.Repositories.Interfaces;

namespace NewsSite.Domain
{
    /// <summary>
    /// DataManager class. Concentrating work with DataBase.
    /// </summary>
    public class DataManager
    {
        /// <summary>
        /// Gets or sets TextField repository realization.
        /// </summary>
        public ITextFieldsRepository TextFields { get; set; }

        /// <summary>
        /// Gets or sets Article repository realization.
        /// </summary>
        public IArticlesRepository Articles { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManager"/> class.
        /// </summary>
        /// <param name="textFieldsRepository">TextField repository realization.</param>
        /// <param name="ArticlesRepository">Article repository realization.</param>
        public DataManager (ITextFieldsRepository textFieldsRepository, IArticlesRepository ArticlesRepository)
        {
            this.TextFields = textFieldsRepository;
            this.Articles = ArticlesRepository;
        }
    }
}
