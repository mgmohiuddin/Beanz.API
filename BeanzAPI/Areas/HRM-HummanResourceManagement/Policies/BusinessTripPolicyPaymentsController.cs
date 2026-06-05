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
    public class BusinessTripPolicyPaymentsController : ControllerBase
    {
        private readonly IBusinessTripPolicyPaymentRepository _businessTripPolicyPaymentsRepository;

        public BusinessTripPolicyPaymentsController(IBusinessTripPolicyPaymentRepository businessTripPolicyPaymentsRepository)
        {
            _businessTripPolicyPaymentsRepository = businessTripPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BusinessTripPolicyPaymentDTO>> GetBusinessTripPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _businessTripPolicyPaymentsRepository.GetBusinessTripPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBusinessTripPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyPaymentsRepository.SetBusinessTripPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostBusinessTripPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyPaymentsRepository.PostBusinessTripPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelBusinessTripPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyPaymentsRepository.DelBusinessTripPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBusinessTripPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _businessTripPolicyPaymentsRepository.LookUpBusinessTripPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BusinessTripPolicyPaymentViewModel> GetInfoBusinessTripPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _businessTripPolicyPaymentsRepository.GetInfoBusinessTripPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BusinessTripPolicyPaymentViewModel> PrintBusinessTripPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _businessTripPolicyPaymentsRepository.PrintBusinessTripPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBusinessTripPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _businessTripPolicyPaymentsRepository.ApproveBusinessTripPolicyPaymentsAsync(common);
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
