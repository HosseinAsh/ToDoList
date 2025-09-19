using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.ToDoList.Events
{
    public sealed record ToDoListCreatedDomainEvent(Guid ToDoListId) : IDomainEvent;
    {
    }
}
