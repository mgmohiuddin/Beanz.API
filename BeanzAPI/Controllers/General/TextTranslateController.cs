using System.Web;
using Beanz.DTOs.BeanzCommon;
using Beanz.DTOs.Common;

//using Beanz.DTOs.HumanResourceManagementSystem.Transactions.Objects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beanz.API.Controllers.General
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TextTranslateController : Controller
    {
        [HttpPost]
        public ActionResult<BeanzlookupDTO> Index( BeanzCommonDTO common)
        {
            try
            {
                TextTranslate _TextTranslate = new TextTranslate();
                _TextTranslate = JsonConvert.DeserializeObject<TextTranslate>(common.Json); 
                string translatedText = TranslateText(_TextTranslate);
                BeanzlookupDTO beanzlookupDTO = new BeanzlookupDTO();
                beanzlookupDTO.DisplayField = translatedText;
                return beanzlookupDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
            
           
        }

        class TextTranslate
        {
            public  string sl  { get; set; }
            public string tl { get; set; }
            public string q { get; set; }
        }
            static string TranslateText(TextTranslate _TextTranslate)
            {
            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={_TextTranslate.sl}&tl={_TextTranslate.tl}&dt=t&q={HttpUtility.UrlEncode(_TextTranslate.q)}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult(); // Synchronous call
                string result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult(); // Synchronous call
                return result.Split('"')[1]; // Extract translated text
            }
        }
    }
}
