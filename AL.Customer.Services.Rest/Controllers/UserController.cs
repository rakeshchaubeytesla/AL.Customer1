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
        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Get()
        {
            return userService.GetAllUsers();
        }

        [HttpPost("register")]
        public bool Register(RegisterViewModel registerDtos)
        {
            return userService.RegisterUser(registerDtos);
        }

        [HttpPost("login")]
        public async Task<ActionResult<bool>> Login(LoginDto loginDtos)
        {
            var user = userService.GetUserByUsername(loginDtos.UserName);
            if (user == null) return Unauthorized("InValid User");

            return userService.ValidatePassword(loginDtos);
        }

    }
}
