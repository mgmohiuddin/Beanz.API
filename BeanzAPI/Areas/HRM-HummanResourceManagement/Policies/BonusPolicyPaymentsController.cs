using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class BonusPolicyPaymentsController : ControllerBase
    {
        private readonly IBonusPolicyPaymentRepository _bonusPolicyPaymentsRepository;

        public BonusPolicyPaymentsController(IBonusPolicyPaymentRepository bonusPolicyPaymentsRepository)
        {
            _bonusPolicyPaymentsRepository = bonusPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<BonusPolicyPaymentDTO>> GetBonusPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _bonusPolicyPaymentsRepository.GetBonusPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetBonusPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyPaymentsRepository.SetBonusPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostBonusPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyPaymentsRepository.PostBonusPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelBonusPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyPaymentsRepository.DelBonusPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpBonusPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _bonusPolicyPaymentsRepository.LookUpBonusPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<BonusPolicyPaymentViewModel> GetInfoBonusPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _bonusPolicyPaymentsRepository.GetInfoBonusPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<BonusPolicyPaymentViewModel> PrintBonusPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _bonusPolicyPaymentsRepository.PrintBonusPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveBonusPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _bonusPolicyPaymentsRepository.ApproveBonusPolicyPaymentsAsync(common);
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
