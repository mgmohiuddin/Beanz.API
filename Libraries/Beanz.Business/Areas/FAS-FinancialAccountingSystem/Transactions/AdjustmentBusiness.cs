using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Transactions;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Transactions;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Transactions
{
    public class AdjustmentBusiness : IAdjustmentBusiness
    {
        private readonly IAdjustmentRepository _repository;

        public AdjustmentBusiness(IAdjustmentRepository repository)
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
        public Task<List<AdjustmentDTO>> GetAdjustmentsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AdjustmentDTO>());
            return _repository.GetAdjustmentsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAdjustmentsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AdjustmentDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AdjustmentDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AdjustmentCode))
                return Fail("ERR013", "Adjustment Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AdjustmentName))
                return Fail("ERR014", "Adjustment Name is required.");

            return await _repository.SetAdjustmentsAsync(common);
        }

        public Task<BeanzResponseDTO> PostAdjustmentsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAdjustmentsAsync(common);
        }

        public Task<BeanzResponseDTO> DelAdjustmentsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAdjustmentsAsync(common);
        }

        public Task<AdjustmentViewModel> GetInfoAdjustmentsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AdjustmentViewModel());
            return _repository.GetInfoAdjustmentsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAdjustmentsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAdjustmentsAsync(lookup);

        public Task<AdjustmentViewModel> PrintAdjustmentsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AdjustmentViewModel());
            return _repository.PrintAdjustmentsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAdjustmentsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAdjustmentsAsync(common);
        }
    }
}
