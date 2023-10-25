using Cosourcing.RH.Contracts.Services.OrganismeSocial;
using Cosourcing.RH.Domain.Entite;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.OrganismeSocial
{
    [Route("api/rh/organismeSocial")]
    [ApiController]
    public class OrganismeSocialController : ControllerBase
	{
		private readonly IOrganismeSocialService _organismeSocialService;

		public OrganismeSocialController(
			IOrganismeSocialService organismeSocialService
		)
		{
			_organismeSocialService = organismeSocialService;
		}

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Save(OrganismeSocialModel organismeSocial)
        {
            try
            {
                var result = await _organismeSocialService.Save(organismeSocial);

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
                var result = await _organismeSocialService.GetEtablissementOrganismeSocials(idEtablissement);

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
                var result = await _organismeSocialService.GetById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrganismeSocial(int id)
        {
            try
            {
                var result = await _organismeSocialService.DeleteOrganismeSocial(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("")]
        [HttpPut]

        public async Task<IActionResult> UpdateOrganismeSocial(OrganismeSocialModel organismeSocial){
            try{
                var result = await _organismeSocialService.UpdateOrganismeSocial(organismeSocial);
                return Ok(result);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }


    }
}

