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
    public class DesignationsController : ControllerBase
    {
        private readonly IDesignationBusiness _designationsBusiness;

        public DesignationsController(IDesignationBusiness designationsBusiness)
        {
            _designationsBusiness = designationsBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<DesignationDTO>> GetDesignations(BeanzCommonDTO common)
        {
            var data = await _designationsBusiness.GetDesignationsAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsBusiness.SetDesignationsAsync(common);
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
        public async Task<ActionResult> PostDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsBusiness.PostDesignationsAsync(common);
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
        public async Task<ActionResult> DelDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsBusiness.DelDesignationsAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpDesignations(BeanzCommonDTO lookup)
        {
            var data = await _designationsBusiness.LookUpDesignationsAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<DesignationViewModel> GetInfoDesignations(BeanzCommonDTO common)
        {
            var data = await _designationsBusiness.GetInfoDesignationsAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<DesignationViewModel> PrintDesignations(BeanzCommonDTO common)
        {
            var data = await _designationsBusiness.PrintDesignationsAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveDesignations(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _designationsBusiness.ApproveDesignationsAsync(common);
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
