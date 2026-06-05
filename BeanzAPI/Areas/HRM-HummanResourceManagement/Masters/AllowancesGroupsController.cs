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
    public class AllowancesGroupsController : ControllerBase
    {
        private readonly IAllowancesGroupRepository _allowancesGroupsRepository;

        public AllowancesGroupsController(IAllowancesGroupRepository allowancesGroupsRepository)
        {
            _allowancesGroupsRepository = allowancesGroupsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AllowancesGroupDTO>> GetAllowancesGroups(BeanzCommonDTO common)
        {
            var data = await _allowancesGroupsRepository.GetAllowancesGroupsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowancesGroups(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesGroupsRepository.SetAllowancesGroupsAsync(common);
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
        public async Task<ActionResult> PostAllowancesGroups(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesGroupsRepository.PostAllowancesGroupsAsync(common);
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
        public async Task<ActionResult> DelAllowancesGroups(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesGroupsRepository.DelAllowancesGroupsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAllowancesGroups(BeanzCommonDTO lookup)
        {
            var data = await _allowancesGroupsRepository.LookUpAllowancesGroupsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowancesGroupViewModel> GetInfoAllowancesGroups(BeanzCommonDTO common)
        {
            var data = await _allowancesGroupsRepository.GetInfoAllowancesGroupsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowancesGroupViewModel> PrintAllowancesGroups(BeanzCommonDTO common)
        {
            var data = await _allowancesGroupsRepository.PrintAllowancesGroupsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowancesGroups(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancesGroupsRepository.ApproveAllowancesGroupsAsync(common);
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
