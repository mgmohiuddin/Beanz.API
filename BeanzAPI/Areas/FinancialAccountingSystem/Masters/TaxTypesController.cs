using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Masters
{
    [Route("api/[area]/Masters/[controller]/[action]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class TaxTypesController : ControllerBase
    {
        private readonly ITaxTypeRepository _taxTypesRepository;

        public TaxTypesController(ITaxTypeRepository taxTypesRepository)
        {
            _taxTypesRepository = taxTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TaxTypeDTO>> GetTaxTypes(BeanzCommonDTO common)
        {
            var data = await _taxTypesRepository.GetTaxTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesRepository.SetTaxTypesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Post")]
        public async Task<ActionResult> PostTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesRepository.PostTaxTypesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("Del")]
        public async Task<ActionResult> DelTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesRepository.DelTaxTypesAsync(common);
                if (beanzResponseDTO.ErrorCode != "")
                    return BadRequest(beanzResponseDTO);
                else
                    return Ok(beanzResponseDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPost("LookUp")]
        public async Task<List<BeanzlookupDTO>> LookUpTaxTypes(BeanzCommonDTO lookup)
        {
            var data = await _taxTypesRepository.LookUpTaxTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TaxTypeViewModel> GetInfoTaxTypes(BeanzCommonDTO common)
        {
            var data = await _taxTypesRepository.GetInfoTaxTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TaxTypeViewModel> PrintTaxTypes(BeanzCommonDTO common)
        {
            var data = await _taxTypesRepository.PrintTaxTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTaxTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _taxTypesRepository.ApproveTaxTypesAsync(common);
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
