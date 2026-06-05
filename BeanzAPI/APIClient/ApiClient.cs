using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.API.APIClient
{
    public partial class ApiClient
    {

        private readonly HttpClient _httpClient;
        HttpClient client = new HttpClient();
        HttpClient Downlodclient = new HttpClient();
        private Uri BaseEndpoint { get; set; }

        public ApiClient(Uri baseEndpoint)
        {
            if (baseEndpoint == null)
            {
                throw new ArgumentNullException("baseEndpoint");
            }
            BaseEndpoint = baseEndpoint;
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        /// <summary>  
        /// Common method for making GET calls  
        /// </summary>  

        private string GetUrlData(string requestUrl, string urlParameters)
        {
            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(requestUrl);
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("").Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
                var getresponse = "";
                if (response.IsSuccessStatusCode)
                {
                    var readresult = response.Content.ReadAsStringAsync();
                    readresult.Wait();
                    getresponse = readresult.Result;
                    //// Parse the response body.
                    //var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                    //foreach (var d in dataObjects)
                    //{
                    //    Console.WriteLine("{0}", d.Name);
                    //}
                }
                else
                {
                    getresponse = response.StatusCode + " " + response.ReasonPhrase.ToString();
                }
                client.Dispose();
                //addHeaders();
                //var response = _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                //response.Wait();
                //var getresponse = "API Response Intiated";

                //var result = response.Result;
                //if (result.IsSuccessStatusCode)
                //{
                //    var readresult = result.Content.ReadAsStringAsync();
                //    readresult.Wait();
                //    getresponse = readresult.Result;

                //}
                //else
                //{
                //    getresponse = "API Response Failure";
                //}
                return getresponse;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }
        private string Get(Uri requestUrl)
        {
            try
            {


                addHeaders();
                var response = _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
                response.Wait();
                var getresponse = "API Response Intiated";

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readresult = result.Content.ReadAsStringAsync();
                    readresult.Wait();
                    getresponse = readresult.Result;

                }
                else
                {
                    getresponse = "API Response Failure";
                }
                return getresponse;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        private string Post<T>(Uri requestUrl, T content)
        {
            try
            {
                var postresponse = "API Response Intiated";
                addHeaders();
                var response = _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
                response.Wait();


                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readresult = result.Content.ReadAsStringAsync();
                    readresult.Wait();
                    postresponse = readresult.Result;
                }
                else
                {
                    postresponse = "API Response Failure";
                }
                return postresponse;
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        private Uri CreateRequestUri(string relativePath, string queryString)
        {
            var endpoint = new Uri(BaseEndpoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);
            if (uriBuilder.Query == "")
            {
                uriBuilder.Query = queryString;
            }
            else
            {
                uriBuilder.Query = queryString + uriBuilder.Query.Replace("?", "&");
            }
            //else
            //{
            //    queryString = uriBuilder.Query;
            //}
            //uriBuilder.Query = queryString;

            return uriBuilder.Uri;
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, Formatting.Indented, FormatSettings);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings FormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                };
            }
        }

        private void addHeaders()
        {
            //_httpClient.DefaultRequestHeaders.Remove("userIP");
            //_httpClient.DefaultRequestHeaders.Add("userIP", "192.168.1.1");

            //// Specify the authentication header
            //// ToBase64String method encodes a string to Base64b
            //string ApiUserName = "BeanzApiUserName";
            //string ApiPassword = "BeanzApiPassword";
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            //    "Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{ApiUserName}:{ApiPassword}")));

            


            string insta_auth = Utilities.Configuration.XInstaAuth;

            _httpClient.DefaultRequestHeaders.Remove("X-insta-auth");
            _httpClient.DefaultRequestHeaders.Add("X-insta-auth", insta_auth);

            _httpClient.DefaultRequestHeaders.Remove("request_handler_key");
            _httpClient.DefaultRequestHeaders.Add("request_handler_key", Utilities.Configuration.request_handler_key);

        }
    }
}
