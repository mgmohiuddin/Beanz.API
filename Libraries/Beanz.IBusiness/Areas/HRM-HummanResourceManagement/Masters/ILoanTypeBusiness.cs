using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.Areas.HummanResourceManagement.Masters;
using Beanz.DTOs.Common;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.IBusiness.Areas.HummanResourceManagement.Masters
{
    public interface ILoanTypeBusiness
    {
        Task<List<LoanTypeDTO>> GetLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> SetLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> PostLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> DelLoanTypesAsync(BeanzCommonDTO common);
        Task<LoanTypeViewModel> GetInfoLoanTypesAsync(BeanzCommonDTO common);
        Task<List<BeanzlookupDTO>> LookUpLoanTypesAsync(BeanzCommonDTO lookup);
        Task<LoanTypeViewModel> PrintLoanTypesAsync(BeanzCommonDTO common);
        Task<BeanzResponseDTO> ApproveLoanTypesAsync(BeanzCommonDTO common);
    }
}
