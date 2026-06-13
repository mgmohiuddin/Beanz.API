using Beanz.Core.Areas.HumanResourceManagement.Employees;
using Beanz.DTOs.Areas.HumanResourceManagement.Employees;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Employees
{
    [Route("api/[area]/Employees/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class EmployeeDependentDocumentsController : ControllerBase
    {
        private readonly IEmployeeDependentDocumentRepository _employeeDependentDocumentsRepository;

        public EmployeeDependentDocumentsController(IEmployeeDependentDocumentRepository employeeDependentDocumentsRepository)
        {
            _employeeDependentDocumentsRepository = employeeDependentDocumentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<EmployeeDependentDocumentDTO>> GetEmployeeDependentDocuments(BeanzCommonDTO common)
        {
            var data = await _employeeDependentDocumentsRepository.GetEmployeeDependentDocumentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetEmployeeDependentDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentDocumentsRepository.SetEmployeeDependentDocumentsAsync(common);
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
        public async Task<ActionResult> PostEmployeeDependentDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentDocumentsRepository.PostEmployeeDependentDocumentsAsync(common);
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
        public async Task<ActionResult> DelEmployeeDependentDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentDocumentsRepository.DelEmployeeDependentDocumentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpEmployeeDependentDocuments(BeanzCommonDTO lookup)
        {
            var data = await _employeeDependentDocumentsRepository.LookUpEmployeeDependentDocumentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<EmployeeDependentDocumentViewModel> GetInfoEmployeeDependentDocuments(BeanzCommonDTO common)
        {
            var data = await _employeeDependentDocumentsRepository.GetInfoEmployeeDependentDocumentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<EmployeeDependentDocumentViewModel> PrintEmployeeDependentDocuments(BeanzCommonDTO common)
        {
            var data = await _employeeDependentDocumentsRepository.PrintEmployeeDependentDocumentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveEmployeeDependentDocuments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _employeeDependentDocumentsRepository.ApproveEmployeeDependentDocumentsAsync(common);
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
