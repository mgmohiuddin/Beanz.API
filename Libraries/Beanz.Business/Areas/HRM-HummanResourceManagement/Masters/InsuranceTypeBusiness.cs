using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Areas.HumanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.HumanResourceManagement.Masters;

namespace Beanz.Business.Areas.HumanResourceManagement.Masters
{
    public class InsuranceTypeBusiness : IInsuranceTypeBusiness
    {
        private readonly IInsuranceTypeRepository _repository;

        public InsuranceTypeBusiness(IInsuranceTypeRepository repository)
        {
            _repository = repository;
        }

        // ---------- Validation Helpers ----------
        private static BeanzResponseDTO Fail(string code, string message)
            => new BeanzResponseDTO { ErrorCode = code, ErrorMessage = message };

        private static BeanzResponseDTO ValidateContext(BeanzCommonDTO common)
        {
            if (common == null)
                return Fail("ERR001", "Request payload is required.");
            if (common.CompanyID <= 0)
                return Fail("ERR002", "CompanyID is required.");
            if (common.UserID <= 0)
                return Fail("ERR003", "UserID is required.");
            return null;
        }

        private static BeanzResponseDTO ValidateKey(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;
            if (common.PrimaryKeyID <= 0)
                return Fail("ERR010", "PrimaryKeyID is required.");
            return null;
        }

        // ---------- Methods ----------
        public Task<List<InsuranceTypeDTO>> GetInsuranceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<InsuranceTypeDTO>());
            return _repository.GetInsuranceTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetInsuranceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            InsuranceTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<InsuranceTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.InsuranceTypeCode))
                return Fail("ERR013", "InsuranceType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.InsuranceTypeName))
                return Fail("ERR014", "InsuranceType Name is required.");

            return await _repository.SetInsuranceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostInsuranceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostInsuranceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelInsuranceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelInsuranceTypesAsync(common);
        }

        public Task<InsuranceTypeViewModel> GetInfoInsuranceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new InsuranceTypeViewModel());
            return _repository.GetInfoInsuranceTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpInsuranceTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpInsuranceTypesAsync(lookup);

        public Task<InsuranceTypeViewModel> PrintInsuranceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new InsuranceTypeViewModel());
            return _repository.PrintInsuranceTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveInsuranceTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveInsuranceTypesAsync(common);
        }
    }
}
