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
    public class EmployeeContractOfficialInformationsController : ControllerBase
    {
        private readonly IEmployeeContractOfficialInformationRepository _employeeContractOfficialInformationsRepository;

        public EmployeeContractOfficialInformationsController(IEmployeeContractOfficialInformationRepository employeeContractOfficialInformationsRepository)
        {
            _employeeContractOfficialInformationsRepository = employeeContractOfficialInformationsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeContractOfficialInformationDTO>> GetEmployeeContractOfficialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeContractOfficialInformationsRepository.GetEmployeeContractOfficialInformationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeContractOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractOfficialInformationsRepository.SetEmployeeContractOfficialInformationsAsync(common);
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
        public async Task<ActionResult> PostEmployeeContractOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractOfficialInformationsRepository.PostEmployeeContractOfficialInformationsAsync(common);
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
        public async Task<ActionResult> DelEmployeeContractOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractOfficialInformationsRepository.DelEmployeeContractOfficialInformationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeContractOfficialInformations(BeanzCommonDTO lookup)
        {
            var data = await _employeeContractOfficialInformationsRepository.LookUpEmployeeContractOfficialInformationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeContractOfficialInformationViewModel> GetInfoEmployeeContractOfficialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeContractOfficialInformationsRepository.GetInfoEmployeeContractOfficialInformationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeContractOfficialInformationViewModel> PrintEmployeeContractOfficialInformations(BeanzCommonDTO common)
        {
            var data = await _employeeContractOfficialInformationsRepository.PrintEmployeeContractOfficialInformationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeContractOfficialInformations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractOfficialInformationsRepository.ApproveEmployeeContractOfficialInformationsAsync(common);
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
