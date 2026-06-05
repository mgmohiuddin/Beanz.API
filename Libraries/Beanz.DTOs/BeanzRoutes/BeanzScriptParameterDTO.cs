using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Beanz.DTOs.BeanzRoutes
{
   
    public class ScriptParameterDTO
    {
        
            public string DataSource { get; set; } = "";
            public string UserId { get; set; } = "";
            public string Password { get; set; } = "";
            public string InitialCatalog { get; set; } = "";
            public string Script { get; set; } = "";

            public string SchemaName { get; set; } = "";
            public string TableName { get; set; } = "";

    }
    public class ScriptDefinitionParameterDTO
    {

        public string DataSource { get; set; } = "";
        public string UserId { get; set; } = "";
        public string Password { get; set; } = "";
        public string InitialCatalog { get; set; } = "";
        public string Script { get; set; } = "";

        public string SchemaName { get; set; } = "";
        public string TableName { get; set; } = "";
        public int RowsAffected { get; set; }
        public List<Dictionary<string, object>> Data { get; set; }                    // first result set (convenience)
        public List<List<Dictionary<string, object>>> Tables { get; set; }            // all result sets

    }


    public class ScriptResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        //public List<Dictionary<string, object>> Rows { get; set; } = new();
        public int RowsAffected { get; set; }
        //public Dictionary<string, object> Response { get; set; }   // 
        public SpResponse Response { get; set; }   // NEW
    }

    public class SpResponse
    {
        public int? ResponseID { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
