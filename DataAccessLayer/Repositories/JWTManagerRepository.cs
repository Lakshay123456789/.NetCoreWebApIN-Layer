using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.ModelDTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _config;

        public JWTManagerRepository(UserManager<IdentityUser> userManager, IConfiguration config,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _config = config;
            _signInManager = signInManager;
        }
        public async Task<LoginResponseModel> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
           
            if (user == null)
            {

                return new LoginResponseModel
                {
                    IsSuccess = false
                };
            }
            bool emailStatus = await _userManager.IsEmailConfirmedAsync(user);
            if (emailStatus == false)
            {
                return new LoginResponseModel()
                {
                    IsSuccess = false
                };
            }

           
            var passwordvalid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordvalid)
            {

                return new LoginResponseModel
                {
                    IsSuccess = false
                };
            }
            //   var email = user.UserName;
            if (user.TwoFactorEnabled)
            {
                await _signInManager.SignOutAsync();
               var t= await _signInManager.PasswordSignInAsync(user, model.Password, false, true);
                var Twotoken = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
                   EmailHelper emailHelper = new EmailHelper();
                  bool emailResponse = emailHelper.SendEmail(user.Email, Twotoken);
              //  SMSHelper smsHelper = new SMSHelper();
             //   bool smsResponse = smsHelper.SendSMSTwoFactorCode(user.PhoneNumber, token);
                if (emailResponse)
                {
                    return new LoginResponseModel
                    {
                        IsSuccess = true,
                    };
                }

            }


            var userRoles = await _userManager.GetRolesAsync(user);
            var tokenHendeler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._config.GetValue<string>("JWT:Key"));

            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(authClaims),
                Expires = System.DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHendeler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHendeler.WriteToken(token);

            return new LoginResponseModel()
            {
                Id = user.Id.ToString(),
                IsSuccess = true,
                Token = encryptedToken,
                Username = user.UserName,
                Role = userRoles[0],

            };
        }
        public async Task<SignResponseModel> SignUp(RegisterDto model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email ,TwoFactorEnabled= true};

            var result=await _userManager.CreateAsync(user,model.Password);

       
           var response = new SignResponseModel();
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                response.Success = true;
                response.User = user;
                return response;
            }
            response.Success = false;
            return response;
           
        }

        public async Task<LoginResponseModel> TwoFactorAuthentication(TwoFactorDto twoFactorDto)
        {
            var result = await _signInManager.TwoFactorSignInAsync("Email", twoFactorDto.TwoFactorCode, false, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(twoFactorDto.Email);
                var userRoles = await _userManager.GetRolesAsync(user);
                var tokenHendeler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(this._config.GetValue<string>("JWT:Key"));

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                };
                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(authClaims),
                    Expires = System.DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHendeler.CreateToken(tokenDescriptor);
                var encryptedToken = tokenHendeler.WriteToken(token);
                return new LoginResponseModel()
                {
                    Id = user.Id.ToString(),
                    IsSuccess = true,
                    Token = encryptedToken,
                    Username = user.UserName,
                    Role = userRoles[0],

                };
            }
            return new LoginResponseModel()
            {
                IsSuccess = false,
            };

        }

    }
}
