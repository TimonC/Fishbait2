﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MySql.Data.MySqlClient;

namespace Fishbait2.Models
{
    public class User
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
