using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class InsuranceTypesController : ControllerBase
    {
        private readonly IInsuranceTypeBusiness _insuranceTypesBusiness;

        public InsuranceTypesController(IInsuranceTypeBusiness insuranceTypesBusiness)
        {
            _insuranceTypesBusiness = insuranceTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<InsuranceTypeDTO>> GetInsuranceTypes(BeanzCommonDTO common)
        {
            var data = await _insuranceTypesBusiness.GetInsuranceTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetInsuranceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesBusiness.SetInsuranceTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesBusiness.PostInsuranceTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesBusiness.DelInsuranceTypesAsync(common);
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
            var data = await _insuranceTypesBusiness.LookUpInsuranceTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<InsuranceTypeViewModel> GetInfoInsuranceTypes(BeanzCommonDTO common)
        {
            var data = await _insuranceTypesBusiness.GetInfoInsuranceTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<InsuranceTypeViewModel> PrintInsuranceTypes(BeanzCommonDTO common)
        {
            var data = await _insuranceTypesBusiness.PrintInsuranceTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveInsuranceTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _insuranceTypesBusiness.ApproveInsuranceTypesAsync(common);
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
