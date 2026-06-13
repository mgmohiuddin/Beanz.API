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
    public class EmployeeQualificationsController : ControllerBase
    {
        private readonly IEmployeeQualificationRepository _employeeQualificationsRepository;

        public EmployeeQualificationsController(IEmployeeQualificationRepository employeeQualificationsRepository)
        {
            _employeeQualificationsRepository = employeeQualificationsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeQualificationDTO>> GetEmployeeQualifications(BeanzCommonDTO common)
        {
            var data = await _employeeQualificationsRepository.GetEmployeeQualificationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeQualifications(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeQualificationsRepository.SetEmployeeQualificationsAsync(common);
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
        public async Task<ActionResult> PostEmployeeQualifications(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeQualificationsRepository.PostEmployeeQualificationsAsync(common);
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
        public async Task<ActionResult> DelEmployeeQualifications(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeQualificationsRepository.DelEmployeeQualificationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeQualifications(BeanzCommonDTO lookup)
        {
            var data = await _employeeQualificationsRepository.LookUpEmployeeQualificationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeQualificationViewModel> GetInfoEmployeeQualifications(BeanzCommonDTO common)
        {
            var data = await _employeeQualificationsRepository.GetInfoEmployeeQualificationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeQualificationViewModel> PrintEmployeeQualifications(BeanzCommonDTO common)
        {
            var data = await _employeeQualificationsRepository.PrintEmployeeQualificationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeQualifications(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeQualificationsRepository.ApproveEmployeeQualificationsAsync(common);
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
