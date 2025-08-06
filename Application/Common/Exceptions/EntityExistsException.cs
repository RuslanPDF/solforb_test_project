using Domain.Entities;

namespace Application.Common.Exceptions;

public class EntityExistsException : Exception
{
    public EntityExistsException(string entityName)
        : base($"Entity {entityName} already exists in the system")
    {
    }

    public EntityExistsException(string entityName, string propName, object propValue)
        : base($"Entity {entityName} with \"{propName}\": \"{propValue}\" already exists in the system")
    {
    }
}