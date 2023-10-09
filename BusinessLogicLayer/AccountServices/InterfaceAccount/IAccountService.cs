using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.ModelDTO;

namespace BusinessLogicLayer.AccountServices.InterfaceAccount
{
    public interface IAccountService
    {
        Task<LoginResponseModel> LoginUser(LoginDto model);

        Task<SignResponseModel> Registration(RegisterDto model);

        Task<bool> EmailSendUser(ControllerBase controller , IdentityUser user);

        Task<bool> CheckEmailConfirmation(string token, string email);

        Task<bool> ForgetPasswordLink(ControllerBase controller, ForgetPasswordDto model);

        Task<bool> ResetPassword(ResetPasswordModel resetPasswordModel);

        Task<LoginResponseModel> VerifyTwoFactor(TwoFactorDto model);

    }
}