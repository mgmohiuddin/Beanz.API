using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
//using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class VacationTypesController : ControllerBase
    {
        private readonly IVacationTypeBusiness _vacationTypesBusiness;

        public VacationTypesController(IVacationTypeBusiness vacationTypesBusiness)
        {
            _vacationTypesBusiness = vacationTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<VacationTypeDTO>> GetVacationTypes(BeanzCommonDTO common)
        {
            var data = await _vacationTypesBusiness.GetVacationTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVacationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesBusiness.SetVacationTypesAsync(common);
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
        public async Task<ActionResult> PostVacationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesBusiness.PostVacationTypesAsync(common);
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
        public async Task<ActionResult> DelVacationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesBusiness.DelVacationTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpVacationTypes(BeanzCommonDTO lookup)
        {
            var data = await _vacationTypesBusiness.LookUpVacationTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VacationTypeViewModel> GetInfoVacationTypes(BeanzCommonDTO common)
        {
            var data = await _vacationTypesBusiness.GetInfoVacationTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VacationTypeViewModel> PrintVacationTypes(BeanzCommonDTO common)
        {
            var data = await _vacationTypesBusiness.PrintVacationTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVacationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesBusiness.ApproveVacationTypesAsync(common);
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
