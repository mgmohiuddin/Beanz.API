using Beanz.WebAPI.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Beanz.WebAPI.Security
{
    
    public class BeanzAuthentication : IBeanzAuthentication
    {
        private  IOptions<ApiSecuritySettings> Config { get; }

        //IOptions<T> injection
        public BeanzAuthentication(IOptions<ApiSecuritySettings> config)
        { 
            Config = config;
        }
        public bool Authenticate(string username, string password)
        {
            //ApiSecurity  
            var BeanzApiUserName = Config.Value.ApiUserName;
            var BeanzApiPassword = Config.Value.ApiPassword;
            
            return username.Equals(BeanzApiUserName) && password.Equals(BeanzApiPassword);

            //return await Task.Run(() => (username.Equals(BeanzApiUserName) && password.Equals(BeanzApiPassword)));            
        }
        
    }
}
