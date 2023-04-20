namespace HRP.Application.Tools.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string entityName, object id) : base($"Entity {entityName} with Id = {id} is not found")
    {
    }
}