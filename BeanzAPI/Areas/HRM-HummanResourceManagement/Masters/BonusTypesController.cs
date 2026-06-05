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
    public class BonusTypesController : ControllerBase
    {
        private readonly IBonusTypeRepository _bonusTypesRepository;

        public BonusTypesController(IBonusTypeRepository bonusTypesRepository)
        {
            _bonusTypesRepository = bonusTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BonusTypeDTO>> GetBonusTypes(BeanzCommonDTO common)
        {
            var data = await _bonusTypesRepository.GetBonusTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBonusTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesRepository.SetBonusTypesAsync(common);
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
        public async Task<ActionResult> PostBonusTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesRepository.PostBonusTypesAsync(common);
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
        public async Task<ActionResult> DelBonusTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesRepository.DelBonusTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBonusTypes(BeanzCommonDTO lookup)
        {
            var data = await _bonusTypesRepository.LookUpBonusTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BonusTypeViewModel> GetInfoBonusTypes(BeanzCommonDTO common)
        {
            var data = await _bonusTypesRepository.GetInfoBonusTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BonusTypeViewModel> PrintBonusTypes(BeanzCommonDTO common)
        {
            var data = await _bonusTypesRepository.PrintBonusTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBonusTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesRepository.ApproveBonusTypesAsync(common);
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
