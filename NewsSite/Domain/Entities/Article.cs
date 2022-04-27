using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Domain.Entities
{
    /// <summary>
    /// Article class.
    /// </summary>
    public class Article : EntityBase
    {
        /// <summary>
        /// Title of the article.
        /// </summary>
        [Required(ErrorMessage ="Заполните название новости")]       
        [Display(Name = "Заголовок")]
        public override string Title { get; set; }

        /// <summary>
        /// Subtitle of the article.
        /// </summary>
        [Display(Name = "Подзаголовок (Краткое описание)")]
        [MinLength(7, ErrorMessage = "Подзаголовок слишком короткий (минимум 7 символов)")]
        public override string Subtitle { get; set; }

        /// <summary>
        /// Full text of the article.
        /// </summary>
        [Display(Name = "Текст новости")]
        public override string Text { get; set; }
    }
}
