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
    public class BusinessTripTypesController : ControllerBase
    {
        private readonly IBusinessTripTypeBusiness _businessTripTypesBusiness;

        public BusinessTripTypesController(IBusinessTripTypeBusiness businessTripTypesBusiness)
        {
            _businessTripTypesBusiness = businessTripTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<BusinessTripTypeDTO>> GetBusinessTripTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripTypesBusiness.GetBusinessTripTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBusinessTripTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripTypesBusiness.SetBusinessTripTypesAsync(common);
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
        public async Task<ActionResult> PostBusinessTripTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripTypesBusiness.PostBusinessTripTypesAsync(common);
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
        public async Task<ActionResult> DelBusinessTripTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripTypesBusiness.DelBusinessTripTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBusinessTripTypes(BeanzCommonDTO lookup)
        {
            var data = await _businessTripTypesBusiness.LookUpBusinessTripTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BusinessTripTypeViewModel> GetInfoBusinessTripTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripTypesBusiness.GetInfoBusinessTripTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BusinessTripTypeViewModel> PrintBusinessTripTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripTypesBusiness.PrintBusinessTripTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBusinessTripTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripTypesBusiness.ApproveBusinessTripTypesAsync(common);
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
