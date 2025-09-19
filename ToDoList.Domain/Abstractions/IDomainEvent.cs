using MediatR;

namespace ToDoList.Domain.Abstractions
{
    public abstract record IDomainEvent : INotification
    {

    }
}
