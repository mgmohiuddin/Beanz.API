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
    public class PayrollTypesController : ControllerBase
    {
        private readonly IPayrollTypeBusiness _payrollTypesBusiness;

        public PayrollTypesController(IPayrollTypeBusiness payrollTypesBusiness)
        {
            _payrollTypesBusiness = payrollTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<PayrollTypeDTO>> GetPayrollTypes(BeanzCommonDTO common)
        {
            var data = await _payrollTypesBusiness.GetPayrollTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetPayrollTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollTypesBusiness.SetPayrollTypesAsync(common);
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
        public async Task<ActionResult> PostPayrollTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollTypesBusiness.PostPayrollTypesAsync(common);
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
        public async Task<ActionResult> DelPayrollTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollTypesBusiness.DelPayrollTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpPayrollTypes(BeanzCommonDTO lookup)
        {
            var data = await _payrollTypesBusiness.LookUpPayrollTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<PayrollTypeViewModel> GetInfoPayrollTypes(BeanzCommonDTO common)
        {
            var data = await _payrollTypesBusiness.GetInfoPayrollTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<PayrollTypeViewModel> PrintPayrollTypes(BeanzCommonDTO common)
        {
            var data = await _payrollTypesBusiness.PrintPayrollTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApprovePayrollTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _payrollTypesBusiness.ApprovePayrollTypesAsync(common);
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
