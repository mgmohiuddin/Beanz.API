using Beanz.Core.Areas.HummanResourceManagement.Transactions;
using Beanz.DTOs.Areas.HummanResourceManagement.Transactions;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Transactions
{
    [Route("api/[area]/Transactions/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class PayrollPeriodsController : ControllerBase
    {
        private readonly IPayrollPeriodRepository _payrollPeriodsRepository;

        public PayrollPeriodsController(IPayrollPeriodRepository payrollPeriodsRepository)
        {
            _payrollPeriodsRepository = payrollPeriodsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<PayrollPeriodDTO>> GetPayrollPeriods(BeanzCommonDTO common)
        {
            var data = await _payrollPeriodsRepository.GetPayrollPeriodsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPayrollPeriods(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPeriodsRepository.SetPayrollPeriodsAsync(common);
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
        public async Task<ActionResult> PostPayrollPeriods(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPeriodsRepository.PostPayrollPeriodsAsync(common);
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
        public async Task<ActionResult> DelPayrollPeriods(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPeriodsRepository.DelPayrollPeriodsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPayrollPeriods(BeanzCommonDTO lookup)
        {
            var data = await _payrollPeriodsRepository.LookUpPayrollPeriodsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PayrollPeriodViewModel> GetInfoPayrollPeriods(BeanzCommonDTO common)
        {
            var data = await _payrollPeriodsRepository.GetInfoPayrollPeriodsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PayrollPeriodViewModel> PrintPayrollPeriods(BeanzCommonDTO common)
        {
            var data = await _payrollPeriodsRepository.PrintPayrollPeriodsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePayrollPeriods(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollPeriodsRepository.ApprovePayrollPeriodsAsync(common);
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
