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
    public class EmployeeLanguagesController : ControllerBase
    {
        private readonly IEmployeeLanguageRepository _employeeLanguagesRepository;

        public EmployeeLanguagesController(IEmployeeLanguageRepository employeeLanguagesRepository)
        {
            _employeeLanguagesRepository = employeeLanguagesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeLanguageDTO>> GetEmployeeLanguages(BeanzCommonDTO common)
        {
            var data = await _employeeLanguagesRepository.GetEmployeeLanguagesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeLanguages(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeLanguagesRepository.SetEmployeeLanguagesAsync(common);
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
        public async Task<ActionResult> PostEmployeeLanguages(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeLanguagesRepository.PostEmployeeLanguagesAsync(common);
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
        public async Task<ActionResult> DelEmployeeLanguages(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeLanguagesRepository.DelEmployeeLanguagesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeLanguages(BeanzCommonDTO lookup)
        {
            var data = await _employeeLanguagesRepository.LookUpEmployeeLanguagesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeLanguageViewModel> GetInfoEmployeeLanguages(BeanzCommonDTO common)
        {
            var data = await _employeeLanguagesRepository.GetInfoEmployeeLanguagesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeLanguageViewModel> PrintEmployeeLanguages(BeanzCommonDTO common)
        {
            var data = await _employeeLanguagesRepository.PrintEmployeeLanguagesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeLanguages(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeLanguagesRepository.ApproveEmployeeLanguagesAsync(common);
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
