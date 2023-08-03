using AutoMapper;
using BusinessLogicLayer.ProductServices.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.EntityModel;
using Model.ModelDTO;

namespace WebApIRevision.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize(Roles = "User")]
    public class UserController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IProductCartService _productCartService;
        private readonly IMapper _mapper;
        public UserController(IProductService productService, IProductCartService productCartService, IMapper mapper)
        {
            _productService = productService;
            _productCartService = productCartService;
            _mapper = mapper;
        }
        [HttpGet("getProducts")]

        public async Task<IActionResult> GetProducts(int page = 1, int pageSize = 1,string? search="")
        {
            var products = await _productService.GetAllProduct(page, pageSize,search);
            if (products.Products.Count > 0)
            {
                return Ok(products);
            }
            return Ok("there is no product found");
        }

        [HttpPost("AddtoCarts")]
        public async Task<IActionResult> AddToCart(AddToCartDto model)
        {
            if (ModelState.IsValid) {
                // AutoMapper
                var productCart = _mapper.Map<AddToCart>(model);
                await _productCartService.Add(productCart);
                return Ok("Added into cart successfully");


            }
            return BadRequest("something went be wrong");
        }

        [HttpGet("GetUserCart")]
        public async Task<IActionResult> GetCartUser(Guid Id)
        {
           var cart= await _productCartService.GetUserCart(Id);
            return Ok(cart);
        }

        [HttpDelete("EmptyUserCart")]
        public async Task<IActionResult> EmptyUserCart(Guid Id)
        {
            var result = await _productCartService.EmptyCart(Id);
            if (result)
            {
                return Ok("Now Cart is Empty");
            }
            return NotFound("there is no product in Cart");
        }
        
         [HttpGet("DeletefromCartParticular")]
         public async Task<IActionResult> DeleteFromCart(Guid Id)
         {
            var result = await _productCartService.DeleteFrom(Id);
            if(result)
            {
                return Ok("delete from successfully");
            }

            return NotFound("there is any not delete");
         }

         [HttpPost("PlaceOrder")]

         public async Task<IActionResult> PlaceOrder(List<AddToCartDto> addToCarts)
        {
            var result = await _productCartService.AddOrderTable(addToCarts);
            if (result)
            {
                return Ok("order is placed sucessfully");
            }
            return NotFound("something went be wrong");
        }

        [HttpGet("GetOrdersByUserId")]
        public async Task<IActionResult> GetOrdersByUserId(string identityUserId)
        {
            var result = await _productCartService.GetOrdersUserId(identityUserId);
            if(result.Count>0)
            {
                return Ok(result);
            }
            return Ok("there is no order place user");
        }
       

    }
}
