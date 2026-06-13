using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class LeavePolicyPaymentsController : ControllerBase
    {
        private readonly ILeavePolicyPaymentRepository _leavePolicyPaymentsRepository;

        public LeavePolicyPaymentsController(ILeavePolicyPaymentRepository leavePolicyPaymentsRepository)
        {
            _leavePolicyPaymentsRepository = leavePolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LeavePolicyPaymentDTO>> GetLeavePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _leavePolicyPaymentsRepository.GetLeavePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLeavePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyPaymentsRepository.SetLeavePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostLeavePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyPaymentsRepository.PostLeavePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelLeavePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyPaymentsRepository.DelLeavePolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLeavePolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _leavePolicyPaymentsRepository.LookUpLeavePolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LeavePolicyPaymentViewModel> GetInfoLeavePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _leavePolicyPaymentsRepository.GetInfoLeavePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LeavePolicyPaymentViewModel> PrintLeavePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _leavePolicyPaymentsRepository.PrintLeavePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLeavePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _leavePolicyPaymentsRepository.ApproveLeavePolicyPaymentsAsync(common);
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
