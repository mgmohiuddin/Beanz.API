using Beanz.Core.Areas.HummanResourceManagement.Policies;
using Beanz.DTOs.Areas.HummanResourceManagement.Policies;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Policies
{
    [Route("api/[area]/Policies/[controller]/[action]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class VacationPolicyPaymentsController : ControllerBase
    {
        private readonly IVacationPolicyPaymentRepository _vacationPolicyPaymentsRepository;

        public VacationPolicyPaymentsController(IVacationPolicyPaymentRepository vacationPolicyPaymentsRepository)
        {
            _vacationPolicyPaymentsRepository = vacationPolicyPaymentsRepository;
        }

        [HttpPost("Get")]
        public async Task<List<VacationPolicyPaymentDTO>> GetVacationPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _vacationPolicyPaymentsRepository.GetVacationPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVacationPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyPaymentsRepository.SetVacationPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> PostVacationPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyPaymentsRepository.PostVacationPolicyPaymentsAsync(common);
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
        public async Task<ActionResult> DelVacationPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyPaymentsRepository.DelVacationPolicyPaymentsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpVacationPolicyPayments(BeanzCommonDTO lookup)
        {
            var data = await _vacationPolicyPaymentsRepository.LookUpVacationPolicyPaymentsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VacationPolicyPaymentViewModel> GetInfoVacationPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _vacationPolicyPaymentsRepository.GetInfoVacationPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VacationPolicyPaymentViewModel> PrintVacationPolicyPayments(BeanzCommonDTO common)
        {
            var data = await _vacationPolicyPaymentsRepository.PrintVacationPolicyPaymentsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVacationPolicyPayments(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationPolicyPaymentsRepository.ApproveVacationPolicyPaymentsAsync(common);
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
