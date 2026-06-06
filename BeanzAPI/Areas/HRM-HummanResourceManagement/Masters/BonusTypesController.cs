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
    public class BonusTypesController : ControllerBase
    {
        private readonly IBonusTypeBusiness _bonusTypesBusiness;

        public BonusTypesController(IBonusTypeBusiness bonusTypesBusiness)
        {
            _bonusTypesBusiness = bonusTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<BonusTypeDTO>> GetBonusTypes(BeanzCommonDTO common)
        {
            var data = await _bonusTypesBusiness.GetBonusTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBonusTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesBusiness.SetBonusTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesBusiness.PostBonusTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesBusiness.DelBonusTypesAsync(common);
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
            var data = await _bonusTypesBusiness.LookUpBonusTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BonusTypeViewModel> GetInfoBonusTypes(BeanzCommonDTO common)
        {
            var data = await _bonusTypesBusiness.GetInfoBonusTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BonusTypeViewModel> PrintBonusTypes(BeanzCommonDTO common)
        {
            var data = await _bonusTypesBusiness.PrintBonusTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBonusTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusTypesBusiness.ApproveBonusTypesAsync(common);
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
