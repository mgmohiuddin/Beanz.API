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
    public class SponsorsController : ControllerBase
    {
        private readonly ISponsorBusiness _sponsorsBusiness;

        public SponsorsController(ISponsorBusiness sponsorsBusiness)
        {
            _sponsorsBusiness = sponsorsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<SponsorDTO>> GetSponsors(BeanzCommonDTO common)
        {
            var data = await _sponsorsBusiness.GetSponsorsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetSponsors(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _sponsorsBusiness.SetSponsorsAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _sponsorsBusiness.PostSponsorsAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _sponsorsBusiness.DelSponsorsAsync(common);
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
            var data = await _sponsorsBusiness.LookUpSponsorsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<SponsorViewModel> GetInfoSponsors(BeanzCommonDTO common)
        {
            var data = await _sponsorsBusiness.GetInfoSponsorsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<SponsorViewModel> PrintSponsors(BeanzCommonDTO common)
        {
            var data = await _sponsorsBusiness.PrintSponsorsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveSponsors(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _sponsorsBusiness.ApproveSponsorsAsync(common);
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
