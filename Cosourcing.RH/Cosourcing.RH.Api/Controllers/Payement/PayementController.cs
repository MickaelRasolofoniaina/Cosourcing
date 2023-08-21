using System;
using Cosourcing.RH.Contracts.Services.Payement;
using Cosourcing.RH.Domain.Payement;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.Payement
{
    [Route("api/rh/payement")]
    [ApiController]
    public class PayementController : ControllerBase
	{
		private IPayementService _payementService;

		public PayementController(
			IPayementService payementService
		)
		{
			_payementService = payementService;
		}

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> Save(PayementModel payement)
        {
            try
            {
                var result = await _payementService.Save(payement);

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
                var result = await _payementService.GetAll();

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
                var result = await _payementService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePayement(Guid id)
        {
            try
            {
                var result = await _payementService.DeletePayement(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

