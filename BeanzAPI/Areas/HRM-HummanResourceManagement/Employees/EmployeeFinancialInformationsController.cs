using Beanz.Core.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.Areas.HummanResourceManagement.Employees;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Employees
{
    [Route("api/[area]/Employees/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class EmployeeFinancialInformationsController : ControllerBase
    {
        private readonly IEmployeeFinancialInformationRepository _employeeFinancialInformationsRepository;

        public EmployeeFinancialInformationsController(IEmployeeFinancialInformationRepository employeeFinancialInformationsRepository)
        {
            _employeeFinancialInformationsRepository = employeeFinancialInformationsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeFinancialInformationDTO>> GetEmployeeFinancialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeFinancialInformationsRepository.GetEmployeeFinancialInformationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeFinancialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeFinancialInformationsRepository.SetEmployeeFinancialInformationsAsync(common);
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
        public async Task<ActionResult> PostEmployeeFinancialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeFinancialInformationsRepository.PostEmployeeFinancialInformationsAsync(common);
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
        public async Task<ActionResult> DelEmployeeFinancialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeFinancialInformationsRepository.DelEmployeeFinancialInformationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeFinancialInformations(BeanzCommonDTO lookup)
        {
            var data = await _employeeFinancialInformationsRepository.LookUpEmployeeFinancialInformationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeFinancialInformationViewModel> GetInfoEmployeeFinancialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeFinancialInformationsRepository.GetInfoEmployeeFinancialInformationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeFinancialInformationViewModel> PrintEmployeeFinancialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeFinancialInformationsRepository.PrintEmployeeFinancialInformationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeFinancialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeFinancialInformationsRepository.ApproveEmployeeFinancialInformationsAsync(common);
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
