using System.Collections.Generic;
using System.Threading.Tasks;
using Beanz.DTOs.BeanzRoutes;

namespace Beanz.Core.BeanzRoutes
{

	public interface IBeanzScriptRepository
    {
        Task<ScriptResponseDTO> ExecuteScriptAsync(ScriptParameterDTO dto);

        Task<ScriptDefinitionResponseDTO> ExecuteDefinitionScriptAsync(ScriptDefinitionParameterDTO dto);
        Task<dynamic> GetDatabaseObjectsAsync(ScriptParameterDTO dto);

        Task<dynamic> GetDatabaseTableDetailsAsync(ScriptParameterDTO dto);

        Task<ScriptResult> ExecuteSPAsync(ScriptParameterDTO dto);
    }
	}
