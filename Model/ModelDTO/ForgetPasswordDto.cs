﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelDTO
{
    public class ForgetPasswordDto
    {
        [Required]
        public string? Email { get; set; }  
    }
}
