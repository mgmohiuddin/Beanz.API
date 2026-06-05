using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Beanz.DTOs.BeanzRoutes
{

    public class ScriptResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public string Error { get; set; }
 
    }

    public class ScriptDefinitionResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public string Error { get; set; }
        public int RowsAffected { get; set; }
        public List<Dictionary<string, object>> Data { get; set; }                    // first result set (convenience)
        public List<List<Dictionary<string, object>>> Tables { get; set; }
    }
}
