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
    public class FiscalYearsController : ControllerBase
    {
        private readonly IFiscalYearBusiness _fiscalYearsBusiness;

        public FiscalYearsController(IFiscalYearBusiness fiscalYearsBusiness)
        {
            _fiscalYearsBusiness = fiscalYearsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<FiscalYearDTO>> GetFiscalYears(BeanzCommonDTO common)
        {
            var data = await _fiscalYearsBusiness.GetFiscalYearsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetFiscalYears(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _fiscalYearsBusiness.SetFiscalYearsAsync(common);
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
        public async Task<ActionResult> PostFiscalYears(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _fiscalYearsBusiness.PostFiscalYearsAsync(common);
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
        public async Task<ActionResult> DelFiscalYears(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _fiscalYearsBusiness.DelFiscalYearsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpFiscalYears(BeanzCommonDTO lookup)
        {
            var data = await _fiscalYearsBusiness.LookUpFiscalYearsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<FiscalYearViewModel> GetInfoFiscalYears(BeanzCommonDTO common)
        {
            var data = await _fiscalYearsBusiness.GetInfoFiscalYearsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<FiscalYearViewModel> PrintFiscalYears(BeanzCommonDTO common)
        {
            var data = await _fiscalYearsBusiness.PrintFiscalYearsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveFiscalYears(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _fiscalYearsBusiness.ApproveFiscalYearsAsync(common);
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
