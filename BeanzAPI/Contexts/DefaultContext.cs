using Microsoft.EntityFrameworkCore; 

namespace Beanz.API.Contexts
{
    public class DefaultContext : DbContext
    {
 

        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
        {
        }
    }
}