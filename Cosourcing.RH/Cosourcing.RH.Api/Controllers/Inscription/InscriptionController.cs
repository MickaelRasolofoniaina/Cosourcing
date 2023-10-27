using Cosourcing.RH.Contracts.Services.Inscription;
using Cosourcing.RH.Domain.Entite;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.Inscription
{
    [Route("api/rh/inscription")]
    [ApiController]
    public class InscriptionController : ControllerBase
	{
		private readonly IInscriptionService _inscriptionService;

		public InscriptionController(
			IInscriptionService inscriptionService
		)
		{
			_inscriptionService = inscriptionService;
		}

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save(InscriptionModel inscription)
        {
            try
            {
                var result = await _inscriptionService.Save(inscription);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int idEtablissement = -1, [FromQuery] int idServiceImpot = -1)
        {
            try
            {            
                var result = await _inscriptionService.GetEtablissementInscriptions(idEtablissement, idServiceImpot);

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
                var result = await _inscriptionService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteInscription(int id)
        {
            try
            {
                var result = await _inscriptionService.DeleteInscription(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("")]
        [HttpPut]

        public async Task<IActionResult> UpdateInscription(InscriptionModel inscription){
            try{
                var result = await _inscriptionService.UpdateInscription(inscription);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }


    }
}

