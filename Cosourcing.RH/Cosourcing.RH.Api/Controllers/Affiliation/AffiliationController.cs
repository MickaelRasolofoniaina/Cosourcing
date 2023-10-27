using Cosourcing.RH.Contracts.Services.Affiliation;
using Cosourcing.RH.Domain.Entite;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.Affiliation
{
    [Route("api/rh/affiliation")]
    [ApiController]
    public class AffiliationController : ControllerBase
	{
		private readonly IAffiliationService _affiliationService;

		public AffiliationController(
			IAffiliationService affiliationService
		)
		{
			_affiliationService = affiliationService;
		}

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save(AffiliationModel affiliation)
        {
            try
            {
                var result = await _affiliationService.Save(affiliation);

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int idEtablissement = -1, [FromQuery] int idOrganismeSocial = -1)
        {
            try
            {            
                var result = await _affiliationService.GetEtablissementAffiliations(idEtablissement, idOrganismeSocial);

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
                var result = await _affiliationService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAffiliation(int id)
        {
            try
            {
                var result = await _affiliationService.DeleteAffiliation(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("")]
        [HttpPut]

        public async Task<IActionResult> UpdateAffiliation(AffiliationModel affiliation){
            try{
                var result = await _affiliationService.UpdateAffiliation(affiliation);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }


    }
}

