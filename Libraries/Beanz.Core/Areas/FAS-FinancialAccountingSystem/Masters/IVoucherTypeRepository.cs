using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.Areas.FinancialAccountingSystem.Masters
{
    public interface IVoucherTypeRepository
    {
        Task<List<VoucherTypeDTO>> GetVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVoucherTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVoucherTypesAsync(BeanzCommonDTO lookup);
        Task<VoucherTypeViewModel> GetInfoVoucherTypesAsync(BeanzCommonDTO common);
        Task<VoucherTypeViewModel> PrintVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVoucherTypesAsync(BeanzCommonDTO common);
    }
}
