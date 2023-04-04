using Microsoft.AspNetCore.Identity;

namespace Carental.Infrastructure.Identity.Extensions
{
    public static class IdentityExtensions
    {
        public static void ToErrorDictionary(this IEnumerable<IdentityError> @this, out Dictionary<string, string[]> dictionary) 
        {
            dictionary = new Dictionary<string, string[]>();
            foreach (IGrouping<string, IdentityError> x in @this.GroupBy(x => x.Code).ToArray())
            {
                string[] values = x.Select(x => x.Description).ToArray();
                dictionary.Add(x.Key, values);
            }
        }
    }
}
