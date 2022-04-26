using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Domain.Entities
{
    /// <summary>
    /// Data of main pages (sections) of the site.
    /// </summary>
    public class TextField : EntityBase
    {
        /// <summary>
        /// Code word to find this page.
        /// </summary>
        [Required]
        public string CodeWord { get; set; }

        /// <summary>
        /// Title of the page.
        /// </summary>
        [Display(Name = "Название страницы (заголовок)")]
        public override string Title { get; set; } = "Информационная страница";

        /// <summary>
        /// Full text (information) that will be shown on this page.
        /// </summary>
        [Display(Name = "Содержание страницы")]
        public override string Text { get; set; } = "Содержание заполняется администратором";
    }
}
