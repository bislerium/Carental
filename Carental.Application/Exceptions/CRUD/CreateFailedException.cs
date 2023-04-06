using Carental.Application.DTOs.Error;
using System.Formats.Asn1;

namespace Carental.Application.Exceptions.CRUD
{
    public class CreateFailedException : DetailException
    {
        public CreateFailedException(Type classType, Errors errors): base($"{classType.Name} creation failed!", errors)
        {
        }
    }
}
