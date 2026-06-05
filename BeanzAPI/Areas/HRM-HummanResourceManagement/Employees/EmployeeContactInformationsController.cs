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
    public class EmployeeContactInformationsController : ControllerBase
    {
        private readonly IEmployeeContactInformationRepository _employeeContactInformationsRepository;

        public EmployeeContactInformationsController(IEmployeeContactInformationRepository employeeContactInformationsRepository)
        {
            _employeeContactInformationsRepository = employeeContactInformationsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeContactInformationDTO>> GetEmployeeContactInformations(BeanzCommonDTO common)
        {
            var data = await _employeeContactInformationsRepository.GetEmployeeContactInformationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeContactInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContactInformationsRepository.SetEmployeeContactInformationsAsync(common);
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
        public async Task<ActionResult> PostEmployeeContactInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContactInformationsRepository.PostEmployeeContactInformationsAsync(common);
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
        public async Task<ActionResult> DelEmployeeContactInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContactInformationsRepository.DelEmployeeContactInformationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeContactInformations(BeanzCommonDTO lookup)
        {
            var data = await _employeeContactInformationsRepository.LookUpEmployeeContactInformationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeContactInformationViewModel> GetInfoEmployeeContactInformations(BeanzCommonDTO common)
        {
            var data = await _employeeContactInformationsRepository.GetInfoEmployeeContactInformationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeContactInformationViewModel> PrintEmployeeContactInformations(BeanzCommonDTO common)
        {
            var data = await _employeeContactInformationsRepository.PrintEmployeeContactInformationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeContactInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContactInformationsRepository.ApproveEmployeeContactInformationsAsync(common);
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
