using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    /// <summary>
    /// Login View Model - data for authentication.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Login.
        /// </summary>
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Should the password be remembered? (Boolean)
        /// </summary>
        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
