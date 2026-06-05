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
    public class AssetTypesController : ControllerBase
    {
        private readonly IAssetTypeRepository _assetTypesRepository;

        public AssetTypesController(IAssetTypeRepository assetTypesRepository)
        {
            _assetTypesRepository = assetTypesRepository;
        }

        [HttpPost("Get")]
        public async Task<List<AssetTypeDTO>> GetAssetTypes(BeanzCommonDTO common)
        {
            var data = await _assetTypesRepository.GetAssetTypesAsync(common);
            return data;
        }

        [HttpPost("Set")]
        public async Task<ActionResult> SetAssetTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _assetTypesRepository.SetAssetTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _assetTypesRepository.PostAssetTypesAsync(common);
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
                BeanzResponseDTO beanzResponseDTO = await _assetTypesRepository.DelAssetTypesAsync(common);
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
            var data = await _assetTypesRepository.LookUpAssetTypesAsync(lookup);
            return data;
        }

        [HttpPost("GetInfo")]
        public async Task<AssetTypeViewModel> GetInfoAssetTypes(BeanzCommonDTO common)
        {
            var data = await _assetTypesRepository.GetInfoAssetTypesAsync(common);
            return data;
        }

        [HttpPost("Print")]
        public async Task<AssetTypeViewModel> PrintAssetTypes(BeanzCommonDTO common)
        {
            var data = await _assetTypesRepository.PrintAssetTypesAsync(common);
            return data;
        }

        [HttpPost("Approve")]
        public async Task<ActionResult> ApproveAssetTypes(BeanzCommonDTO common)
        {
            try
            {
                BeanzResponseDTO beanzResponseDTO = await _assetTypesRepository.ApproveAssetTypesAsync(common);
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
