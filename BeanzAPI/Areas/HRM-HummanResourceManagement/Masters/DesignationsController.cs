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
    public class DesignationsController : ControllerBase
    {
        private readonly IDesignationRepository _designationsRepository;

        public DesignationsController(IDesignationRepository designationsRepository)
        {
            _designationsRepository = designationsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<DesignationDTO>> GetDesignations(BeanzCommonDTO common)
        {
            var data = await _designationsRepository.GetDesignationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsRepository.SetDesignationsAsync(common);
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
        public async Task<ActionResult> PostDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsRepository.PostDesignationsAsync(common);
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
        public async Task<ActionResult> DelDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsRepository.DelDesignationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpDesignations(BeanzCommonDTO lookup)
        {
            var data = await _designationsRepository.LookUpDesignationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<DesignationViewModel> GetInfoDesignations(BeanzCommonDTO common)
        {
            var data = await _designationsRepository.GetInfoDesignationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<DesignationViewModel> PrintDesignations(BeanzCommonDTO common)
        {
            var data = await _designationsRepository.PrintDesignationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsRepository.ApproveDesignationsAsync(common);
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
