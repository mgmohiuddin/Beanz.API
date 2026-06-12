using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Masters
{
    public class CostCenterBusiness : ICostCenterBusiness
    {
        private readonly ICostCenterRepository _repository;

        public CostCenterBusiness(ICostCenterRepository repository)
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
        public Task<List<CostCenterDTO>> GetCostCentersAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<CostCenterDTO>());
            return _repository.GetCostCentersAsync(common);
        }

        public async Task<BeanzResponseDTO> SetCostCentersAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            CostCenterDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<CostCenterDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.CostCenterCode))
                return Fail("ERR013", "CostCenter Code is required.");
            if (string.IsNullOrWhiteSpace(dto.CostCenterName))
                return Fail("ERR014", "CostCenter Name is required.");

            return await _repository.SetCostCentersAsync(common);
        }

        public Task<BeanzResponseDTO> PostCostCentersAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostCostCentersAsync(common);
        }

        public Task<BeanzResponseDTO> DelCostCentersAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelCostCentersAsync(common);
        }

        public Task<CostCenterViewModel> GetInfoCostCentersAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new CostCenterViewModel());
            return _repository.GetInfoCostCentersAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpCostCentersAsync(BeanzCommonDTO lookup)
            => _repository.LookUpCostCentersAsync(lookup);

        public Task<CostCenterViewModel> PrintCostCentersAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new CostCenterViewModel());
            return _repository.PrintCostCentersAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveCostCentersAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveCostCentersAsync(common);
        }
    }
}
