using Beanz.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beanz.Business.Helper
{
    public abstract  class BaseBusiness
    {
        /// <summary>
        /// Build a failed BeanzResponseObjectDTO&lt;T&gt; in one line.
        /// </summary>
        protected static BeanzResponseObjectDTO<T> Fail<T>(
            string message,
            string errorCode = "ERR-00",
            int statusCode = 400,
            object? errors = null)
        {
            return BeanzResponseObjectDTO<T>.Fail(message, errorCode, statusCode, errors);
        }

        /// <summary>
        /// Build a success BeanzResponseObjectDTO&lt;T&gt; in one line.
        /// </summary>
        protected static BeanzResponseObjectDTO<T> Ok<T>(
            T data,
            string message = "Success",
            int statusCode = 200)
        {
            return BeanzResponseObjectDTO<T>.Ok(data, message, statusCode);
        }

        /// <summary>
        /// Validate the ambient context (CompanyID, UserID, LanguageID) on a request.
        /// Returns null when valid, or a ready-to-return Fail response when invalid.
        /// </summary>
        protected static BeanzResponseObjectDTO<T>? ValidateContext<T>(BeanzRequestDTO common)
        {
            if (common == null)
                return Fail<T>("Request is required.", "ERR-REQ-01", 400);

            if (common.CompanyID <= 0)
                return Fail<T>("CompanyID is required.", "ERR-CTX-01", 400);

            if (common.UserID <= 0)
                return Fail<T>("UserID is required.", "ERR-CTX-02", 400);

            if (common.LanguageID <= 0)
                return Fail<T>("LanguageID is required.", "ERR-CTX-03", 400);

            return null; // valid
        }

        protected BeanzResponseObjectDTO<T>? ValidateDto<T, TDto>(TDto dto)
        {
            if (dto == null)
                return BeanzResponseObjectDTO<T>.Fail("Invalid request payload.", "ERR012", 400);

            var results = new List<ValidationResult>();
            var ctx = new ValidationContext(dto);
            if (!Validator.TryValidateObject(dto, ctx, results, validateAllProperties: true))
            {
                var firstError = results.FirstOrDefault()?.ErrorMessage ?? "Validation failed.";
                return BeanzResponseObjectDTO<T>.Fail(firstError, "ERR013", 400,
                    results.Select(r => r.ErrorMessage));
            }
            return null;
        }
    }
}
