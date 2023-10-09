using Model.ModelDTO;

namespace DataAccessLayer.Repositories
{
    public interface IJWTManagerRepository
    {
        Task<LoginResponseModel> Login(LoginDto model);

        Task<SignResponseModel> SignUp(RegisterDto model);
        Task<LoginResponseModel> TwoFactorAuthentication(TwoFactorDto twoFactorDto);
    }
}