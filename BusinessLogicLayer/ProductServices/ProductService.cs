using BusinessLogicLayer.ProductServices.Interface;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ModelDTO;
using System.Globalization;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _genericRepository;

        private readonly IGenericRepository<ForgetPassword> _ForgetgenericRepository;
        public ProductService(IGenericRepository<Product> genericRepository,IGenericRepository<ForgetPassword> genericRepository1)
        {
            _genericRepository = genericRepository;
            _ForgetgenericRepository = genericRepository1;
        }
    
        public async Task<ProductResponseModel> GetAllProduct(int page, int pageSize, string search = "")
        {
            var productList=await _genericRepository.GetAll();

            var totalCount=  productList.Count();

            if (!string.IsNullOrEmpty(search))
            {
                productList=productList.Where(x=> 
                x.Name.Contains(search) || 
                x.Category.Contains(search) ||
                x.Price.ToString().Contains(search) ||
                x.Description.Contains(search) ||
                x.Rating.Contains(search) ||
                x.Quantity.ToString().Contains(search)).ToList();
            }
            var totalPage =(int)Math.Ceiling((Decimal)totalCount/pageSize);


            var productPerPage = productList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new ProductResponseModel
            {
               TotalCount= totalCount,
               TotalPage= totalPage,
                 Products= productPerPage
            };
        }
        public async Task<Product> GetProductById(Guid Id)
        {
            return await _genericRepository.GetById(Id);
        }
        public async Task<Product> Update(Product product)
        {
            return await _genericRepository.Update(product);
        }
        public async Task Add(Product product)
        {
            await _genericRepository.Insert(product);
        }
        public async Task<bool> Delete(Guid Id)
        {
           return  await _genericRepository.Delete(Id);
        }
        
        // add token database
        public async Task AddToken(ForgetPassword model)
        {
            await _ForgetgenericRepository.Insert(model);
        }

        // get token data

        public async Task<ForgetPassword> GetTokeByEmail(string email)
        {
            return await _ForgetgenericRepository.GetToken(email);
        }
        

        public async Task<bool> DeleteToken(string email)
        {
            return await _ForgetgenericRepository.Delete(email);
        }
    }
}
