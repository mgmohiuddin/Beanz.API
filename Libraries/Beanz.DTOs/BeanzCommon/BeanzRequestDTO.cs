using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Beanz.DTOs.Common
{
   
    public class  BeanzRequestDTO 
    {
        public int? Type { get; set; }
        private string _json;
        public string Json
        {
            get => _json;
            set => _json = ConvertJsonToLowCase(value);

        }
        public string Json2        { get; set; }
        public long? PrimaryKeyID { get; set; }
        public long? ForeignKeyID { get; set; }
        public long? CompanyID { get; set; }
        public long? UserID { get; set; }
        public int? LanguageID { get; set; }
        public string ScreenID { get; set; }
        public string SearchText { get; set; }
        public int EmployeeID { get; set; }

        public int? BranchID { get; set; }
        public string ForeginValueField { get; set; }

        public int Page {  get; set; } = 1;
        public int PageCount { get; set; } = 100;
        public int PageSize { get; set; } = 1000;

        private string ConvertJsonToUpperCamelCase1(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return json;

            JObject obj = JObject.Parse(json);
            JObject newObj = new JObject();

            foreach (var prop in obj.Properties())
            {
                 
                string newName = char.ToUpper(prop.Name[0]) + prop.Name.Substring(1);
                newObj[newName] = prop.Value;
            }

            return newObj.ToString();
        }


        private string ConvertJsonToLowCase(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return json;

            JToken token = JToken.Parse(json);
            RenameLowKeys(token);
            return token.ToString();
        }

        private void RenameLowKeys(JToken token)
        {
            if (token is JObject obj)
            {
                var properties = obj.Properties().ToList();
                foreach (var prop in properties)
                {
                    string newName = ToLowCase(prop.Name);
                    if (newName != prop.Name)
                    {
                        var newProp = new JProperty(newName, prop.Value);
                        prop.Replace(newProp);
                        RenameLowKeys(newProp.Value);
                    }
                    else
                    {
                        RenameLowKeys(prop.Value);
                    }
                }
            }
            else if (token is JArray arr)
            {
                foreach (var item in arr)
                    RenameLowKeys(item);
            }
        }
        private string ToLowCase(string name)
        {
            if (string.IsNullOrEmpty(name))
                return name;
            return name.ToLowerInvariant();
        }
        //private string ToLowCase(string name)
        //{
        //    if (string.IsNullOrEmpty(name) || char.IsLower(name[0]))
        //        return name;

        //    return char.ToLowerInvariant(name[0]) + name.Substring(1);
        //}

        private string ConvertJsonToUpperCamelCase(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return json;

            JToken token = JToken.Parse(json);
            RenameKeys(token);
            return token.ToString();
        }

        private void RenameKeys(JToken token)
        {
            if (token is JObject obj)
            {
                var props = obj.Properties().ToList();

                foreach (var prop in props)
                {
                    string newName = char.ToUpper(prop.Name[0]) + prop.Name.Substring(1);

                    if (newName != prop.Name)
                    {
                        JToken value = prop.Value;
                        prop.Replace(new JProperty(newName, value));
                        RenameKeys(value);
                    }
                    else
                    {
                        RenameKeys(prop.Value);
                    }
                }
            }
            else if (token is JArray array)
            {
                foreach (var item in array)
                {
                    RenameKeys(item);
                }
            }
        }

        //public static string ToUpperCamelCaseJson(string json)
        //{
        //    if (string.IsNullOrWhiteSpace(json))
        //        return json;

        //    var obj = JObject.Parse(json);
        //    var newObj = new JObject();

        //    foreach (var prop in obj.Properties())
        //    {
        //        string pascalName = char.ToUpper(prop.Name[0]) + prop.Name.Substring(1);
        //        newObj[pascalName] = prop.Value;
        //    }

        //    return newObj.ToString();
        //}

    }
}
