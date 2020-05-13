﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    class UserDto
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string mail { get; set; }

        public string preference { get; set; }
    }
}