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
    public class RegisterViewModel
    {
        /// <summary>
        /// Login.
        /// </summary>
        [Required]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [UIHint("email")]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        /// <summary>
        /// Password.
        /// </summary>
        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        /// <summary>
        /// Confirm password.
        /// </summary>
        [Required]
        [UIHint("confirmPassword")]
        [Display(Name = "Подтвердите пароль")]
        public string PasswordConfirm { get; set; }
    }
}
