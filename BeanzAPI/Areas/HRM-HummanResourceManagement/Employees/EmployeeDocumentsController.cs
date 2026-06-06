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
    public class EmployeeDocumentsController : ControllerBase
    {
        private readonly IEmployeeDocumentRepository _employeeDocumentsRepository;

        public EmployeeDocumentsController(IEmployeeDocumentRepository employeeDocumentsRepository)
        {
            _employeeDocumentsRepository = employeeDocumentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeDocumentDTO>> GetEmployeeDocuments(BeanzCommonDTO common)
        {
            var data = await _employeeDocumentsRepository.GetEmployeeDocumentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDocumentsRepository.SetEmployeeDocumentsAsync(common);
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
        public async Task<ActionResult> PostEmployeeDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDocumentsRepository.PostEmployeeDocumentsAsync(common);
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
        public async Task<ActionResult> DelEmployeeDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDocumentsRepository.DelEmployeeDocumentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeDocuments(BeanzCommonDTO lookup)
        {
            var data = await _employeeDocumentsRepository.LookUpEmployeeDocumentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeDocumentViewModel> GetInfoEmployeeDocuments(BeanzCommonDTO common)
        {
            var data = await _employeeDocumentsRepository.GetInfoEmployeeDocumentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeDocumentViewModel> PrintEmployeeDocuments(BeanzCommonDTO common)
        {
            var data = await _employeeDocumentsRepository.PrintEmployeeDocumentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDocumentsRepository.ApproveEmployeeDocumentsAsync(common);
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
