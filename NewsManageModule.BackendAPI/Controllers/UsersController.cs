using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsManageModule.Services.System;
using NewsManageModule.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsManageModule.BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // Login account: ./api/users/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authen(/*[FromBody]*/[FromForm] LoginRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var resToken = await _userService.Authen(request);
            if (string.IsNullOrEmpty(resToken))
                return BadRequest("Login information incorrect!");
            return Ok(new { token = resToken });
        }

        // Register account: ./api/users/register
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm] RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var res = await _userService.Register(request);
            if(!res)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
} 
