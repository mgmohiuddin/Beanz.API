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
    public class TravelTypeBusiness : ITravelTypeBusiness
    {
        private readonly ITravelTypeRepository _repository;

        public TravelTypeBusiness(ITravelTypeRepository repository)
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
        public Task<List<TravelTypeDTO>> GetTravelTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<TravelTypeDTO>());
            return _repository.GetTravelTypesAsync(common);
        }

        public async Task<BeanzResponseDTO> SetTravelTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            TravelTypeDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<TravelTypeDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.TravelTypeCode))
                return Fail("ERR013", "TravelType Code is required.");
            if (string.IsNullOrWhiteSpace(dto.TravelTypeName))
                return Fail("ERR014", "TravelType Name is required.");

            return await _repository.SetTravelTypesAsync(common);
        }

        public Task<BeanzResponseDTO> PostTravelTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostTravelTypesAsync(common);
        }

        public Task<BeanzResponseDTO> DelTravelTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelTravelTypesAsync(common);
        }

        public Task<TravelTypeViewModel> GetInfoTravelTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new TravelTypeViewModel());
            return _repository.GetInfoTravelTypesAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpTravelTypesAsync(BeanzCommonDTO lookup)
            => _repository.LookUpTravelTypesAsync(lookup);

        public Task<TravelTypeViewModel> PrintTravelTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new TravelTypeViewModel());
            return _repository.PrintTravelTypesAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveTravelTypesAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveTravelTypesAsync(common);
        }
    }
}
