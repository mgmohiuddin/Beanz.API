using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class DocumentSubmissionTypesController : ControllerBase
    {
        private readonly IDocumentSubmissionTypeRepository _documentSubmissionTypesRepository;

        public DocumentSubmissionTypesController(IDocumentSubmissionTypeRepository documentSubmissionTypesRepository)
        {
            _documentSubmissionTypesRepository = documentSubmissionTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<DocumentSubmissionTypeDTO>> GetDocumentSubmissionTypes(BeanzCommonDTO common)
        {
            var data = await _documentSubmissionTypesRepository.GetDocumentSubmissionTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetDocumentSubmissionTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentSubmissionTypesRepository.SetDocumentSubmissionTypesAsync(common);
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
        public async Task<ActionResult> PostDocumentSubmissionTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentSubmissionTypesRepository.PostDocumentSubmissionTypesAsync(common);
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
        public async Task<ActionResult> DelDocumentSubmissionTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentSubmissionTypesRepository.DelDocumentSubmissionTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpDocumentSubmissionTypes(BeanzCommonDTO lookup)
        {
            var data = await _documentSubmissionTypesRepository.LookUpDocumentSubmissionTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<DocumentSubmissionTypeViewModel> GetInfoDocumentSubmissionTypes(BeanzCommonDTO common)
        {
            var data = await _documentSubmissionTypesRepository.GetInfoDocumentSubmissionTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<DocumentSubmissionTypeViewModel> PrintDocumentSubmissionTypes(BeanzCommonDTO common)
        {
            var data = await _documentSubmissionTypesRepository.PrintDocumentSubmissionTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveDocumentSubmissionTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentSubmissionTypesRepository.ApproveDocumentSubmissionTypesAsync(common);
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
