using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.FinancialAccountingSystem.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.FinancialAccountingSystem.Masters
{
    public interface IVoucherTypeBusiness
    {
        Task<List<VoucherTypeDTO>> GetVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelVoucherTypesAsync(BeanzCommonDTO common);
        Task<VoucherTypeViewModel> GetInfoVoucherTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpVoucherTypesAsync(BeanzCommonDTO lookup);
        Task<VoucherTypeViewModel> PrintVoucherTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveVoucherTypesAsync(BeanzCommonDTO common);
    }
}
