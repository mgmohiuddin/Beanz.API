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
    public class AccountOpeningDetailsController : ControllerBase
    {
        private readonly IAccountOpeningDetailBusiness _accountOpeningDetailsBusiness;

        public AccountOpeningDetailsController(IAccountOpeningDetailBusiness accountOpeningDetailsBusiness)
        {
            _accountOpeningDetailsBusiness = accountOpeningDetailsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AccountOpeningDetailDTO>> GetAccountOpeningDetails(BeanzCommonDTO common)
        {
            var data = await _accountOpeningDetailsBusiness.GetAccountOpeningDetailsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAccountOpeningDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningDetailsBusiness.SetAccountOpeningDetailsAsync(common);
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
        public async Task<ActionResult> PostAccountOpeningDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningDetailsBusiness.PostAccountOpeningDetailsAsync(common);
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
        public async Task<ActionResult> DelAccountOpeningDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningDetailsBusiness.DelAccountOpeningDetailsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAccountOpeningDetails(BeanzCommonDTO lookup)
        {
            var data = await _accountOpeningDetailsBusiness.LookUpAccountOpeningDetailsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AccountOpeningDetailViewModel> GetInfoAccountOpeningDetails(BeanzCommonDTO common)
        {
            var data = await _accountOpeningDetailsBusiness.GetInfoAccountOpeningDetailsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AccountOpeningDetailViewModel> PrintAccountOpeningDetails(BeanzCommonDTO common)
        {
            var data = await _accountOpeningDetailsBusiness.PrintAccountOpeningDetailsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAccountOpeningDetails(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _accountOpeningDetailsBusiness.ApproveAccountOpeningDetailsAsync(common);
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
