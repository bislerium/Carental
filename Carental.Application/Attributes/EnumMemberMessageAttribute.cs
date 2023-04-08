using Carental.Application.Enums;
using System.Diagnostics;
using System.Reflection;

namespace Carental.Application.Attributes
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]       
    internal class EnumMemberMessageAttribute: Attribute
    {
        public string Message { get; }

        public EnumMemberMessageAttribute(string message)
        {
            Message = message;
        }
    }
}
