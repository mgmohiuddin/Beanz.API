using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;

namespace Beanz.Core.BeanzRoutes
{

		public interface IBeanzRepository
    {

        Task<List<dynamic>> GetAsync(BeanzRoutesRequestDTO dto);
        Task<BeanzRoutesResponseDTO> SetAsync(BeanzRoutesRequestDTO dto);
        Task<BeanzRoutesResponseDTO> PostAsync(BeanzRoutesRequestDTO dto);
        Task<BeanzRoutesResponseDTO> DelAsync(BeanzRoutesRequestDTO dto);
        Task<List<BeanzlookupDTO>> LookupAsync(BeanzRoutesRequestDTO dto);
        Task<dynamic> GetInfoAsync(BeanzRoutesRequestDTO dto);

        Task<dynamic> PrintAsync(BeanzRoutesRequestDTO dto);

    }
	}
