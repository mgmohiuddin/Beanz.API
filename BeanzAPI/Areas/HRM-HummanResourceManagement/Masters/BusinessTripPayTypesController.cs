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
    public class BusinessTripPayTypesController : ControllerBase
    {
        private readonly IBusinessTripPayTypeRepository _businessTripPayTypesRepository;

        public BusinessTripPayTypesController(IBusinessTripPayTypeRepository businessTripPayTypesRepository)
        {
            _businessTripPayTypesRepository = businessTripPayTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BusinessTripPayTypeDTO>> GetBusinessTripPayTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripPayTypesRepository.GetBusinessTripPayTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBusinessTripPayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesRepository.SetBusinessTripPayTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesRepository.PostBusinessTripPayTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesRepository.DelBusinessTripPayTypesAsync(common);
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
            var data = await _businessTripPayTypesRepository.LookUpBusinessTripPayTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BusinessTripPayTypeViewModel> GetInfoBusinessTripPayTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripPayTypesRepository.GetInfoBusinessTripPayTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BusinessTripPayTypeViewModel> PrintBusinessTripPayTypes(BeanzCommonDTO common)
        {
            var data = await _businessTripPayTypesRepository.PrintBusinessTripPayTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBusinessTripPayTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPayTypesRepository.ApproveBusinessTripPayTypesAsync(common);
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
