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
    public class PayrollPoliciesController : ControllerBase
    {
        private readonly IPayrollPolicieRepository _payrollPoliciesRepository;

        public PayrollPoliciesController(IPayrollPolicieRepository payrollPoliciesRepository)
        {
            _payrollPoliciesRepository = payrollPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PayrollPolicieDTO>> GetPayrollPolicies(BeanzCommonDTO common)
        {
            var data = await _payrollPoliciesRepository.GetPayrollPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPayrollPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPoliciesRepository.SetPayrollPoliciesAsync(common);
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
        public async Task<ActionResult> PostPayrollPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPoliciesRepository.PostPayrollPoliciesAsync(common);
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
        public async Task<ActionResult> DelPayrollPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPoliciesRepository.DelPayrollPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPayrollPolicies(BeanzCommonDTO lookup)
        {
            var data = await _payrollPoliciesRepository.LookUpPayrollPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PayrollPolicieViewModel> GetInfoPayrollPolicies(BeanzCommonDTO common)
        {
            var data = await _payrollPoliciesRepository.GetInfoPayrollPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PayrollPolicieViewModel> PrintPayrollPolicies(BeanzCommonDTO common)
        {
            var data = await _payrollPoliciesRepository.PrintPayrollPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePayrollPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPoliciesRepository.ApprovePayrollPoliciesAsync(common);
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
