using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Employees
{
    [Route("api/[area]/Employees/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class EmployeeAssignPoliciesController : ControllerBase
    {
        private readonly IEmployeeAssignPolicieRepository _employeeAssignPoliciesRepository;

        public EmployeeAssignPoliciesController(IEmployeeAssignPolicieRepository employeeAssignPoliciesRepository)
        {
            _employeeAssignPoliciesRepository = employeeAssignPoliciesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeAssignPolicieDTO>> GetEmployeeAssignPolicies(BeanzCommonDTO common)
        {
            var data = await _employeeAssignPoliciesRepository.GetEmployeeAssignPoliciesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeAssignPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAssignPoliciesRepository.SetEmployeeAssignPoliciesAsync(common);
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
        public async Task<ActionResult> PostEmployeeAssignPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAssignPoliciesRepository.PostEmployeeAssignPoliciesAsync(common);
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
        public async Task<ActionResult> DelEmployeeAssignPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAssignPoliciesRepository.DelEmployeeAssignPoliciesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeAssignPolicies(BeanzCommonDTO lookup)
        {
            var data = await _employeeAssignPoliciesRepository.LookUpEmployeeAssignPoliciesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeAssignPolicieViewModel> GetInfoEmployeeAssignPolicies(BeanzCommonDTO common)
        {
            var data = await _employeeAssignPoliciesRepository.GetInfoEmployeeAssignPoliciesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeAssignPolicieViewModel> PrintEmployeeAssignPolicies(BeanzCommonDTO common)
        {
            var data = await _employeeAssignPoliciesRepository.PrintEmployeeAssignPoliciesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeAssignPolicies(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeAssignPoliciesRepository.ApproveEmployeeAssignPoliciesAsync(common);
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
