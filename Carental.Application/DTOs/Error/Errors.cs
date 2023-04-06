namespace Carental.Application.DTOs.Error
{
    public record Errors(ICollection<Error> Values) {
        public Errors() : this(new List<Error>()) { }
    }
}
