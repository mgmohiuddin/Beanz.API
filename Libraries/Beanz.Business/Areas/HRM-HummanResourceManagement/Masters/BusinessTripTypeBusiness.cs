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
    public class BusinessTripTypeBusiness : IBusinessTripTypeBusiness
    {
        private readonly IBusinessTripTypeRepository _repository;

        public BusinessTripTypeBusiness(IBusinessTripTypeRepository repository)
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
        public Task<List<BusinessTripTypeDTO>> GetBusinessTripTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<BusinessTripTypeDTO>());
            return _repository.GetBusinessTripTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetBusinessTripTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            BusinessTripTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<BusinessTripTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.BusinessTripTypeCode))
                return Fail("ERR013", "BusinessTripType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.BusinessTripTypeName))
                return Fail("ERR014", "BusinessTripType Name is required.");

            return await _repository.SetBusinessTripTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostBusinessTripTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostBusinessTripTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelBusinessTripTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelBusinessTripTypesAsync(common);
        }

        public Task<BusinessTripTypeViewModel> GetInfoBusinessTripTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new BusinessTripTypeViewModel());
            return _repository.GetInfoBusinessTripTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpBusinessTripTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpBusinessTripTypesAsync(lookup);

        public Task<BusinessTripTypeViewModel> PrintBusinessTripTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new BusinessTripTypeViewModel());
            return _repository.PrintBusinessTripTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveBusinessTripTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveBusinessTripTypesAsync(common);
        }
    }
}
