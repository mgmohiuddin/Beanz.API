using Beanz.Core.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.FinancialAccountingSystem.Accounts
{
    [Route("api/[area]/Accounts/[controller]")]
    [ApiController]
    [Area("FinancialAccountingSystem")]
    public class AccountTypesController : ControllerBase
    {
        private readonly IAccountTypeBusiness _accountTypesBusiness;

        public AccountTypesController(IAccountTypeBusiness accountTypesBusiness)
        {
            _accountTypesBusiness = accountTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AccountTypeDTO>> GetAccountTypes(BeanzCommonDTO common)
        {
            var data = await _accountTypesBusiness.GetAccountTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAccountTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountTypesBusiness.SetAccountTypesAsync(common);
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
        public async Task<ActionResult> PostAccountTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountTypesBusiness.PostAccountTypesAsync(common);
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
        public async Task<ActionResult> DelAccountTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountTypesBusiness.DelAccountTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAccountTypes(BeanzCommonDTO lookup)
        {
            var data = await _accountTypesBusiness.LookUpAccountTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AccountTypeViewModel> GetInfoAccountTypes(BeanzCommonDTO common)
        {
            var data = await _accountTypesBusiness.GetInfoAccountTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AccountTypeViewModel> PrintAccountTypes(BeanzCommonDTO common)
        {
            var data = await _accountTypesBusiness.PrintAccountTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAccountTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountTypesBusiness.ApproveAccountTypesAsync(common);
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
