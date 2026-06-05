
//using System.Text.Json;
using Beanz.Core.BeanzRoutes;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pipelines.Sockets.Unofficial.Arenas;

namespace Beanz.API.Controllers.BeanzRoutes
{
    [Route("api/[controller]")]
    [ApiController]
   // [Area("FinancialAccountingSystem")]
    public class BeanzController : ControllerBase
    {
        private readonly IBeanzRepository _repository;
        private readonly IBeanzPermissionRepository _permission_repository;

        public BeanzController(IBeanzRepository repository, IBeanzPermissionRepository beanzPermissionRepository)
        {
            _repository = repository;
            _permission_repository = beanzPermissionRepository;
        }




        [HttpPost("{system}/{module}/Get")]
        [HttpPost("{system}/{area}/{module}/Get")]
        public async Task<IActionResult> Get(            string system,            string? area,            string module,            [FromBody] BeanzRequestDTO dto)
        {
            dto.system = system;
            dto.area = area;
            dto.module = module;
            dto.Action = "Get";
             //List<BeanzPermissionDTO> result = await _permission_repository.GetBeanzPermissionsAsync(dto);

           //-- if (result != null &&    result.Count > 0 &&    result[0].IsView == true)
            //{
                var data = await _repository.GetAsync(dto);
                return Ok(data);
           // }
            //else
            //{
              //  return BadRequest("No Permission");
           // }

            


        }

        [HttpPost("{system}/{module}/Set")]
        [HttpPost("{system}/{area}/{module}/Set")]
        public async Task<IActionResult> Set(string system,            string? area,            string module, [FromBody] BeanzRequestDTO dto)
        {
            dto.system = system;
            dto.area = area;
            dto.module = module;
            dto.Action = "Set";
            var result = await _repository.SetAsync(dto);

            if (result.ErrorCode != "")
                return BadRequest(result);
             

            return Ok(result);
        }

        [HttpPost("{system}/{module}/Post")]
        [HttpPost("{system}/{area}/{module}/Post")]
        public async Task<IActionResult> Post(string system,            string? area,            string module,            [FromBody] BeanzRequestDTO dto)
        {
            dto.system = system;
            dto.area = area;
            dto.module = module;
            dto.Action = "Post";
            var result = await _repository.PostAsync(dto);

            if (result.ErrorCode != "")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("{system}/{module}/Del")]
        [HttpPost("{system}/{area}/{module}/Del")]
        public async Task<IActionResult> Del(string system,            string? area,            string module,             [FromBody] BeanzRequestDTO dto)
        {
            dto.system = system;
            dto.area = area;
            dto.module = module;
            dto.Action = "Del";
            var result = await _repository.DelAsync(dto);

              if (result.ErrorCode != "")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("{system}/{module}/Lookup")]
        [HttpPost("{system}/{area}/{module}/Lookup")]
        public async Task<IActionResult> Lookup(string system,            string? area,            string module,             [FromBody] BeanzRequestDTO dto)
        {
            dto.system = system;
            dto.area = area;
            dto.module = module;

            dto.Action = "Lookup";
            var data = await _repository.LookupAsync(dto);
            return Ok(data);
        }

        [HttpPost("{system}/{module}/GetInfo")]
        [HttpPost("{system}/{area}/{module}/GetInfo")]
        public async Task<IActionResult> GetInfo(string system,            string? area,            string module,             [FromBody] BeanzRequestDTO dto)
        {
            dto.system = system;
            dto.area = area;
            dto.module = module;
            dto.Action = "GetInfo";
            var data = await _repository.GetInfoAsync(dto);
            return Ok(data);
        }

        [HttpPost("{system}/{module}/Print")]
        [HttpPost("{system}/{area}/{module}/Print")]
        public async Task<IActionResult> Print(string system,            string? area,            string module,            [FromBody] BeanzRequestDTO dto)
        {
            dto.system = system;
            dto.area = area;
            dto.module = module;
            dto.Action = "Print";
            var data = await _repository.PrintAsync(dto);
            return Ok(data);
        }
    }
}