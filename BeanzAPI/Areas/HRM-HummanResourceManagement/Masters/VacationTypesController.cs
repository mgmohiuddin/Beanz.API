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
    public class VacationTypesController : ControllerBase
    {
        private readonly IVacationTypeRepository _vacationTypesRepository;

        public VacationTypesController(IVacationTypeRepository vacationTypesRepository)
        {
            _vacationTypesRepository = vacationTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<VacationTypeDTO>> GetVacationTypes(BeanzCommonDTO common)
        {
            var data = await _vacationTypesRepository.GetVacationTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetVacationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesRepository.SetVacationTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesRepository.PostVacationTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesRepository.DelVacationTypesAsync(common);
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
            var data = await _vacationTypesRepository.LookUpVacationTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<VacationTypeViewModel> GetInfoVacationTypes(BeanzCommonDTO common)
        {
            var data = await _vacationTypesRepository.GetInfoVacationTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<VacationTypeViewModel> PrintVacationTypes(BeanzCommonDTO common)
        {
            var data = await _vacationTypesRepository.PrintVacationTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveVacationTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _vacationTypesRepository.ApproveVacationTypesAsync(common);
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
