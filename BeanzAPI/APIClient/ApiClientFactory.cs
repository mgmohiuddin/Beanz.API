using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beanz.API.APIClient
{
    public static class ApiClientFactory
    {
        private static Uri apiURI;

        private static Lazy<ApiClient> apiClient = new Lazy<ApiClient>(() => new ApiClient(apiURI), LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
     
            apiURI = new Uri(Utilities.Configuration.InstaAPILink.ToString());
        }

        public static ApiClient Instance
        {
            get
            {
                return apiClient.Value;
            }
        }
    }
}
