using MediatR;

namespace ToDoList.Application.ToDoList.GetToDoList
{
    public sealed record GetToDoListQuery(Guid ToDoId) : IRequest<GetToDoListResponse>;
}
