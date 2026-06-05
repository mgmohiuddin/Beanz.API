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
    public class SponsorsController : ControllerBase
    {
        private readonly ISponsorRepository _sponsorsRepository;

        public SponsorsController(ISponsorRepository sponsorsRepository)
        {
            _sponsorsRepository = sponsorsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<SponsorDTO>> GetSponsors(BeanzCommonDTO common)
        {
            var data = await _sponsorsRepository.GetSponsorsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetSponsors(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _sponsorsRepository.SetSponsorsAsync(common);
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
        public async Task<ActionResult> PostSponsors(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _sponsorsRepository.PostSponsorsAsync(common);
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
        public async Task<ActionResult> DelSponsors(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _sponsorsRepository.DelSponsorsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpSponsors(BeanzCommonDTO lookup)
        {
            var data = await _sponsorsRepository.LookUpSponsorsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<SponsorViewModel> GetInfoSponsors(BeanzCommonDTO common)
        {
            var data = await _sponsorsRepository.GetInfoSponsorsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<SponsorViewModel> PrintSponsors(BeanzCommonDTO common)
        {
            var data = await _sponsorsRepository.PrintSponsorsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveSponsors(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _sponsorsRepository.ApproveSponsorsAsync(common);
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
