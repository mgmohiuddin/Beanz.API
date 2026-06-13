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
    public class BusinessTripPayTypeBusiness : IBusinessTripPayTypeBusiness
    {
        private readonly IBusinessTripPayTypeRepository _repository;

        public BusinessTripPayTypeBusiness(IBusinessTripPayTypeRepository repository)
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
        public Task<List<BusinessTripPayTypeDTO>> GetBusinessTripPayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<BusinessTripPayTypeDTO>());
            return _repository.GetBusinessTripPayTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetBusinessTripPayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            BusinessTripPayTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<BusinessTripPayTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.BusinessTripPayTypeCode))
                return Fail("ERR013", "BusinessTripPayType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.BusinessTripPayTypeName))
                return Fail("ERR014", "BusinessTripPayType Name is required.");

            return await _repository.SetBusinessTripPayTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostBusinessTripPayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostBusinessTripPayTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelBusinessTripPayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelBusinessTripPayTypesAsync(common);
        }

        public Task<BusinessTripPayTypeViewModel> GetInfoBusinessTripPayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new BusinessTripPayTypeViewModel());
            return _repository.GetInfoBusinessTripPayTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpBusinessTripPayTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpBusinessTripPayTypesAsync(lookup);

        public Task<BusinessTripPayTypeViewModel> PrintBusinessTripPayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new BusinessTripPayTypeViewModel());
            return _repository.PrintBusinessTripPayTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveBusinessTripPayTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveBusinessTripPayTypesAsync(common);
        }
    }
}
