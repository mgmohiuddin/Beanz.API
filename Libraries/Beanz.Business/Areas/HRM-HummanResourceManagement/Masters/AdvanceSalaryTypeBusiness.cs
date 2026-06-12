using Beanz.Business.Helper;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class AdvanceSalaryTypeBusiness : BaseBusiness ,IAdvanceSalaryTypeBusiness
    {
        private readonly IAdvanceSalaryTypeRepository _repository;

        public AdvanceSalaryTypeBusiness(IAdvanceSalaryTypeRepository repository)
        {
            _repository = repository;
        }

        // ---------- Validation Helpers ----------
        private static BeanzResponseDTO Fail(string code, string message)
            => new BeanzResponseDTO { ErrorCode = code, ErrorMessage = message };

        private static BeanzResponseDTO ValidateContext(BeanzRequestDTO common)
        {
            if (common == null)
                return Fail("ERR001", "Request payload is required.");
            if (common.CompanyID <= 0)
                return Fail("ERR002", "CompanyID is required.");
            if (common.UserID <= 0)
                return Fail("ERR003", "UserID is required.");
            return null;
        }

        private static BeanzResponseDTO ValidateKey(BeanzRequestDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;
            if (common.PrimaryKeyID <= 0)
                return Fail("ERR010", "PrimaryKeyID is required.");
            return null;
        }

        // ---------- Methods ----------
        public async Task<BeanzResponseObjectDTO<List<AdvanceSalaryTypeDTO>>> GetAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateContext(common);

            if (ctx != null)
                return new BeanzResponseObjectDTO<List<AdvanceSalaryTypeDTO>>
                {
                    Success = false,
                    ErrorCode = ctx.ErrorCode,
                    Message = ctx.ErrorMessage,
                    Data = null,
                    StatusCode = 400
                };

            var data = await _repository.GetAdvanceSalaryTypesAsync(common);
            return data;
            //return new BeanzResponseObjectDTO<List<AdvanceSalaryTypeDTO>>
            //{
            //    Success = true,
            //    Data = data,
            //    StatusCode = 200
            //};
            //return Task.FromResult(new List<AdvanceSalaryTypeDTO>());
            //return _repository.GetAdvanceSalaryTypesAsync(common);
        }

        public async Task<BeanzResponseObjectDTO<int?>> SetAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        {
            // 1. Context validation
            var ctx = ValidateContext<int?>(common);
            if (ctx != null) return ctx;

            // 2. Json payload presence
            if (string.IsNullOrWhiteSpace(common.Json))
                return BeanzResponseObjectDTO<int?>.Fail("Request data (Json) is required.", "ERR011", 400);

            // 3. Deserialize
            AdvanceSalaryTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AdvanceSalaryTypeDTO>(common.Json);
            }
            catch
            {
                return BeanzResponseObjectDTO<int?>.Fail("Invalid request payload format.", "ERR012", 400);
            }

            if (dto == null)
                return BeanzResponseObjectDTO<int?>.Fail("Invalid request payload.", "ERR012", 400);

            // 4. DTO validation (DataAnnotations like [Required])
            var validationResults = new List<ValidationResult>();
            //var validationContext = new ValidationContext(dto);
            var dtoError = ValidateDto<int?, AdvanceSalaryTypeDTO>(dto);
            if (dtoError != null) return dtoError;

            //if (!Validator.TryValidateObject(dto, validationContext, validationResults, validateAllProperties: true))
            //{
            //    var firstError = validationResults.FirstOrDefault()?.ErrorMessage ?? "Validation failed.";
            //    return BeanzResponseObjectDTO<int?>.Fail(firstError, "ERR013", 400, validationResults.Select(r => r.ErrorMessage));
            //}

            // 5. Extra business conditions
            if (string.IsNullOrWhiteSpace(dto.AdvanceSalaryTypeCode))
                return BeanzResponseObjectDTO<int?>.Fail("AdvanceSalaryType Code is required.", "ERR014", 400);

            // 6. Call repository
            return await _repository.SetAdvanceSalaryTypesAsync(common);
        }


        //public async Task<BeanzResponseObjectDTO<int?>> SetAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        //{
        //    var ctx = ValidateContext<int?>(common);
        //    if (ctx != null) return ctx;

        //    if (string.IsNullOrWhiteSpace(common.Json))
        //        return BeanzResponseObjectDTO<int?>.Fail("Request data (Json) is required.", "ERR011", 400);

        //    AdvanceSalaryTypeDTO dto;
        //    try
        //    {
        //        dto = JsonConvert.DeserializeObject<AdvanceSalaryTypeDTO>(common.Json);
        //    }
        //    catch
        //    {
        //        return BeanzResponseObjectDTO<int?>.Fail("Invalid request payload format.", "ERR012", 400);
        //    }

        //    if (dto == null)
        //        return BeanzResponseObjectDTO<int?>.Fail("Invalid request payload.", "ERR012", 400);

        //    if (string.IsNullOrWhiteSpace(dto.AdvanceSalaryTypeCode))
        //        return BeanzResponseObjectDTO<int?>.Fail("AdvanceSalaryType Code is required.", "ERR013", 400);

        //    if (string.IsNullOrWhiteSpace(dto.AdvanceSalaryTypeName))
        //        return BeanzResponseObjectDTO<int?>.Fail("AdvanceSalaryType Name is required.", "ERR014", 400);

        //    return await _repository.SetAdvanceSalaryTypesAsync(common);
        //}
        //public async Task<BeanzResponseDTO> SetAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        //{
        //    var ctx = ValidateContext(common);
        //    if (ctx != null) return ctx;

        //    if (string.IsNullOrWhiteSpace(common.Json))
        //        return Fail("ERR011", "Request data (Json) is required.");

        //    AdvanceSalaryTypeDTO dto;
        //    try
        //    {
        //        dto = JsonConvert.DeserializeObject<AdvanceSalaryTypeDTO>(common.Json);
        //    }
        //    catch
        //    {
        //        return Fail("ERR012", "Invalid request payload format.");
        //    }

        //    if (dto == null)
        //        return Fail("ERR012", "Invalid request payload.");
        //    if (string.IsNullOrWhiteSpace(dto.AdvanceSalaryTypeCode))
        //        return Fail("ERR013", "AdvanceSalaryType Code is required.");
        //    if (string.IsNullOrWhiteSpace(dto.AdvanceSalaryTypeName))
        //        return Fail("ERR014", "AdvanceSalaryType Name is required.");

        //    return await _repository.SetAdvanceSalaryTypesAsync(common);
        //}

        public Task<BeanzResponseDTO> PostAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAdvanceSalaryTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAdvanceSalaryTypesAsync(common);
        }

        public Task<AdvanceSalaryTypeViewModel> GetInfoAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AdvanceSalaryTypeViewModel());
            return _repository.GetInfoAdvanceSalaryTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAdvanceSalaryTypesAsync(BeanzRequestDTO lookup)
            => _repository.LookUpAdvanceSalaryTypesAsync(lookup);

        public Task<AdvanceSalaryTypeViewModel> PrintAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AdvanceSalaryTypeViewModel());
            return _repository.PrintAdvanceSalaryTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAdvanceSalaryTypesAsync(BeanzRequestDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAdvanceSalaryTypesAsync(common);
        }
    }
}
