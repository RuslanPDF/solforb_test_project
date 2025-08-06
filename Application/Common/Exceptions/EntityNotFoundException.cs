namespace Application.Common.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName)
        : base($"Entity {entityName} was not found")
    {
    }

    public EntityNotFoundException(string entityName, string propName, object propValue)
        : base($"Entity {entityName} with \"{propName}\": \"{propValue}\" was not found")
    {
    }
}