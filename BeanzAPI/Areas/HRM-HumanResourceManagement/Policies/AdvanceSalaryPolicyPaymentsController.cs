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
    public class AdvanceSalaryPolicyPaymentsController : ControllerBase
    {
        private readonly IAdvanceSalaryPolicyPaymentRepository _advanceSalaryPolicyPaymentsRepository;

        public AdvanceSalaryPolicyPaymentsController(IAdvanceSalaryPolicyPaymentRepository advanceSalaryPolicyPaymentsRepository)
        {
            _advanceSalaryPolicyPaymentsRepository = advanceSalaryPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AdvanceSalaryPolicyPaymentDTO>> GetAdvanceSalaryPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPolicyPaymentsRepository.GetAdvanceSalaryPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAdvanceSalaryPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyPaymentsRepository.SetAdvanceSalaryPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostAdvanceSalaryPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyPaymentsRepository.PostAdvanceSalaryPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelAdvanceSalaryPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyPaymentsRepository.DelAdvanceSalaryPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _advanceSalaryPolicyPaymentsRepository.LookUpAdvanceSalaryPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AdvanceSalaryPolicyPaymentViewModel> GetInfoAdvanceSalaryPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPolicyPaymentsRepository.GetInfoAdvanceSalaryPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AdvanceSalaryPolicyPaymentViewModel> PrintAdvanceSalaryPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _advanceSalaryPolicyPaymentsRepository.PrintAdvanceSalaryPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAdvanceSalaryPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _advanceSalaryPolicyPaymentsRepository.ApproveAdvanceSalaryPolicyPaymentsAsync(common);
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
