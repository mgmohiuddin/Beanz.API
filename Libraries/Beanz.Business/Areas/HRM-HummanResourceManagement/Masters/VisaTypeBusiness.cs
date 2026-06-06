using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Beanz.Core.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;
using Beanz.IBusiness.Areas.HummanResourceManagement.Masters;

namespace Beanz.Business.Areas.HummanResourceManagement.Masters
{
    public class VisaTypeBusiness : IVisaTypeBusiness
    {
        private readonly IVisaTypeRepository _repository;

        public VisaTypeBusiness(IVisaTypeRepository repository)
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
        public Task<List<VisaTypeDTO>> GetVisaTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<VisaTypeDTO>());
            return _repository.GetVisaTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetVisaTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            VisaTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<VisaTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.VisaTypeCode))
                return Fail("ERR013", "VisaType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.VisaTypeName))
                return Fail("ERR014", "VisaType Name is required.");

            return await _repository.SetVisaTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostVisaTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostVisaTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelVisaTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelVisaTypesAsync(common);
        }

        public Task<VisaTypeViewModel> GetInfoVisaTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new VisaTypeViewModel());
            return _repository.GetInfoVisaTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpVisaTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpVisaTypesAsync(lookup);

        public Task<VisaTypeViewModel> PrintVisaTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new VisaTypeViewModel());
            return _repository.PrintVisaTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveVisaTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveVisaTypesAsync(common);
        }
    }
}
