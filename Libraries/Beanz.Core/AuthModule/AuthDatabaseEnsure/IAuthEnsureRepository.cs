 

using Beanz.DTOs.AuthModule.RequestResponse;
using Beanz.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Core.AuthModule.AuthDatabaseEnsure
{
    public interface IAuthEnsureRepository
    {
        Task<GeneralResponseDTO> EnsureAuthSchemaAsync();

        Task<GeneralResponseDTO> EnsureAudSchemaAsync();
        Task<GeneralResponseDTO> EnsureUsersTableAsync(); 
        Task<GeneralResponseDTO> EnsureAuditLogsTableAsync();
        Task<GeneralResponseDTO> EnsureUserSessionsTableAsync();
        Task<GeneralResponseDTO> EnsureUserTokensTableAsync();
        Task<GeneralResponseDTO> EnsureRolesTableAsync();
        Task<GeneralResponseDTO> EnsureUserRolesTableAsync();
        Task<GeneralResponseDTO> EnsureLoginAttemptsTableAsync();
        Task<GeneralResponseDTO> EnsureExternalLoginsTableAsync();
        Task<GeneralResponseDTO> EnsureEmailVerificationTokensTableAsync();

        Task<GeneralResponseDTO> EnsureUserMFATableAsync();

        Task<GeneralResponseDTO> EnsureMFAOTPsTableAsync();
        Task<GeneralResponseDTO> EnsureCompaniesTableAsync();
        Task<GeneralResponseDTO> EnsureUserCompaniesTableAsync();

        Task<GeneralResponseDTO> EnsureSystemEndpointsTableAsync();
        Task<GeneralResponseDTO> SeedDefaultCompanyAsync();

        Task<GeneralResponseDTO> EnsureUsersEmailChangedTriggerAsync();



    }
}
