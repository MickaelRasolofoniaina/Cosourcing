using Cosourcing.RH.Contracts.Services.Etablissement;
using Cosourcing.RH.Domain.Entite;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Cosourcing.RH.Api.Controllers.Etablissement
{
    [Route("api/rh/etablissement")]
    [ApiController]
    [Authorize]
    public class EtablissementController : ControllerBase
	{
		private readonly IEtablissementService _etablissementService;

		public EtablissementController(
			IEtablissementService etablissementService
		)
		{
			_etablissementService = etablissementService;
		}

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save(EtablissementModel etablissement)
        {
            try
            {
                var result = await _etablissementService.Save(etablissement);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int idSociete = -1)
        {
            try
            {
                if(idSociete != -1)
                {
                    var result = await _etablissementService.GetSocieteEtablissements(idSociete);

                    return Ok(result);
                }
                else
                {

                    var result = await _etablissementService.GetAll();

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
                var result = await _etablissementService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteEtablissement(int id)
        {
            try
            {
                var result = await _etablissementService.DeleteEtablissement(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}

