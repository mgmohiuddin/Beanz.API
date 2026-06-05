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
    public class AllowanceTypesController : ControllerBase
    {
        private readonly IAllowanceTypeRepository _allowanceTypesRepository;

        public AllowanceTypesController(IAllowanceTypeRepository allowanceTypesRepository)
        {
            _allowanceTypesRepository = allowanceTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AllowanceTypeDTO>> GetAllowanceTypes(BeanzCommonDTO common)
        {
            var data = await _allowanceTypesRepository.GetAllowanceTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesRepository.SetAllowanceTypesAsync(common);
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
        public async Task<ActionResult> PostAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesRepository.PostAllowanceTypesAsync(common);
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
        public async Task<ActionResult> DelAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesRepository.DelAllowanceTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAllowanceTypes(BeanzCommonDTO lookup)
        {
            var data = await _allowanceTypesRepository.LookUpAllowanceTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowanceTypeViewModel> GetInfoAllowanceTypes(BeanzCommonDTO common)
        {
            var data = await _allowanceTypesRepository.GetInfoAllowanceTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowanceTypeViewModel> PrintAllowanceTypes(BeanzCommonDTO common)
        {
            var data = await _allowanceTypesRepository.PrintAllowanceTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowanceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowanceTypesRepository.ApproveAllowanceTypesAsync(common);
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
