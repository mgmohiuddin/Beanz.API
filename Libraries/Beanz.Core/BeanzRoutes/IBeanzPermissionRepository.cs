using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.BeanzRoutes
{

		public interface IBeanzPermissionRepository
        {
        Task<List<BeanzPermissionDTO>> GetBeanzPermissionsAsync(BeanzRoutesRequestDTO common);

        Task<string> SetBeanzPermissionsAsync(BeanzPermissionDTO common);

        Task<string> DelBeanzPermissionsAsync(BeanzPermissionDTO common);

        Task<List<BeanzlookupDTO>> LookUpBeanzPermissionsAsync(BeanzPermissionDTO lookup);

        //Task<AccountViewModel> GetInfoBeanzPermissionsAsync(BeanzCommonDTO common);

        //Task<List<dynamic>> GetBeanzPermissionAsync(RequestDTO dto);
        //Task<string> SetBeanzPermissionAsync(RequestDTO dto);
        //Task<string> PostBeanzPermissionAsync(RequestDTO dto);
        //Task<string> DelBeanzPermissionAsync(RequestDTO dto);
        //Task<List<BeanzlookupDTO>> LookupBeanzPermissionAsync(RequestDTO dto);


    }
	}
