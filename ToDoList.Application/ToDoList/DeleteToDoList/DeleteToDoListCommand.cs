using MediatR;

namespace ToDoList.Application.ToDoList.DeleteToDoList
{
    public sealed record DeleteToDoListCommand(string ToDoId) : IRequest;
}
