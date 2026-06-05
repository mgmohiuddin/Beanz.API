
//using System.Text.Json;
using Beanz.Core.BeanzRoutes;
using Beanz.DTOs.BeanzRoutes;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pipelines.Sockets.Unofficial.Arenas;

namespace Beanz.API.Controllers.BeanzRoutes
{
    [Route("api/[controller]")]
    [ApiController]
   // [Area("FinancialAccountingSystem")]
    public class BeanzScriptController : ControllerBase
    {
        private readonly IBeanzScriptRepository _scriptRepository;

        public BeanzScriptController(IBeanzScriptRepository scriptRepository)
        {
            _scriptRepository = scriptRepository; 
        }

        [HttpPost("Execute")]
        public async Task<IActionResult> Execute([FromBody] ScriptParameterDTO script)
        {
            var result = await _scriptRepository.ExecuteScriptAsync(script);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }


        [HttpPost("ExecuteDefinition")]
        public async Task<IActionResult> ExecuteDefinition([FromBody] ScriptDefinitionParameterDTO script)
        {
            var result = await _scriptRepository.ExecuteDefinitionScriptAsync(script);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }



        [HttpPost("ExecuteSP")]
        public async Task<IActionResult> ExecuteSP([FromBody] ScriptParameterDTO script)
        {
            var result = await _scriptRepository.ExecuteSPAsync(script);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }


        [HttpPost("GetDatabaseObjects")]
        public async Task<IActionResult> GetDatabaseObjects(
        [FromBody] ScriptParameterDTO dto)
        {
            var result = await _scriptRepository.GetDatabaseObjectsAsync(dto);

            return Ok(result);
        }

        [HttpPost("GetDatabaseTableDetails")]
        public async Task<IActionResult> GetDatabaseTableDetails([FromBody] ScriptParameterDTO dto)
        {
            var result =
                await _scriptRepository.GetDatabaseTableDetailsAsync(dto);

            return Ok(result);
        }
    }
}