﻿using System.ComponentModel.DataAnnotations;

namespace MVP.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
