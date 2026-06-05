using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IDocumentTypeRepository _documentTypesRepository;

        public DocumentTypesController(IDocumentTypeRepository documentTypesRepository)
        {
            _documentTypesRepository = documentTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<DocumentTypeDTO>> GetDocumentTypes(BeanzCommonDTO common)
        {
            var data = await _documentTypesRepository.GetDocumentTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetDocumentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentTypesRepository.SetDocumentTypesAsync(common);
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
        public async Task<ActionResult> PostDocumentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentTypesRepository.PostDocumentTypesAsync(common);
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
        public async Task<ActionResult> DelDocumentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentTypesRepository.DelDocumentTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpDocumentTypes(BeanzCommonDTO lookup)
        {
            var data = await _documentTypesRepository.LookUpDocumentTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<DocumentTypeViewModel> GetInfoDocumentTypes(BeanzCommonDTO common)
        {
            var data = await _documentTypesRepository.GetInfoDocumentTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<DocumentTypeViewModel> PrintDocumentTypes(BeanzCommonDTO common)
        {
            var data = await _documentTypesRepository.PrintDocumentTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveDocumentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentTypesRepository.ApproveDocumentTypesAsync(common);
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
