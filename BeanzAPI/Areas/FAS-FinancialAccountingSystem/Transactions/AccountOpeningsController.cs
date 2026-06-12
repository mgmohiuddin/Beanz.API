using Beanz.Core.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Transactions
{
    [Route("api/[area]/Transactions/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class AccountOpeningsController : ControllerBase
    {
        private readonly IAccountOpeningBusiness _accountOpeningsBusiness;

        public AccountOpeningsController(IAccountOpeningBusiness accountOpeningsBusiness)
        {
            _accountOpeningsBusiness = accountOpeningsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AccountOpeningDTO>> GetAccountOpenings(BeanzCommonDTO common)
        {
            var data = await _accountOpeningsBusiness.GetAccountOpeningsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAccountOpenings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningsBusiness.SetAccountOpeningsAsync(common);
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
        public async Task<ActionResult> PostAccountOpenings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningsBusiness.PostAccountOpeningsAsync(common);
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
        public async Task<ActionResult> DelAccountOpenings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningsBusiness.DelAccountOpeningsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAccountOpenings(BeanzCommonDTO lookup)
        {
            var data = await _accountOpeningsBusiness.LookUpAccountOpeningsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AccountOpeningViewModel> GetInfoAccountOpenings(BeanzCommonDTO common)
        {
            var data = await _accountOpeningsBusiness.GetInfoAccountOpeningsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AccountOpeningViewModel> PrintAccountOpenings(BeanzCommonDTO common)
        {
            var data = await _accountOpeningsBusiness.PrintAccountOpeningsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAccountOpenings(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningsBusiness.ApproveAccountOpeningsAsync(common);
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
