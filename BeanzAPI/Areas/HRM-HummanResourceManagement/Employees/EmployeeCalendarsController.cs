using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
 using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Employees
{
    [Route("api/[area]/Employees/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class EmployeeCalendarsController : ControllerBase
    {
        private readonly IEmployeeCalendarRepository _employeeCalendarsRepository;

        public EmployeeCalendarsController(IEmployeeCalendarRepository employeeCalendarsRepository)
        {
            _employeeCalendarsRepository = employeeCalendarsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeCalendarDTO>> GetEmployeeCalendars(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarsRepository.GetEmployeeCalendarsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeCalendars(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarsRepository.SetEmployeeCalendarsAsync(common);
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
        public async Task<ActionResult> PostEmployeeCalendars(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarsRepository.PostEmployeeCalendarsAsync(common);
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
        public async Task<ActionResult> DelEmployeeCalendars(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarsRepository.DelEmployeeCalendarsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeCalendars(BeanzCommonDTO lookup)
        {
            var data = await _employeeCalendarsRepository.LookUpEmployeeCalendarsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeCalendarViewModel> GetInfoEmployeeCalendars(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarsRepository.GetInfoEmployeeCalendarsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeCalendarViewModel> PrintEmployeeCalendars(BeanzCommonDTO common)
        {
            var data = await _employeeCalendarsRepository.PrintEmployeeCalendarsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeCalendars(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeCalendarsRepository.ApproveEmployeeCalendarsAsync(common);
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
