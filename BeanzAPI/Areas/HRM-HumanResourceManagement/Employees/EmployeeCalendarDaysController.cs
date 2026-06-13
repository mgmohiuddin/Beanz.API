using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Employees
{
    [Route("api/[area]/Employees/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class EmployeeCalendarDaysController : ControllerBase
    {
        private readonly IEmployeeCalendarDayRepository _employeeCalendarDaysRepository;

        public EmployeeCalendarDaysController(IEmployeeCalendarDayRepository employeeCalendarDaysRepository)
        {
            _employeeCalendarDaysRepository = employeeCalendarDaysRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeCalendarDayDTO>> GetEmployeeCalendarDays(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarDaysRepository.GetEmployeeCalendarDaysAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeCalendarDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDaysRepository.SetEmployeeCalendarDaysAsync(common);
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
        public async Task<ActionResult> PostEmployeeCalendarDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDaysRepository.PostEmployeeCalendarDaysAsync(common);
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
        public async Task<ActionResult> DelEmployeeCalendarDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDaysRepository.DelEmployeeCalendarDaysAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeCalendarDays(BeanzCommonDTO lookup)
        {
            var data = await _employeeCalendarDaysRepository.LookUpEmployeeCalendarDaysAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeCalendarDayViewModel> GetInfoEmployeeCalendarDays(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarDaysRepository.GetInfoEmployeeCalendarDaysAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeCalendarDayViewModel> PrintEmployeeCalendarDays(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarDaysRepository.PrintEmployeeCalendarDaysAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeCalendarDays(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDaysRepository.ApproveEmployeeCalendarDaysAsync(common);
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
