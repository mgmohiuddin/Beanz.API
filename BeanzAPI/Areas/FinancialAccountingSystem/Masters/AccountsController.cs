using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountBusiness _accountsBusiness;

        public AccountsController(IAccountBusiness accountsBusiness)
        {
            _accountsBusiness = accountsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AccountDTO>> GetAccounts(BeanzCommonDTO common)
        {
            var data = await _accountsBusiness.GetAccountsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountsBusiness.SetAccountsAsync(common);
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
        public async Task<ActionResult> PostAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountsBusiness.PostAccountsAsync(common);
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
        public async Task<ActionResult> DelAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountsBusiness.DelAccountsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAccounts(BeanzCommonDTO lookup)
        {
            var data = await _accountsBusiness.LookUpAccountsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AccountViewModel> GetInfoAccounts(BeanzCommonDTO common)
        {
            var data = await _accountsBusiness.GetInfoAccountsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AccountViewModel> PrintAccounts(BeanzCommonDTO common)
        {
            var data = await _accountsBusiness.PrintAccountsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAccounts(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountsBusiness.ApproveAccountsAsync(common);
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
