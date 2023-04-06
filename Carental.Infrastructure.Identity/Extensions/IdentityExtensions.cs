using Carental.Application.DTOs.Error;
using Microsoft.AspNetCore.Identity;

namespace Carental.Infrastructure.Identity.Extensions
{
    public static class IdentityExtensions
    {
        public static void ToErrors(this IEnumerable<IdentityError> @this, out Errors errors) 
        {
            errors = new Errors();

            foreach (IGrouping<string, IdentityError> x in @this.GroupBy(x => x.Code).ToArray())
            {
                
                string[] values = x.Select(x => x.Description).ToArray();
                Error err = new (x.Key, values);
                errors.Values.Add(err);
            }
        }
    }
}
