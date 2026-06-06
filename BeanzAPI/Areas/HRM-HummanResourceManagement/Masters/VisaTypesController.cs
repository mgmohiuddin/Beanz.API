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
    public class VisaTypesController : ControllerBase
    {
        private readonly IVisaTypeBusiness _visaTypesBusiness;

        public VisaTypesController(IVisaTypeBusiness visaTypesBusiness)
        {
            _visaTypesBusiness = visaTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<VisaTypeDTO>> GetVisaTypes(BeanzCommonDTO common)
        {
            var data = await _visaTypesBusiness.GetVisaTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesBusiness.SetVisaTypesAsync(common);
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
        public async Task<ActionResult> PostVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesBusiness.PostVisaTypesAsync(common);
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
        public async Task<ActionResult> DelVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesBusiness.DelVisaTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpVisaTypes(BeanzCommonDTO lookup)
        {
            var data = await _visaTypesBusiness.LookUpVisaTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VisaTypeViewModel> GetInfoVisaTypes(BeanzCommonDTO common)
        {
            var data = await _visaTypesBusiness.GetInfoVisaTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VisaTypeViewModel> PrintVisaTypes(BeanzCommonDTO common)
        {
            var data = await _visaTypesBusiness.PrintVisaTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesBusiness.ApproveVisaTypesAsync(common);
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
