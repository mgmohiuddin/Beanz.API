using System.Threading.Tasks;

namespace Beanz.API.Security
{
    public  interface IBeanzAuthentication
    {
         bool Authenticate(string username, string password); 
    }
}
