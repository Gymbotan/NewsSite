using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Domain.Repositories.Interfaces;

namespace NewsSite.Domain
{
    public class DataManager
    {
        public ITextFieldsRepository TextFields { get; set; }
        public IArticlesRepository Articles { get; set; }

        public DataManager (ITextFieldsRepository textFieldsRepository, IArticlesRepository ArticlesRepository)
        {
            this.TextFields = textFieldsRepository;
            this.Articles = ArticlesRepository;
        }
    }
}
