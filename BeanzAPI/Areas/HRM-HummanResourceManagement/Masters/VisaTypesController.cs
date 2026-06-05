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
    public class VisaTypesController : ControllerBase
    {
        private readonly IVisaTypeRepository _visaTypesRepository;

        public VisaTypesController(IVisaTypeRepository visaTypesRepository)
        {
            _visaTypesRepository = visaTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<VisaTypeDTO>> GetVisaTypes(BeanzCommonDTO common)
        {
            var data = await _visaTypesRepository.GetVisaTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesRepository.SetVisaTypesAsync(common);
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
        public async Task<ActionResult> PostVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesRepository.PostVisaTypesAsync(common);
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
        public async Task<ActionResult> DelVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesRepository.DelVisaTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpVisaTypes(BeanzCommonDTO lookup)
        {
            var data = await _visaTypesRepository.LookUpVisaTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VisaTypeViewModel> GetInfoVisaTypes(BeanzCommonDTO common)
        {
            var data = await _visaTypesRepository.GetInfoVisaTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VisaTypeViewModel> PrintVisaTypes(BeanzCommonDTO common)
        {
            var data = await _visaTypesRepository.PrintVisaTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVisaTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _visaTypesRepository.ApproveVisaTypesAsync(common);
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
