using BusinessLogicLayer.AccountServices.InterfaceAccount;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Model.ModelDTO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly IJWTManagerRepository _IJWTManagerRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountService(IJWTManagerRepository IJWTManagerRepository, UserManager<IdentityUser> userManager, IUrlHelperFactory urlHelperFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _IJWTManagerRepository = IJWTManagerRepository;
            _userManager= userManager;
            _urlHelperFactory = urlHelperFactory;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<LoginResponseModel> LoginUser(LoginDto model)
        {
            return await _IJWTManagerRepository.Login(model);
        }
        public async Task<SignResponseModel> Registration(RegisterDto model)
        {
            return await _IJWTManagerRepository.SignUp(model);
        }

        public async Task<bool> EmailSendUser(ControllerBase controller, IdentityUser user)
        {
          //  var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            //  var token = _userManager.GenerateEmailConfirmationTokenAsync(user);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var urlHelper = _urlHelperFactory.GetUrlHelper(controller.ControllerContext);
            var requestScheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var confirmationLink = urlHelper.Action(
                       action: "ConfirmEmail",
                       controller: "Account",
                       values: new { token, email = user.Email },
                       protocol: requestScheme
                   );

            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

            if (emailResponse)
            {
                return emailResponse;
            }
            return false;

        }
        public async Task<bool> CheckEmailConfirmation(string token,string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                // Email confirmation successful
                return true;
            }
            else
            {
                // Email confirmation failed
                return false;
            }
        }


        // Reset  password link send
        public async Task<bool> ForgetPasswordLink(ControllerBase controller,ForgetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return false;
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var urlHelper = _urlHelperFactory.GetUrlHelper(controller.ControllerContext);
            var requestScheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var confirmationLink = urlHelper.Action(
                       action: "ConfirmPassword",
                       controller: "Account",
                       values: new { token, email = user.Email },
                       protocol: requestScheme
                   );

            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

            if (emailResponse)
            {
                return emailResponse;
            }
            return false;
        }

        // set New Password
        public async Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email);
            if (user == null)
                return false;
            var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordModel.Token, resetPasswordModel.Password);
            if (resetPassResult.Succeeded)
            {
                return true;
            }
            return false;
        }

       
    }
}
