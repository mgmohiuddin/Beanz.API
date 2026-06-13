using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
 
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Employees
{
    [Route("api/[area]/Employees/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class EmployeeDependentsController : ControllerBase
    {
        private readonly IEmployeeDependentRepository _employeeDependentsRepository;

        public EmployeeDependentsController(IEmployeeDependentRepository employeeDependentsRepository)
        {
            _employeeDependentsRepository = employeeDependentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeDependentDTO>> GetEmployeeDependents(BeanzCommonDTO common)
        {
            var data = await _employeeDependentsRepository.GetEmployeeDependentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeDependents(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentsRepository.SetEmployeeDependentsAsync(common);
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
        public async Task<ActionResult> PostEmployeeDependents(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentsRepository.PostEmployeeDependentsAsync(common);
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
        public async Task<ActionResult> DelEmployeeDependents(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentsRepository.DelEmployeeDependentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeDependents(BeanzCommonDTO lookup)
        {
            var data = await _employeeDependentsRepository.LookUpEmployeeDependentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeDependentViewModel> GetInfoEmployeeDependents(BeanzCommonDTO common)
        {
            var data = await _employeeDependentsRepository.GetInfoEmployeeDependentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeDependentViewModel> PrintEmployeeDependents(BeanzCommonDTO common)
        {
            var data = await _employeeDependentsRepository.PrintEmployeeDependentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeDependents(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentsRepository.ApproveEmployeeDependentsAsync(common);
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
