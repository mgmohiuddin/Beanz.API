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
    public class LoanTypesController : ControllerBase
    {
        private readonly ILoanTypeRepository _loanTypesRepository;

        public LoanTypesController(ILoanTypeRepository loanTypesRepository)
        {
            _loanTypesRepository = loanTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<LoanTypeDTO>> GetLoanTypes(BeanzCommonDTO common)
        {
            var data = await _loanTypesRepository.GetLoanTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetLoanTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanTypesRepository.SetLoanTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _loanTypesRepository.PostLoanTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _loanTypesRepository.DelLoanTypesAsync(common);
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
            var data = await _loanTypesRepository.LookUpLoanTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<LoanTypeViewModel> GetInfoLoanTypes(BeanzCommonDTO common)
        {
            var data = await _loanTypesRepository.GetInfoLoanTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<LoanTypeViewModel> PrintLoanTypes(BeanzCommonDTO common)
        {
            var data = await _loanTypesRepository.PrintLoanTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveLoanTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _loanTypesRepository.ApproveLoanTypesAsync(common);
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
