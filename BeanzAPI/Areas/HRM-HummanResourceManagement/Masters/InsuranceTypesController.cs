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
    public class InsuranceTypesController : ControllerBase
    {
        private readonly IInsuranceTypeRepository _insuranceTypesRepository;

        public InsuranceTypesController(IInsuranceTypeRepository insuranceTypesRepository)
        {
            _insuranceTypesRepository = insuranceTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<InsuranceTypeDTO>> GetInsuranceTypes(BeanzCommonDTO common)
        {
            var data = await _insuranceTypesRepository.GetInsuranceTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetInsuranceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesRepository.SetInsuranceTypesAsync(common);
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
        public async Task<ActionResult> PostInsuranceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesRepository.PostInsuranceTypesAsync(common);
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
        public async Task<ActionResult> DelInsuranceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesRepository.DelInsuranceTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpInsuranceTypes(BeanzCommonDTO lookup)
        {
            var data = await _insuranceTypesRepository.LookUpInsuranceTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<InsuranceTypeViewModel> GetInfoInsuranceTypes(BeanzCommonDTO common)
        {
            var data = await _insuranceTypesRepository.GetInfoInsuranceTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<InsuranceTypeViewModel> PrintInsuranceTypes(BeanzCommonDTO common)
        {
            var data = await _insuranceTypesRepository.PrintInsuranceTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveInsuranceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesRepository.ApproveInsuranceTypesAsync(common);
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
