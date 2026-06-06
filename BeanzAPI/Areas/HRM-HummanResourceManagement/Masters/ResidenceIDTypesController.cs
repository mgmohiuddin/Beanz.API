using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class ResidenceIDTypesController : ControllerBase
    {
        private readonly IResidenceIDTypeBusiness _residenceIDTypesBusiness;

        public ResidenceIDTypesController(IResidenceIDTypeBusiness residenceIDTypesBusiness)
        {
            _residenceIDTypesBusiness = residenceIDTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<ResidenceIDTypeDTO>> GetResidenceIDTypes(BeanzCommonDTO common)
        {
            var data = await _residenceIDTypesBusiness.GetResidenceIDTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetResidenceIDTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesBusiness.SetResidenceIDTypesAsync(common);
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
        public async Task<ActionResult> PostResidenceIDTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesBusiness.PostResidenceIDTypesAsync(common);
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
        public async Task<ActionResult> DelResidenceIDTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesBusiness.DelResidenceIDTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpResidenceIDTypes(BeanzCommonDTO lookup)
        {
            var data = await _residenceIDTypesBusiness.LookUpResidenceIDTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ResidenceIDTypeViewModel> GetInfoResidenceIDTypes(BeanzCommonDTO common)
        {
            var data = await _residenceIDTypesBusiness.GetInfoResidenceIDTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ResidenceIDTypeViewModel> PrintResidenceIDTypes(BeanzCommonDTO common)
        {
            var data = await _residenceIDTypesBusiness.PrintResidenceIDTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveResidenceIDTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesBusiness.ApproveResidenceIDTypesAsync(common);
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
