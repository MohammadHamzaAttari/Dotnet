﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos.User
{
    public class ApiUserDto : LoginUserDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        [Phone]

        public string? PhoneNumber { get; set; }

    }
}
