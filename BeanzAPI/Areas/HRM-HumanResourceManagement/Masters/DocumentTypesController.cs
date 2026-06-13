using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IDocumentTypeBusiness _documentTypesBusiness;

        public DocumentTypesController(IDocumentTypeBusiness documentTypesBusiness)
        {
            _documentTypesBusiness = documentTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<DocumentTypeDTO>> GetDocumentTypes(BeanzCommonDTO common)
        {
            var data = await _documentTypesBusiness.GetDocumentTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetDocumentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentTypesBusiness.SetDocumentTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _documentTypesBusiness.PostDocumentTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _documentTypesBusiness.DelDocumentTypesAsync(common);
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
            var data = await _documentTypesBusiness.LookUpDocumentTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<DocumentTypeViewModel> GetInfoDocumentTypes(BeanzCommonDTO common)
        {
            var data = await _documentTypesBusiness.GetInfoDocumentTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<DocumentTypeViewModel> PrintDocumentTypes(BeanzCommonDTO common)
        {
            var data = await _documentTypesBusiness.PrintDocumentTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveDocumentTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _documentTypesBusiness.ApproveDocumentTypesAsync(common);
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
