namespace Carental.Application.Exceptions.CRUD
{
    public class CreateFailedException<TClass> : DetailException where TClass : class
    {

        public CreateFailedException(IDictionary<string, string[]> errors) : this()
        {
        }

        public CreateFailedException() : base($"{typeof(TClass).Name} creation failed!")
        {
        }
    }
}
