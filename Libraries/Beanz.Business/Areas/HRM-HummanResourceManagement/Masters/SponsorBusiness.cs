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
    public class SponsorBusiness : ISponsorBusiness
    {
        private readonly ISponsorRepository _repository;

        public SponsorBusiness(ISponsorRepository repository)
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
        public Task<List<SponsorDTO>> GetSponsorsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new List<SponsorDTO>());
            return _repository.GetSponsorsAsync(common);
        }

        public async Task<BeanzResponseDTO> SetSponsorsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return ctx;

            if (string.IsNullOrWhiteSpace(common.Json))
                return Fail("ERR011", "Request data (Json) is required.");

            SponsorDTO dto;
            try
            {
                dto = JsonConvert.DeserializeObject<SponsorDTO>(common.Json);
            }
            catch
            {
                return Fail("ERR012", "Invalid request payload format.");
            }

            if (dto == null)
                return Fail("ERR012", "Invalid request payload.");
            if (string.IsNullOrWhiteSpace(dto.SponsorCode))
                return Fail("ERR013", "Sponsor Code is required.");
            if (string.IsNullOrWhiteSpace(dto.SponsorName))
                return Fail("ERR014", "Sponsor Name is required.");

            return await _repository.SetSponsorsAsync(common);
        }

        public Task<BeanzResponseDTO> PostSponsorsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.PostSponsorsAsync(common);
        }

        public Task<BeanzResponseDTO> DelSponsorsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.DelSponsorsAsync(common);
        }

        public Task<SponsorViewModel> GetInfoSponsorsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateContext(common);
            if (ctx != null) return Task.FromResult(new SponsorViewModel());
            return _repository.GetInfoSponsorsAsync(common);
        }

        public Task<List<BeanzlookupDTO>> LookUpSponsorsAsync(BeanzCommonDTO lookup)
            => _repository.LookUpSponsorsAsync(lookup);

        public Task<SponsorViewModel> PrintSponsorsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(new SponsorViewModel());
            return _repository.PrintSponsorsAsync(common);
        }

        public Task<BeanzResponseDTO> ApproveSponsorsAsync(BeanzCommonDTO common)
        {
            var ctx = ValidateKey(common);
            if (ctx != null) return Task.FromResult(ctx);
            return _repository.ApproveSponsorsAsync(common);
        }
    }
}
