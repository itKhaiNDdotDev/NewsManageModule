using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NewsManageModule.Data.Entities;
using NewsManageModule.Helpers.Exceptions;
using NewsManageModule.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NewsManageModule.Services.System
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _config;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<string> Authen(LoginRequest request)
        {
            //throw new NotImplementedException();
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                //throw new NMMException($"Username {request.Username} is not exist!");
                return null;
            var res = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, true);
            if(!res.Succeeded)
            {
                return null;
            }
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.Fullname),
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                _config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds
             );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            //throw new NotImplementedException();
            var user = new User()
            {
                Email = request.Email,
                Fullname = request.Fullname,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Username,
            };
            var res = await _userManager.CreateAsync(user, request.Password);
            if (request.Password == request.ConfirmPassword && res.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
