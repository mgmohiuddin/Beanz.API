using Microsoft.AspNetCore.Mvc;

namespace Beanz.API.Filters
{
    public class ValidatePagingAttribute : ServiceFilterAttribute
    {
        public ValidatePagingAttribute() : base(typeof(ValidatePagingAsyncActionFilter))
        {
        }
    }
}
