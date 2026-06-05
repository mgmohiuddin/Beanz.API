using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.BeanzRoutes;
using Beanz.DTOs.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beanz.Core.BeanzRoutes
{

		public interface IBeanzRepository
    {

        Task<List<dynamic>> GetAsync(BeanzRequestDTO dto);
        Task<BeanzResponseDTO> SetAsync(BeanzRequestDTO dto);
        Task<BeanzResponseDTO> PostAsync(BeanzRequestDTO dto);
        Task<BeanzResponseDTO> DelAsync(BeanzRequestDTO dto);
        Task<List<BeanzlookupDTO>> LookupAsync(BeanzRequestDTO dto);
        Task<dynamic> GetInfoAsync(BeanzRequestDTO dto);

        Task<dynamic> PrintAsync(BeanzRequestDTO dto);

    }
	}
