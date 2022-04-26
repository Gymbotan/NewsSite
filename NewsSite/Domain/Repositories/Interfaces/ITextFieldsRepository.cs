using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsSite.Domain.Entities;

namespace NewsSite.Domain.Repositories.Interfaces
{
    /// <summary>
    /// Interface of a repository for pages.
    /// </summary>
    public interface ITextFieldsRepository
    {
        /// <summary>
        /// Get all pages.
        /// </summary>
        /// <returns>All pages.</returns>
        IQueryable<TextField> GetTextFields();

        /// <summary>
        /// Get specific page with choosen id.
        /// </summary>
        /// <param name="id">Id of the page.</param>
        /// <returns>Page with choosen id.</returns>
        TextField GetTextFieldById(Guid id);

        /// <summary>
        /// Get specific page with choosen code word.
        /// </summary>
        /// <param name="codeWord">Code word of the page.</param>
        /// <returns>Page with choosen code word.</returns>
        TextField GetTextFieldByCodeWord(string codeWord);

        /// <summary>
        /// Save page.
        /// </summary>
        /// <param name="entity">Page to save.</param>
        void SaveTextField(TextField entity);

        /// <summary>
        /// Delete page.
        /// </summary>
        /// <param name="id">Id of the page.</param>
        void DeleteTextField(Guid id);
    }
}
