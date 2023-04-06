using Carental.Application.DTOs.Error;

namespace Carental.Application.Exceptions
{
    public class DetailException : Exception
    {
        public readonly Errors errors;

        public Errors Errors { get => errors; }

        public DetailException(string message, Errors errors) : base(message) => this.errors = errors;

    }
}
