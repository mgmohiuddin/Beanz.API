using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Filters
{
    public class ValidateIdAttribute : ServiceFilterAttribute
    {
        public ValidateIdAttribute() : base(typeof(ValidateIdAsyncActionFilter))
        {
        }
    }
}