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
    public class BusinessTripPayTypesController : ControllerBase
    {
        private readonly IBusinessTripPayTypeBusiness _businessTripPayTypesBusiness;

        public BusinessTripPayTypesController(IBusinessTripPayTypeBusiness businessTripPayTypesBusiness)
        {
            _businessTripPayTypesBusiness = businessTripPayTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<BusinessTripPayTypeDTO>> GetBusinessTripPayTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripPayTypesBusiness.GetBusinessTripPayTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBusinessTripPayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesBusiness.SetBusinessTripPayTypesAsync(common);
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
        public async Task<ActionResult> PostBusinessTripPayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesBusiness.PostBusinessTripPayTypesAsync(common);
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
        public async Task<ActionResult> DelBusinessTripPayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesBusiness.DelBusinessTripPayTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBusinessTripPayTypes(BeanzCommonDTO lookup)
        {
            var data = await _businessTripPayTypesBusiness.LookUpBusinessTripPayTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BusinessTripPayTypeViewModel> GetInfoBusinessTripPayTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripPayTypesBusiness.GetInfoBusinessTripPayTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BusinessTripPayTypeViewModel> PrintBusinessTripPayTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripPayTypesBusiness.PrintBusinessTripPayTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBusinessTripPayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesBusiness.ApproveBusinessTripPayTypesAsync(common);
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
