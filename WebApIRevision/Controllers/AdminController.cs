using AutoMapper;
using BusinessLogicLayer.ProductServices;
using BusinessLogicLayer.ProductServices.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Model.EntityModel;
using Model.ModelDTO;

namespace WebApIRevision.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin")]
    public class AdminController:ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductCartService _productCartService;
        private readonly IMapper _mapper;

        public AdminController(IProductService productService,IProductCartService productCartService,IMapper mapper) {
            _productService = productService;
            _productCartService=productCartService;
            _mapper = mapper;
        }
        [HttpGet("GetProducts")]

        public  async Task<IActionResult> GetAllProducts(int page=1,int pageSize=1, string? search = "")
        {
            var products = await _productService.GetAllProduct(page,pageSize,search);
            if (products.Products.Count > 0)
            {
                return Ok(products);
            }
            return Ok("there is no product found");
        }
        [HttpGet("GetProductById")]

        public async Task<IActionResult> GetProductId(Guid Id)
        {
            var product = await _productService.GetProductById(Id);
            return Ok(product);
        }

        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                // Automapper
                var products = _mapper.Map<Product>(product);
                await _productService.Add(products);
                return Ok("Insert Successfully ");

            }
            return BadRequest("Somethingwent wrong");

        }
        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid Id)
        {
            var result = _productService.Delete(Id);
            if (result.Result)
            {
                return Ok("Delete product successfully");
            }
            return BadRequest("Somethingwent wrong");

        }

        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProduct(Guid Id, ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var existingProduct = await _productService.GetProductById(Id);

                if (existingProduct != null)
                {
                    _mapper.Map(product, existingProduct); 
                    var result = await _productService.Update(existingProduct); 
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return StatusCode(500, "Failed to update the product.");
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("AllUserOrders")]
        public async Task<IActionResult> GetAllUsersOrder()
        {
            var result = await _productCartService.GetAllOrdersUseres();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return Ok("there is no order placed by any user");
        }


    }
}
