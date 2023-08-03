using BusinessLogicLayer.AccountServices.InterfaceAccount;
using BusinessLogicLayer.ProductServices.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.EntityModel;
using Model.ModelDTO;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace WebApIRevision.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController :ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IProductService _productService;
     
        public AccountController(IAccountService accountService,IProductService productService)
        {
            _accountService = accountService;
            _productService = productService;
          
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn(LoginDto model)
        {
            var result = await _accountService.LoginUser(model);

            if (result.IsSuccess)
            {
                return Ok(result); 
            }
            else
            {
                return Unauthorized(result);
            }

        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(RegisterDto model)
        {
             var result= await _accountService.Registration(model);
        
            if (result.Success)
            {
                var emailResponse = await _accountService.EmailSendUser(this, result.User);

                if (emailResponse)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Failed to send the email.");
                }
            }
            else
            {
                return BadRequest("SomeThing are in correct");
            }
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {

             var result = _accountService.CheckEmailConfirmation(token, email);
            if (result.Result==true)
            {

                return Ok("your Email is Confirm thank you");
            }
            return BadRequest("Some thing is Wrong");
        }

        [HttpPost("ForgetPassword")]

        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto model)
        {
            var result = await _accountService.ForgetPasswordLink(this,model);
            if (result)
            {
                return Ok("link send successfully");
            }
            return BadRequest("SomeThing are incorrect");
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var result = await _accountService.ResetPassword(resetPasswordModel);
            if (result)
            {
                return Ok("your password Reset successfully");
            }
            return BadRequest("asdf");
        }

        [HttpGet("ConfirmPassword")]
        public async Task<IActionResult> ConfirmPassword(string token, string email)
        {
            var model = new ResetPasswordModel { Token = token, Email = email };

            var Forgetmodel = new ForgetPassword
            {
                Email = email,
                Token=token
            };
            var checkToken = await _productService.GetTokeByEmail(email);
             if(checkToken !=null)
            {
                await _productService.DeleteToken(email);
            }
            await _productService.AddToken(Forgetmodel);

            return Ok(model);
        }

        [HttpGet("GetEmailToken")]
        public  async Task<IActionResult> GetTokenEmail(string Email)
       {
            if (!string.IsNullOrEmpty(Email))
            {
               
                var result2= await _productService.GetTokeByEmail(Email);
                if (result2 != null)
                {
                   
                    return Ok(result2);
                }
                else
                {
                    return NotFound("Token not found for the specified email.");
                }
            }
            else
            {
                return BadRequest("Email cannot be empty or null.");
            }
        }

    }

}
