using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;
using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Areas.HumanResourceManagement.Masters
{
    [Route("api/[area]/Masters/[controller]")]
    [ApiController]
    [Area("HumanResourceManagement")]
    public class AssetTypesController : ControllerBase
    {
        private readonly IAssetTypeBusiness _assetTypesBusiness;

        public AssetTypesController(IAssetTypeBusiness assetTypesBusiness)
        {
            _assetTypesBusiness = assetTypesBusiness;
        }

        [HttpPost("Get")]
        public async Task<List<AssetTypeDTO>> GetAssetTypes(BeanzCommonDTO common)
        {
            var data = await _assetTypesBusiness.GetAssetTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAssetTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _assetTypesBusiness.SetAssetTypesAsync(common);
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
        public async Task<ActionResult> PostAssetTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _assetTypesBusiness.PostAssetTypesAsync(common);
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
        public async Task<ActionResult> DelAssetTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _assetTypesBusiness.DelAssetTypesAsync(common);
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
        public async Task<List<BeanzlookupDTO>> LookUpAssetTypes(BeanzCommonDTO lookup)
        {
            var data = await _assetTypesBusiness.LookUpAssetTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AssetTypeViewModel> GetInfoAssetTypes(BeanzCommonDTO common)
        {
            var data = await _assetTypesBusiness.GetInfoAssetTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AssetTypeViewModel> PrintAssetTypes(BeanzCommonDTO common)
        {
            var data = await _assetTypesBusiness.PrintAssetTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAssetTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _assetTypesBusiness.ApproveAssetTypesAsync(common);
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
