using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HummanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HummanResourceManagement")]
    public class TicketClassTypesController : ControllerBase
    {
        private readonly ITicketClassTypeBusiness _ticketClassTypesBusiness;

        public TicketClassTypesController(ITicketClassTypeBusiness ticketClassTypesBusiness)
        {
            _ticketClassTypesBusiness = ticketClassTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<TicketClassTypeDTO>> GetTicketClassTypes(BeanzCommonDTO common)
        {
            var data = await _ticketClassTypesBusiness.GetTicketClassTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetTicketClassTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketClassTypesBusiness.SetTicketClassTypesAsync(common);
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
        public async Task<ActionResult> PostTicketClassTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketClassTypesBusiness.PostTicketClassTypesAsync(common);
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
        public async Task<ActionResult> DelTicketClassTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketClassTypesBusiness.DelTicketClassTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpTicketClassTypes(BeanzCommonDTO lookup)
        {
            var data = await _ticketClassTypesBusiness.LookUpTicketClassTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<TicketClassTypeViewModel> GetInfoTicketClassTypes(BeanzCommonDTO common)
        {
            var data = await _ticketClassTypesBusiness.GetInfoTicketClassTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<TicketClassTypeViewModel> PrintTicketClassTypes(BeanzCommonDTO common)
        {
            var data = await _ticketClassTypesBusiness.PrintTicketClassTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveTicketClassTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _ticketClassTypesBusiness.ApproveTicketClassTypesAsync(common);
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
