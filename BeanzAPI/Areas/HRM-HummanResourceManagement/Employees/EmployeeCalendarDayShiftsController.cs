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
    public class EmployeeCalendarDayShiftsController : ControllerBase
    {
        private readonly IEmployeeCalendarDayShiftRepository _employeeCalendarDayShiftsRepository;

        public EmployeeCalendarDayShiftsController(IEmployeeCalendarDayShiftRepository employeeCalendarDayShiftsRepository)
        {
            _employeeCalendarDayShiftsRepository = employeeCalendarDayShiftsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeCalendarDayShiftDTO>> GetEmployeeCalendarDayShifts(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarDayShiftsRepository.GetEmployeeCalendarDayShiftsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeCalendarDayShifts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDayShiftsRepository.SetEmployeeCalendarDayShiftsAsync(common);
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
        public async Task<ActionResult> PostEmployeeCalendarDayShifts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDayShiftsRepository.PostEmployeeCalendarDayShiftsAsync(common);
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
        public async Task<ActionResult> DelEmployeeCalendarDayShifts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDayShiftsRepository.DelEmployeeCalendarDayShiftsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeCalendarDayShifts(BeanzCommonDTO lookup)
        {
            var data = await _employeeCalendarDayShiftsRepository.LookUpEmployeeCalendarDayShiftsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeCalendarDayShiftViewModel> GetInfoEmployeeCalendarDayShifts(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarDayShiftsRepository.GetInfoEmployeeCalendarDayShiftsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeCalendarDayShiftViewModel> PrintEmployeeCalendarDayShifts(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarDayShiftsRepository.PrintEmployeeCalendarDayShiftsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeCalendarDayShifts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarDayShiftsRepository.ApproveEmployeeCalendarDayShiftsAsync(common);
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
