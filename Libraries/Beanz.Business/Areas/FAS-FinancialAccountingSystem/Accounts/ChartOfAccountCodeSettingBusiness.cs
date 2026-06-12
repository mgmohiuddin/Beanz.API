using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Accounts;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.FinancialAccountingSystem.Accounts;

namespace Beanz.Business.Areas.FinancialAccountingSystem.Accounts
{
    public class ChartOfAccountCodeSettingBusiness : IChartOfAccountCodeSettingBusiness
    {
        private readonly IChartOfAccountCodeSettingRepository _repository;

        public ChartOfAccountCodeSettingBusiness(IChartOfAccountCodeSettingRepository repository)
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
        public Task<List<ChartOfAccountCodeSettingDTO>> GetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<ChartOfAccountCodeSettingDTO>());
            return _repository.GetChartOfAccountCodeSettingsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            ChartOfAccountCodeSettingDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<ChartOfAccountCodeSettingDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.ChartOfAccountCodeSettingCode))
                return Fail("ERR013", "ChartOfAccountCodeSetting Code is required.");
            if (string.IsNullOrWhiteSpace(dto.ChartOfAccountCodeSettingName))
                return Fail("ERR014", "ChartOfAccountCodeSetting Name is required.");

            return await _repository.SetChartOfAccountCodeSettingsAsync(common);
        }

        public Task<BeanzResponseDTO> PostChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostChartOfAccountCodeSettingsAsync(common);
        }

        public Task<BeanzResponseDTO> DelChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelChartOfAccountCodeSettingsAsync(common);
        }

        public Task<ChartOfAccountCodeSettingViewModel> GetInfoChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new ChartOfAccountCodeSettingViewModel());
            return _repository.GetInfoChartOfAccountCodeSettingsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpChartOfAccountCodeSettingsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpChartOfAccountCodeSettingsAsync(lookup);

        public Task<ChartOfAccountCodeSettingViewModel> PrintChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new ChartOfAccountCodeSettingViewModel());
            return _repository.PrintChartOfAccountCodeSettingsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveChartOfAccountCodeSettingsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveChartOfAccountCodeSettingsAsync(common);
        }
    }
}
