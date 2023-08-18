using System;
using Cosourcing.RH.Contracts.Services.User;
using Cosourcing.RH.Domain.Request.User;
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _userService.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _userService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                var result = await _userService.DeleteUser(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("update-email/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmail(Guid id, [FromBody] UpdateEmailRequest updateEmailRequest)
        {
            try
            {
                var result = await _userService.UpdateEmail(id, updateEmailRequest.Email);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

