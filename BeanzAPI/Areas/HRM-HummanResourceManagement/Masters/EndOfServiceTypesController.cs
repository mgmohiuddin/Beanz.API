using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class EndOfServiceTypesController : ControllerBase
    {
        private readonly IEndOfServiceTypeBusiness _endOfServiceTypesBusiness;

        public EndOfServiceTypesController(IEndOfServiceTypeBusiness endOfServiceTypesBusiness)
        {
            _endOfServiceTypesBusiness = endOfServiceTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<EndOfServiceTypeDTO>> GetEndOfServiceTypes(BeanzCommonDTO common)
        {
            var data = await _endOfServiceTypesBusiness.GetEndOfServiceTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEndOfServiceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServiceTypesBusiness.SetEndOfServiceTypesAsync(common);
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
        public async Task<ActionResult> PostEndOfServiceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServiceTypesBusiness.PostEndOfServiceTypesAsync(common);
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
        public async Task<ActionResult> DelEndOfServiceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServiceTypesBusiness.DelEndOfServiceTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEndOfServiceTypes(BeanzCommonDTO lookup)
        {
            var data = await _endOfServiceTypesBusiness.LookUpEndOfServiceTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EndOfServiceTypeViewModel> GetInfoEndOfServiceTypes(BeanzCommonDTO common)
        {
            var data = await _endOfServiceTypesBusiness.GetInfoEndOfServiceTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EndOfServiceTypeViewModel> PrintEndOfServiceTypes(BeanzCommonDTO common)
        {
            var data = await _endOfServiceTypesBusiness.PrintEndOfServiceTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEndOfServiceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _endOfServiceTypesBusiness.ApproveEndOfServiceTypesAsync(common);
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
