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
    public class TicketTypesController : ControllerBase
    {
        private readonly ITicketTypeRepository _ticketTypesRepository;

        public TicketTypesController(ITicketTypeRepository ticketTypesRepository)
        {
            _ticketTypesRepository = ticketTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<TicketTypeDTO>> GetTicketTypes(BeanzCommonDTO common)
        {
            var data = await _ticketTypesRepository.GetTicketTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTicketTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketTypesRepository.SetTicketTypesAsync(common);
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
        public async Task<ActionResult> PostTicketTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketTypesRepository.PostTicketTypesAsync(common);
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
        public async Task<ActionResult> DelTicketTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketTypesRepository.DelTicketTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTicketTypes(BeanzCommonDTO lookup)
        {
            var data = await _ticketTypesRepository.LookUpTicketTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TicketTypeViewModel> GetInfoTicketTypes(BeanzCommonDTO common)
        {
            var data = await _ticketTypesRepository.GetInfoTicketTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TicketTypeViewModel> PrintTicketTypes(BeanzCommonDTO common)
        {
            var data = await _ticketTypesRepository.PrintTicketTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTicketTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketTypesRepository.ApproveTicketTypesAsync(common);
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
