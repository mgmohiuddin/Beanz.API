using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class LoanTypesController : ControllerBase
    {
        private readonly ILoanTypeBusiness _loanTypesBusiness;

        public LoanTypesController(ILoanTypeBusiness loanTypesBusiness)
        {
            _loanTypesBusiness = loanTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<LoanTypeDTO>> GetLoanTypes(BeanzCommonDTO common)
        {
            var data = await _loanTypesBusiness.GetLoanTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLoanTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanTypesBusiness.SetLoanTypesAsync(common);
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
        public async Task<ActionResult> PostLoanTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanTypesBusiness.PostLoanTypesAsync(common);
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
        public async Task<ActionResult> DelLoanTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanTypesBusiness.DelLoanTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpLoanTypes(BeanzCommonDTO lookup)
        {
            var data = await _loanTypesBusiness.LookUpLoanTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LoanTypeViewModel> GetInfoLoanTypes(BeanzCommonDTO common)
        {
            var data = await _loanTypesBusiness.GetInfoLoanTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LoanTypeViewModel> PrintLoanTypes(BeanzCommonDTO common)
        {
            var data = await _loanTypesBusiness.PrintLoanTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLoanTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanTypesBusiness.ApproveLoanTypesAsync(common);
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
