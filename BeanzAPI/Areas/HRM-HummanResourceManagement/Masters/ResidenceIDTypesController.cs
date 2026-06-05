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
    public class ResidenceIDTypesController : ControllerBase
    {
        private readonly IResidenceIDTypeRepository _residenceIDTypesRepository;

        public ResidenceIDTypesController(IResidenceIDTypeRepository residenceIDTypesRepository)
        {
            _residenceIDTypesRepository = residenceIDTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<ResidenceIDTypeDTO>> GetResidenceIDTypes(BeanzCommonDTO common)
        {
            var data = await _residenceIDTypesRepository.GetResidenceIDTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetResidenceIDTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesRepository.SetResidenceIDTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesRepository.PostResidenceIDTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesRepository.DelResidenceIDTypesAsync(common);
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
            var data = await _residenceIDTypesRepository.LookUpResidenceIDTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<ResidenceIDTypeViewModel> GetInfoResidenceIDTypes(BeanzCommonDTO common)
        {
            var data = await _residenceIDTypesRepository.GetInfoResidenceIDTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<ResidenceIDTypeViewModel> PrintResidenceIDTypes(BeanzCommonDTO common)
        {
            var data = await _residenceIDTypesRepository.PrintResidenceIDTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveResidenceIDTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _residenceIDTypesRepository.ApproveResidenceIDTypesAsync(common);
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
