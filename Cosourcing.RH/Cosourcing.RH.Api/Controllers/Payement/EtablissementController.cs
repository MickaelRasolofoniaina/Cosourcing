using System;
using Cosourcing.RH.Contracts.Services.Etablissement;
using Cosourcing.RH.Domain.Etablissement;
using Microsoft.AspNetCore.Mvc;

namespace Cosourcing.RH.Api.Controllers.Etablissement
{
    [Route("api/rh/etablissement")]
    [ApiController]
    public class EtablissementController : ControllerBase
	{
		private IEtablissementService _etablissementService;

		public EtablissementController(
			IEtablissementService etablissementService
		)
		{
			_etablissementService = etablissementService;
		}

        [Route("save")]
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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _etablissementService.GetAll();

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
        public async Task<IActionResult> DeleteEtablissement(Guid id)
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

