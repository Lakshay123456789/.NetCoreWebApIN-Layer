using AutoMapper;
using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelDTO
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            CreateMap<ProductDto, Product>();

            CreateMap<AddToCartDto, AddToCart>();

        }
    }
}
