using Beanz.Core.Areas.HumanResourceManagement.Policies;
using Beanz.DTOs.Areas.HumanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class GosiPolicyPaymentsController : ControllerBase
    {
        private readonly IGosiPolicyPaymentRepository _gosiPolicyPaymentsRepository;

        public GosiPolicyPaymentsController(IGosiPolicyPaymentRepository gosiPolicyPaymentsRepository)
        {
            _gosiPolicyPaymentsRepository = gosiPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<GosiPolicyPaymentDTO>> GetGosiPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyPaymentsRepository.GetGosiPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetGosiPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyPaymentsRepository.SetGosiPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostGosiPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyPaymentsRepository.PostGosiPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelGosiPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyPaymentsRepository.DelGosiPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpGosiPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _gosiPolicyPaymentsRepository.LookUpGosiPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<GosiPolicyPaymentViewModel> GetInfoGosiPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyPaymentsRepository.GetInfoGosiPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<GosiPolicyPaymentViewModel> PrintGosiPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _gosiPolicyPaymentsRepository.PrintGosiPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveGosiPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _gosiPolicyPaymentsRepository.ApproveGosiPolicyPaymentsAsync(common);
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
