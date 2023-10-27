using Cosourcing.RH.Contracts.Services.ServiceImpot;
using Cosourcing.RH.Domain.Entite;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.ServiceImpot
{
    [Route("api/rh/serviceImpot")]
    [ApiController]
    public class ServiceImpotController : ControllerBase
	{
		private readonly IServiceImpotService _serviceImpotService;

		public ServiceImpotController(
			IServiceImpotService serviceImpotService
		)
		{
			_serviceImpotService = serviceImpotService;
		}

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save(ServiceImpotModel serviceImpot)
        {
            try
            {
                var result = await _serviceImpotService.Save(serviceImpot);

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
                var result = await _serviceImpotService.GetAll();

                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _serviceImpotService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteServiceImpot(int id)
        {
            try
            {
                var result = await _serviceImpotService.DeleteServiceImpot(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("")]
        [HttpPut]

        public async Task<IActionResult> UpdateServiceImpot(ServiceImpotModel serviceImpot){
            try{
                var result = await _serviceImpotService.UpdateServiceImpot(serviceImpot);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }


    }
}

