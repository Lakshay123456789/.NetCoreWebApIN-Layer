using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelDTO
{
    public class AddToCartDto
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string ProductCategory { get; set; }
        [Required]

        public string ProductRating { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        public bool IsCheckOut { get; set; } = true;


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }

        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
    }
}
