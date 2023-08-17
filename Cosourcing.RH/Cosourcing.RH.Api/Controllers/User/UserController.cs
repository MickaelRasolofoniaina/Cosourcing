using System;
using Cosourcing.RH.Contracts.Services.User;
using Cosourcing.RH.Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.User
{
    [Route("api/rh/user")]
    [ApiController]
    public class UserController : ControllerBase
	{
		private IUserService _userService;

		public UserController(
			IUserService userService
		)
		{
			_userService = userService;
		}

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save(UserModel user)
        {
            try
            {
                var result = await _userService.Save(user);

                return Ok(result);
            }
            catch(Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}

