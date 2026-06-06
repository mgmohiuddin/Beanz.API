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
    public class EmployeeContractAllowancesController : ControllerBase
    {
        private readonly IEmployeeContractAllowanceRepository _employeeContractAllowancesRepository;

        public EmployeeContractAllowancesController(IEmployeeContractAllowanceRepository employeeContractAllowancesRepository)
        {
            _employeeContractAllowancesRepository = employeeContractAllowancesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeContractAllowanceDTO>> GetEmployeeContractAllowances(BeanzCommonDTO common)
        {
            var data = await _employeeContractAllowancesRepository.GetEmployeeContractAllowancesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeContractAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractAllowancesRepository.SetEmployeeContractAllowancesAsync(common);
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
        public async Task<ActionResult> PostEmployeeContractAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractAllowancesRepository.PostEmployeeContractAllowancesAsync(common);
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
        public async Task<ActionResult> DelEmployeeContractAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractAllowancesRepository.DelEmployeeContractAllowancesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeContractAllowances(BeanzCommonDTO lookup)
        {
            var data = await _employeeContractAllowancesRepository.LookUpEmployeeContractAllowancesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeContractAllowanceViewModel> GetInfoEmployeeContractAllowances(BeanzCommonDTO common)
        {
            var data = await _employeeContractAllowancesRepository.GetInfoEmployeeContractAllowancesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeContractAllowanceViewModel> PrintEmployeeContractAllowances(BeanzCommonDTO common)
        {
            var data = await _employeeContractAllowancesRepository.PrintEmployeeContractAllowancesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeContractAllowances(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractAllowancesRepository.ApproveEmployeeContractAllowancesAsync(common);
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
