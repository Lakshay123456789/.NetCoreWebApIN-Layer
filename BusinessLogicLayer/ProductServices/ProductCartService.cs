using BusinessLogicLayer.ProductServices.Interface;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.EntityModel;
using Model.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ProductServices
{
    public class ProductCartService : IProductCartService
    {
        private readonly IGenericRepository<AddToCart> _genericRepository;
        private readonly IGenericRepository<Product> _productgenericRepository;
        private readonly IGenericRepository<Order> _ordergenericRepository;
        private readonly IGenericRepository<OrderProduct> _orderproductgenericRepository;
        public ProductCartService(IGenericRepository<AddToCart> genericRepository, 
            IGenericRepository<Product> productgenericRepository,
             IGenericRepository<Order> ordergenericRepository,
             IGenericRepository<OrderProduct> orderproductgenericRepository
            )
        {

            _genericRepository = genericRepository;
            _productgenericRepository = productgenericRepository;
            _ordergenericRepository = ordergenericRepository;
            _orderproductgenericRepository= orderproductgenericRepository;
        }

        public async Task Add(AddToCart addToCart)
        {
          //  var product=await _productgenericRepository.GetById(addToCart.ProductId);
            await _genericRepository.Insert(addToCart);
        }
        public async Task<List<AddToCart>> GetUserCart(Guid Id)
        {
           return await _genericRepository.GetAllById(Id);
           
        } 

        public async Task<bool> EmptyCart(Guid Id)
        {
            var userCart = await _genericRepository.GetAllById(Id);
            if(userCart.Count> 0)
            {
                foreach(var  item in userCart)
                {
                   await _genericRepository.Delete(item.Id);
                }
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteFrom(Guid id)
        {
            var result=await _genericRepository.Delete(id);
            if (result)
            {
                return true;
            }

            return false;
            
        }
        public async Task<bool> AddOrderTable(List<AddToCartDto> addToCarts)
        {
            decimal totalAmount = 0;
            foreach (var addToCart in addToCarts)
            {
                totalAmount += addToCart.ProductPrice;
            }
            decimal totalTax = totalAmount * 0.18m;
            totalAmount += totalTax;

            var newOrder = new Order
            {
                 Id=Guid.NewGuid(),
                 IdentityUserId = addToCarts[0].IdentityUserId, 
                 OrderDate = DateTime.Now,
                 TotalAmount = totalAmount,
                 TotalTax = totalTax,
            };

            await _ordergenericRepository.Insert(newOrder);


            foreach (var cartProduct in addToCarts)
            {
                var orderProduct = new OrderProduct
                {
                    Id = Guid.NewGuid(),
                    OrderId = newOrder.Id,
                    ProductId = cartProduct.ProductId,
                    Quantity = cartProduct.ProductQuantity
                  
                };
                await _orderproductgenericRepository.Insert(orderProduct);

            }
            return true;
        } 
        public async Task<List<Order>> GetOrdersUserId(string identityUserId)
        {
            return await _ordergenericRepository.GetAllOrders(identityUserId);
        }

        public async Task<List<Order>> GetAllOrdersUseres()
        {
            return await _ordergenericRepository.GetAllOrdersOfDifferentUsers();  
        }
        
    }
}
