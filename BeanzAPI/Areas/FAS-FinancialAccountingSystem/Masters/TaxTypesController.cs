using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class TaxTypesController : ControllerBase
    {
        private readonly ITaxTypeBusiness _taxTypesBusiness;

        public TaxTypesController(ITaxTypeBusiness taxTypesBusiness)
        {
            _taxTypesBusiness = taxTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<TaxTypeDTO>> GetTaxTypes(BeanzCommonDTO common)
        {
            var data = await _taxTypesBusiness.GetTaxTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesBusiness.SetTaxTypesAsync(common);
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
        public async Task<ActionResult> PostTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesBusiness.PostTaxTypesAsync(common);
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
        public async Task<ActionResult> DelTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesBusiness.DelTaxTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTaxTypes(BeanzCommonDTO lookup)
        {
            var data = await _taxTypesBusiness.LookUpTaxTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TaxTypeViewModel> GetInfoTaxTypes(BeanzCommonDTO common)
        {
            var data = await _taxTypesBusiness.GetInfoTaxTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TaxTypeViewModel> PrintTaxTypes(BeanzCommonDTO common)
        {
            var data = await _taxTypesBusiness.PrintTaxTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesBusiness.ApproveTaxTypesAsync(common);
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
