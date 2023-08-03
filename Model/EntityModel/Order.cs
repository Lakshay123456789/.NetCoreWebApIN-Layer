using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EntityModel
{
     public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public string? IdentityUserId { get; set; }
         
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public decimal TotalTax { get;set; }=0;

        public decimal TotalAmount { get; set; } = 0;

        public List<OrderProduct> OrderProductss { get; set; }
     

    }
}
