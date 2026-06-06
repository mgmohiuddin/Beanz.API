using Beanz.Core.Areas.HummanResourceManagement.Statuses;
using Beanz.DTOs.Areas.HummanResourceManagement.Statuses;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Statuses
{
    [Route("api/[area]/Statuses/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class EmployeeContractStatusesController : ControllerBase
    {
        private readonly IEmployeeContractStatuseRepository _employeeContractStatusesRepository;

        public EmployeeContractStatusesController(IEmployeeContractStatuseRepository employeeContractStatusesRepository)
        {
            _employeeContractStatusesRepository = employeeContractStatusesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeContractStatuseDTO>> GetEmployeeContractStatuses(BeanzCommonDTO common)
        {
            var data = await _employeeContractStatusesRepository.GetEmployeeContractStatusesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeContractStatuses(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractStatusesRepository.SetEmployeeContractStatusesAsync(common);
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
        public async Task<ActionResult> PostEmployeeContractStatuses(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractStatusesRepository.PostEmployeeContractStatusesAsync(common);
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
        public async Task<ActionResult> DelEmployeeContractStatuses(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractStatusesRepository.DelEmployeeContractStatusesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeContractStatuses(BeanzCommonDTO lookup)
        {
            var data = await _employeeContractStatusesRepository.LookUpEmployeeContractStatusesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeContractStatuseViewModel> GetInfoEmployeeContractStatuses(BeanzCommonDTO common)
        {
            var data = await _employeeContractStatusesRepository.GetInfoEmployeeContractStatusesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeContractStatuseViewModel> PrintEmployeeContractStatuses(BeanzCommonDTO common)
        {
            var data = await _employeeContractStatusesRepository.PrintEmployeeContractStatusesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeContractStatuses(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeContractStatusesRepository.ApproveEmployeeContractStatusesAsync(common);
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
