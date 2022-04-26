using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Domain.Entities
{
    /// <summary>
    /// Base class for entities.
    /// </summary>
    public class EntityBase
    {
        protected EntityBase()
        {
            this.DateAdded = DateTime.UtcNow;
        }

        /// <summary>
        /// Entity's id.
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Title of the entity.
        /// </summary>
        [Display(Name ="Название (заголовок)")]
        public virtual string Title { get; set; }

        /// <summary>
        /// Subtitle of the entity.
        /// </summary>
        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        /// <summary>
        /// Description or text of the entity.
        /// </summary>
        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        /// <summary>
        /// Path to the title image.
        /// </summary>
        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }

        /// <summary>
        /// Meta title of the entity.
        /// </summary>
        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }

        /// <summary>
        /// Meta description of the entity.
        /// </summary>
        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }

        // <summary>
        /// Meta keywords of the entity.
        /// </summary>
        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords{ get; set; }

        /// <summary>
        /// Time of entity creating.
        /// </summary>
        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
