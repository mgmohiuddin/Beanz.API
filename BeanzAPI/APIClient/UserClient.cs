using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beanz.API.APIClient
{
    public partial class ApiClient
    {
        public string GetRequest(string url, string querystring)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, url), querystring);
            //return GetUrlData(requestUrl.ToString(), querystring);
            return Get(requestUrl);

        }
        public string PostRequest<T>(string url, T model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, url), "");
            return Post<T>(requestUrl, model);


        }
        //public async Task<string> GetRequest(string url)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, url));

        //    return await GetAsync(requestUrl);

        //}
        //public async Task<string> PostRequest<T>(string url, T model)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, url));
        //    return await PostAsync<T>(requestUrl, model);
        //}


    }
}
