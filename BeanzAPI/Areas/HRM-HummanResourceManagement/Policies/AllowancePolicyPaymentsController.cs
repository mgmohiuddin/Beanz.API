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
    public class AllowancePolicyPaymentsController : ControllerBase
    {
        private readonly IAllowancePolicyPaymentRepository _allowancePolicyPaymentsRepository;

        public AllowancePolicyPaymentsController(IAllowancePolicyPaymentRepository allowancePolicyPaymentsRepository)
        {
            _allowancePolicyPaymentsRepository = allowancePolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AllowancePolicyPaymentDTO>> GetAllowancePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _allowancePolicyPaymentsRepository.GetAllowancePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAllowancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyPaymentsRepository.SetAllowancePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostAllowancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyPaymentsRepository.PostAllowancePolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelAllowancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyPaymentsRepository.DelAllowancePolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAllowancePolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _allowancePolicyPaymentsRepository.LookUpAllowancePolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AllowancePolicyPaymentViewModel> GetInfoAllowancePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _allowancePolicyPaymentsRepository.GetInfoAllowancePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AllowancePolicyPaymentViewModel> PrintAllowancePolicyPayments(BeanzCommonDTO common)
        {
            var data = await _allowancePolicyPaymentsRepository.PrintAllowancePolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAllowancePolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _allowancePolicyPaymentsRepository.ApproveAllowancePolicyPaymentsAsync(common);
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
