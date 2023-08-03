using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelDTO
{
    public  class OrderDto
    {
        public string? IdentityUserId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalTax { get; set; }

        public decimal TotalAmount { get; set; }

    }
}
