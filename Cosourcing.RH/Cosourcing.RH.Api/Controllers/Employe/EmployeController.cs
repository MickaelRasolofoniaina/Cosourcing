using Cosourcing.RH.Contracts.Services.Employe;
using Cosourcing.RH.Domain.Entite;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.Employe
{
    [Route("api/rh/employe")]
    [ApiController]
    public class EmployeController : ControllerBase
	{
		private readonly IEmployeService _employeService;

		public EmployeController(
			IEmployeService employeService
		)
		{
			_employeService = employeService;
		}

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save(EmployeModel employe)
        {
            try
            {
                var result = await _employeService.Save(employe);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int idEtablissement = -1)
        {
            try
            {
                if(idEtablissement != -1)
                {
                    var result = await _employeService.GetEtablissementEmployes(idEtablissement);

                    return Ok(result);
                }
                else
                {

                    var result = await _employeService.GetAll();

                    return Ok(result);
                }
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
                var result = await _employeService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEmploye(int id)
        {
            try
            {
                var result = await _employeService.DeleteEmploye(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

