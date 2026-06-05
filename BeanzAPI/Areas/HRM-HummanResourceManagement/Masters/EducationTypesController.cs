using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class EducationTypesController : ControllerBase
    {
        private readonly IEducationTypeRepository _educationTypesRepository;

        public EducationTypesController(IEducationTypeRepository educationTypesRepository)
        {
            _educationTypesRepository = educationTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EducationTypeDTO>> GetEducationTypes(BeanzCommonDTO common)
        {
            var data = await _educationTypesRepository.GetEducationTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEducationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _educationTypesRepository.SetEducationTypesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Post")]
        public async Task<ActionResult> PostEducationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _educationTypesRepository.PostEducationTypesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Del")]
        public async Task<ActionResult> DelEducationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _educationTypesRepository.DelEducationTypesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("LookUp")]
        public async Task<List<BeanzlookupDTO>> LookUpEducationTypes(BeanzCommonDTO lookup)
        {
            var data = await _educationTypesRepository.LookUpEducationTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EducationTypeViewModel> GetInfoEducationTypes(BeanzCommonDTO common)
        {
            var data = await _educationTypesRepository.GetInfoEducationTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EducationTypeViewModel> PrintEducationTypes(BeanzCommonDTO common)
        {
            var data = await _educationTypesRepository.PrintEducationTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEducationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _educationTypesRepository.ApproveEducationTypesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }
    }
}
