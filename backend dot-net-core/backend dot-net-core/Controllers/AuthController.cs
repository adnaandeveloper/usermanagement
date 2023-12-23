using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using backend_dot_net_core.Core.Constants;
using backend_dot_net_core.Core.Dtos.Auth;
using backend_dot_net_core.Core.Interfaces;
using backend_dot_net_core.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend_dot_net_core.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }


        // Route -> Seed Roles DB
        [HttpPost]
        [Route("seed-roles")]
        public async Task<IActionResult> SeedRoles ()
        {
            var seedResult = await _authService.SeedRolesAsync();
            return StatusCode(seedResult.StatusCode, seedResult.Message);

        }

        // Route -> Register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult>Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authService.RegisterAsync(registerDto);
            return StatusCode(registerResult.StatusCode, registerResult.Message);
        }

        // Route -> Login
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginServiceResponseDto>> Login([FromBody] LoginDtos loginDto)
        {
            var loginResult = await _authService.LoginAsync(loginDto);

            if(loginResult is null)
            {
                return Unauthorized("Your credentials are invalid. Please contact to an Admin");
            }
            return Ok(loginResult);
        }


        //Route -> Update User Role
        //An Awner van change everything
        // an admin can Change just User to Manager o reverse
        //Manaeger and user Roles dont have access to this Route

        // Route -> Login
        [HttpPost]
        [Route("update-role")]
        [Authorize(Roles = StaticUserRoles.OwnerAdmin)]
        public async Task<IActionResult> Update([FromBody] UpdateRoleDto updateRoleDto)
        {
            var updateRoleResult = await _authService.UpdateRoleAsync(User, updateRoleDto);

            if (updateRoleResult.IsSucceed)
            {
                return Ok(updateRoleResult.Message);
            }
            else
            {
                return StatusCode(updateRoleResult.StatusCode, updateRoleResult.Message);
            }
        }




        //Route -> getting data of a user from its JWT
        [HttpPost]
        [Route("me")]

        public async Task<ActionResult<LoginServiceResponseDto>> Me([FromBody] MeDto token)
        {
            try
            {
                var me = await _authService.MeAsync(token);
                if(me is not null)
                {
                    return Ok(me);
                }
                else
                {
                    return Unauthorized("Ivalid Token");
                }
            }
            catch (Exception)
            {
                return Unauthorized("Ivalid Token");
            }
        }


        //Route -> List of all users with details
        [HttpGet]
        [Route("users")]

        public async Task<ActionResult<IEnumerable<UserInfoResult>>> Getuserslist()
        {
            var usersList = await _authService.GetUsersListAsync();
            return Ok(usersList);
        }


        //Route -> Get User by UserName
        [HttpGet]
        [Route("users/{userName}")]

        public async Task<ActionResult<UserInfoResult>> GetUserDetailsByUserName([FromRoute] string userName)
        {
            var user = await _authService.GetUserDetailsByUserNameAsync(userName);
            if(user is not null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("UserName not found");
            }

        }


        //Route -> Get List of all usernames for send message
        [HttpGet]
        [Route("usernames")]

        public async Task<ActionResult<IEnumerable<string>>> GetUserNamesList()
        {
            var usernames = await _authService.GetUserNamesListAsync();
            return Ok(usernames);
        }

    }




}

