﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskEtkinlik.Core.DTOs
{
    public class CreateUserDto
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required")]

        public string Surname { get; set; }
        [Required(ErrorMessage = "Username is required")]

        public string UserName { get; set; }  
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]


        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
    }
}
