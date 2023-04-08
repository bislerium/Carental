using Carental.Application.Attributes;

namespace Carental.Application.Extensions
{
    internal static class EnumMemberMessageAttributeExtensions
    {
        public static string Message<T>(this T value) where T: Enum
        {
            var attribute = (EnumMemberMessageAttribute) typeof(Enums.AuthSignInResult)
                    .GetMember(value.ToString())[0]
                    .GetCustomAttributes(typeof(EnumMemberMessageAttribute), false)[0];

            return attribute.Message;
        }
    }
}
