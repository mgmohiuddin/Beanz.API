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
    public class AdjustmentDetailBusiness : IAdjustmentDetailBusiness
    {
        private readonly IAdjustmentDetailRepository _repository;

        public AdjustmentDetailBusiness(IAdjustmentDetailRepository repository)
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
        public Task<List<AdjustmentDetailDTO>> GetAdjustmentDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<AdjustmentDetailDTO>());
            return _repository.GetAdjustmentDetailsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetAdjustmentDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            AdjustmentDetailDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<AdjustmentDetailDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.AdjustmentDetailCode))
                return Fail("ERR013", "AdjustmentDetail Code is required.");
            if (string.IsNullOrWhiteSpace(dto.AdjustmentDetailName))
                return Fail("ERR014", "AdjustmentDetail Name is required.");

            return await _repository.SetAdjustmentDetailsAsync(common);
        }

        public Task<BeanzResponseDTO> PostAdjustmentDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostAdjustmentDetailsAsync(common);
        }

        public Task<BeanzResponseDTO> DelAdjustmentDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelAdjustmentDetailsAsync(common);
        }

        public Task<AdjustmentDetailViewModel> GetInfoAdjustmentDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new AdjustmentDetailViewModel());
            return _repository.GetInfoAdjustmentDetailsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpAdjustmentDetailsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpAdjustmentDetailsAsync(lookup);

        public Task<AdjustmentDetailViewModel> PrintAdjustmentDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new AdjustmentDetailViewModel());
            return _repository.PrintAdjustmentDetailsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveAdjustmentDetailsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveAdjustmentDetailsAsync(common);
        }
    }
}
