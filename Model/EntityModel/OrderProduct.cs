﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityModel
{
   public class OrderProduct
    {
        [Key]
        public Guid  Id { get; set; }
        
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; } = 0;

    }
}
