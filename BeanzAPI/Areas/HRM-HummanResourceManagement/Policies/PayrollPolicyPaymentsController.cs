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
    public class PayrollPolicyPaymentsController : ControllerBase
    {
        private readonly IPayrollPolicyPaymentRepository _payrollPolicyPaymentsRepository;

        public PayrollPolicyPaymentsController(IPayrollPolicyPaymentRepository payrollPolicyPaymentsRepository)
        {
            _payrollPolicyPaymentsRepository = payrollPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PayrollPolicyPaymentDTO>> GetPayrollPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _payrollPolicyPaymentsRepository.GetPayrollPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPayrollPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyPaymentsRepository.SetPayrollPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostPayrollPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyPaymentsRepository.PostPayrollPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelPayrollPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyPaymentsRepository.DelPayrollPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPayrollPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _payrollPolicyPaymentsRepository.LookUpPayrollPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PayrollPolicyPaymentViewModel> GetInfoPayrollPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _payrollPolicyPaymentsRepository.GetInfoPayrollPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PayrollPolicyPaymentViewModel> PrintPayrollPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _payrollPolicyPaymentsRepository.PrintPayrollPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePayrollPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyPaymentsRepository.ApprovePayrollPolicyPaymentsAsync(common);
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
