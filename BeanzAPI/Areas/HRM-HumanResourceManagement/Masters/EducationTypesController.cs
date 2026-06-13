using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class EducationTypesController : ControllerBase
    {
        private readonly IEducationTypeBusiness _educationTypesBusiness;

        public EducationTypesController(IEducationTypeBusiness educationTypesBusiness)
        {
            _educationTypesBusiness = educationTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<EducationTypeDTO>> GetEducationTypes(BeanzCommonDTO common)
        {
            var data = await _educationTypesBusiness.GetEducationTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEducationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _educationTypesBusiness.SetEducationTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _educationTypesBusiness.PostEducationTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _educationTypesBusiness.DelEducationTypesAsync(common);
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
            var data = await _educationTypesBusiness.LookUpEducationTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EducationTypeViewModel> GetInfoEducationTypes(BeanzCommonDTO common)
        {
            var data = await _educationTypesBusiness.GetInfoEducationTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EducationTypeViewModel> PrintEducationTypes(BeanzCommonDTO common)
        {
            var data = await _educationTypesBusiness.PrintEducationTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEducationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _educationTypesBusiness.ApproveEducationTypesAsync(common);
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
