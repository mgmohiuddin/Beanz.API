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
    public class TravelTypesController : ControllerBase
    {
        private readonly ITravelTypeRepository _travelTypesRepository;

        public TravelTypesController(ITravelTypeRepository travelTypesRepository)
        {
            _travelTypesRepository = travelTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TravelTypeDTO>> GetTravelTypes(BeanzCommonDTO common)
        {
            var data = await _travelTypesRepository.GetTravelTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTravelTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _travelTypesRepository.SetTravelTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _travelTypesRepository.PostTravelTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _travelTypesRepository.DelTravelTypesAsync(common);
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
            var data = await _travelTypesRepository.LookUpTravelTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TravelTypeViewModel> GetInfoTravelTypes(BeanzCommonDTO common)
        {
            var data = await _travelTypesRepository.GetInfoTravelTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TravelTypeViewModel> PrintTravelTypes(BeanzCommonDTO common)
        {
            var data = await _travelTypesRepository.PrintTravelTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTravelTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _travelTypesRepository.ApproveTravelTypesAsync(common);
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
