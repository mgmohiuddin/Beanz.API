using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class TicketPolicyPaymentsController : ControllerBase
    {
        private readonly ITicketPolicyPaymentRepository _ticketPolicyPaymentsRepository;

        public TicketPolicyPaymentsController(ITicketPolicyPaymentRepository ticketPolicyPaymentsRepository)
        {
            _ticketPolicyPaymentsRepository = ticketPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TicketPolicyPaymentDTO>> GetTicketPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _ticketPolicyPaymentsRepository.GetTicketPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTicketPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPolicyPaymentsRepository.SetTicketPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostTicketPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPolicyPaymentsRepository.PostTicketPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelTicketPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPolicyPaymentsRepository.DelTicketPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTicketPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _ticketPolicyPaymentsRepository.LookUpTicketPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TicketPolicyPaymentViewModel> GetInfoTicketPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _ticketPolicyPaymentsRepository.GetInfoTicketPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TicketPolicyPaymentViewModel> PrintTicketPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _ticketPolicyPaymentsRepository.PrintTicketPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTicketPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketPolicyPaymentsRepository.ApproveTicketPolicyPaymentsAsync(common);
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
