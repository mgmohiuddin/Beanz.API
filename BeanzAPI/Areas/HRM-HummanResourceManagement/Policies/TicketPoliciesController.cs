using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class TicketPoliciesController : ControllerBase
    {
        private readonly ITicketPolicieRepository _ticketPoliciesRepository;

        public TicketPoliciesController(ITicketPolicieRepository ticketPoliciesRepository)
        {
            _ticketPoliciesRepository = ticketPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TicketPolicieDTO>> GetTicketPolicies(BeanzCommonDTO common)
        {
            var data = await _ticketPoliciesRepository.GetTicketPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTicketPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPoliciesRepository.SetTicketPoliciesAsync(common);
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
        public async Task<ActionResult> PostTicketPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPoliciesRepository.PostTicketPoliciesAsync(common);
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
        public async Task<ActionResult> DelTicketPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPoliciesRepository.DelTicketPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTicketPolicies(BeanzCommonDTO lookup)
        {
            var data = await _ticketPoliciesRepository.LookUpTicketPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TicketPolicieViewModel> GetInfoTicketPolicies(BeanzCommonDTO common)
        {
            var data = await _ticketPoliciesRepository.GetInfoTicketPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TicketPolicieViewModel> PrintTicketPolicies(BeanzCommonDTO common)
        {
            var data = await _ticketPoliciesRepository.PrintTicketPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTicketPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPoliciesRepository.ApproveTicketPoliciesAsync(common);
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
