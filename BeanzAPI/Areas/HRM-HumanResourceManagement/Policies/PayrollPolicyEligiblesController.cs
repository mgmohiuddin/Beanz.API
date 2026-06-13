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
    public class PayrollPolicyEligiblesController : ControllerBase
    {
        private readonly IPayrollPolicyEligibleRepository _payrollPolicyEligiblesRepository;

        public PayrollPolicyEligiblesController(IPayrollPolicyEligibleRepository payrollPolicyEligiblesRepository)
        {
            _payrollPolicyEligiblesRepository = payrollPolicyEligiblesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PayrollPolicyEligibleDTO>> GetPayrollPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _payrollPolicyEligiblesRepository.GetPayrollPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPayrollPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyEligiblesRepository.SetPayrollPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> PostPayrollPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyEligiblesRepository.PostPayrollPolicyEligiblesAsync(common);
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
        public async Task<ActionResult> DelPayrollPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyEligiblesRepository.DelPayrollPolicyEligiblesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPayrollPolicyEligibles(BeanzCommonDTO lookup)
        {
            var data = await _payrollPolicyEligiblesRepository.LookUpPayrollPolicyEligiblesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PayrollPolicyEligibleViewModel> GetInfoPayrollPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _payrollPolicyEligiblesRepository.GetInfoPayrollPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PayrollPolicyEligibleViewModel> PrintPayrollPolicyEligibles(BeanzCommonDTO common)
        {
            var data = await _payrollPolicyEligiblesRepository.PrintPayrollPolicyEligiblesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePayrollPolicyEligibles(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPolicyEligiblesRepository.ApprovePayrollPolicyEligiblesAsync(common);
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
