using Cosourcing.RH.Contracts.Services.Societe;
using Cosourcing.RH.Domain.Entite;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.Societe
{
    [Route("api/rh/societe")]
    [ApiController]
    public class SocieteController : ControllerBase
    {
        private ISocieteService _societeService;

        public SocieteController(
            ISocieteService societeService
        )
        {
            _societeService = societeService;
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save(SocieteModel societe)
        {
            try
            {
                var result = await _societeService.Save(societe);

                return Ok(result);
            }
            catch (Exception ex)
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
                var result = await _societeService.GetAll();

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
                var result = await _societeService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}

