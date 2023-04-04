using System.Text.Json;

namespace Carental.Application.Exceptions
{
    public class DetailException: Exception
    {
        public readonly IDictionary<string, string[]> _Errors;

        public IDictionary<string, string[]> Errors { get => _Errors; }

        public DetailException(string message): base(message) => _Errors = new Dictionary<string, string[]>();

        public DetailException(string message, IDictionary<string, string[]> errors): base(message)
        {
            _Errors = errors;
        }
    }
}
