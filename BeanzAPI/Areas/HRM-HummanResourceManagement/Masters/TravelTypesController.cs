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
    public class TravelTypesController : ControllerBase
    {
        private readonly ITravelTypeBusiness _travelTypesBusiness;

        public TravelTypesController(ITravelTypeBusiness travelTypesBusiness)
        {
            _travelTypesBusiness = travelTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<TravelTypeDTO>> GetTravelTypes(BeanzCommonDTO common)
        {
            var data = await _travelTypesBusiness.GetTravelTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTravelTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _travelTypesBusiness.SetTravelTypesAsync(common);
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
        public async Task<ActionResult> PostTravelTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _travelTypesBusiness.PostTravelTypesAsync(common);
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
        public async Task<ActionResult> DelTravelTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _travelTypesBusiness.DelTravelTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTravelTypes(BeanzCommonDTO lookup)
        {
            var data = await _travelTypesBusiness.LookUpTravelTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TravelTypeViewModel> GetInfoTravelTypes(BeanzCommonDTO common)
        {
            var data = await _travelTypesBusiness.GetInfoTravelTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TravelTypeViewModel> PrintTravelTypes(BeanzCommonDTO common)
        {
            var data = await _travelTypesBusiness.PrintTravelTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTravelTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _travelTypesBusiness.ApproveTravelTypesAsync(common);
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
