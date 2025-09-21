using MediatR;
using ToDoList.Application.ToDoList.GetToDoList;

namespace ToDoList.Application.ToDoList.GetAllToDoList
{
    public sealed record GetAllToDoListQuery : IRequest<IEnumerable<GetToDoListResponse>>
    {
    }
}
