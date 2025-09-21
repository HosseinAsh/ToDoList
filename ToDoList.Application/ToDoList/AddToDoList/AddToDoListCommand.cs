using MediatR;

namespace ToDoList.Application.ToDoList.AddToDoList
{
    public record AddToDoListCommand(string Title, string Description, DateTime DueDate) : IRequest<Guid>;
}
