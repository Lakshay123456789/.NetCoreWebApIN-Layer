using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityModel;

namespace Model.ModelDTO
{
    public class ProductResponseModel
    {
        public int TotalCount { get; set; } 

        public int TotalPage { get; set; }

        public List<Product> Products { get; set; }

    }
}
