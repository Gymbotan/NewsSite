using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsSite.Domain.Repositories.Interfaces;
using NewsSite.Domain.Entities;

namespace NewsSite.Domain.Repositories.EntityFramework
{
    /// <summary>
    /// Entity Framework realization of ITextFieldsRepository interface.
    /// </summary>
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EFTextFieldsRepository"/> class.
        /// </summary>
        /// <param name="context">DB context.</param>
        public EFTextFieldsRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all pages.
        /// </summary>
        /// <returns>All pages.</returns>
        public IQueryable<TextField> GetTextFields()
        {
            return context.TextFields;
        }

        /// <summary>
        /// Get specific page with choosen code word.
        /// </summary>
        /// <param name="codeWord">Code word of the page.</param>
        /// <returns>Page with choosen code word.</returns>
        public TextField GetTextFieldByCodeWord(string codeWord)
        {
            return context.TextFields.FirstOrDefault(x => x.CodeWord == codeWord);
        }

        /// <summary>
        /// Get specific page with choosen id.
        /// </summary>
        /// <param name="id">Id of the page.</param>
        /// <returns>Page with choosen id.</returns>
        public TextField GetTextFieldById(Guid id)
        {
            return context.TextFields.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Save page.
        /// </summary>
        /// <param name="entity">Page to save.</param>
        public void SaveTextField(TextField entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Delete page.
        /// </summary>
        /// <param name="id">Id of the page.</param>
        public void DeleteTextField(Guid id)
        {
            context.TextFields.Remove(new TextField { Id = id });
            context.SaveChanges();
        }
    }
}
