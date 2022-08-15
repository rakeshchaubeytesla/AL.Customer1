using AL.Customer.Domain.Interface;
using AL.Customer.Effigy.DTOModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AL.Customer.Services.Rest.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserService userService;
        private readonly ITokenService tokenService;
        public UserController(IUserService _userService, ITokenService _tokenService)
        {
            this.userService = _userService;
            this.tokenService = _tokenService;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return userService.GetAllUsers();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public UserDtos Register(RegisterViewModel registerDtos)
        {
            userService.RegisterUser(registerDtos);
            return new UserDtos
            {
                UserName = registerDtos.UserName,
                Token = tokenService.CreateToken(registerDtos.UserName)
            };
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDtos>> Login(LoginDto loginDtos)
        {
            var user = userService.GetUserByUsername(loginDtos.UserName);
            if (user == null) return Unauthorized("InValid User");

            userService.ValidatePassword(loginDtos);
            return new UserDtos
            {
                UserName = user.UserName,
                Token = tokenService.CreateToken(user.UserName)
            };
        }

    }
}
