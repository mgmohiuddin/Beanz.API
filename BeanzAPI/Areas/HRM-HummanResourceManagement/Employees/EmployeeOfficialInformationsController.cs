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
    public class EmployeeOfficialInformationsController : ControllerBase
    {
        private readonly IEmployeeOfficialInformationRepository _employeeOfficialInformationsRepository;

        public EmployeeOfficialInformationsController(IEmployeeOfficialInformationRepository employeeOfficialInformationsRepository)
        {
            _employeeOfficialInformationsRepository = employeeOfficialInformationsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeOfficialInformationDTO>> GetEmployeeOfficialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeOfficialInformationsRepository.GetEmployeeOfficialInformationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeOfficialInformationsRepository.SetEmployeeOfficialInformationsAsync(common);
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
        public async Task<ActionResult> PostEmployeeOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeOfficialInformationsRepository.PostEmployeeOfficialInformationsAsync(common);
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
        public async Task<ActionResult> DelEmployeeOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeOfficialInformationsRepository.DelEmployeeOfficialInformationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeOfficialInformations(BeanzCommonDTO lookup)
        {
            var data = await _employeeOfficialInformationsRepository.LookUpEmployeeOfficialInformationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeOfficialInformationViewModel> GetInfoEmployeeOfficialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeOfficialInformationsRepository.GetInfoEmployeeOfficialInformationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeOfficialInformationViewModel> PrintEmployeeOfficialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeOfficialInformationsRepository.PrintEmployeeOfficialInformationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeOfficialInformationsRepository.ApproveEmployeeOfficialInformationsAsync(common);
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
