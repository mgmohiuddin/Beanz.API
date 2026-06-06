using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Employees
{
    [Route("api/[area]/Employees/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class EmployeeAllowancesController : ControllerBase
    {
        private readonly IEmployeeAllowanceRepository _employeeAllowancesRepository;

        public EmployeeAllowancesController(IEmployeeAllowanceRepository employeeAllowancesRepository)
        {
            _employeeAllowancesRepository = employeeAllowancesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeAllowanceDTO>> GetEmployeeAllowances(BeanzCommonDTO common)
        {
            var data = await _employeeAllowancesRepository.GetEmployeeAllowancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAllowancesRepository.SetEmployeeAllowancesAsync(common);
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
        public async Task<ActionResult> PostEmployeeAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAllowancesRepository.PostEmployeeAllowancesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Del")]
        public async Task<ActionResult> DelEmployeeAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAllowancesRepository.DelEmployeeAllowancesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeAllowances(BeanzCommonDTO lookup)
        {
            var data = await _employeeAllowancesRepository.LookUpEmployeeAllowancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeAllowanceViewModel> GetInfoEmployeeAllowances(BeanzCommonDTO common)
        {
            var data = await _employeeAllowancesRepository.GetInfoEmployeeAllowancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeAllowanceViewModel> PrintEmployeeAllowances(BeanzCommonDTO common)
        {
            var data = await _employeeAllowancesRepository.PrintEmployeeAllowancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAllowancesRepository.ApproveEmployeeAllowancesAsync(common);
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
