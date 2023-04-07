namespace Carental.Application.DTOs.Error
{
    public record Errors(string Title, ICollection<Error> Values) {
        public Errors(string Title) : this(Title, new List<Error>()) { }
    }
}
