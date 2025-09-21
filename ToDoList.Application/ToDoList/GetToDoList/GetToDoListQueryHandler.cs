using MediatR;
using ToDoList.Domain.ToDoList;

namespace ToDoList.Application.ToDoList.GetToDoList
{
    internal sealed class GetToDoListQueryHandler : IRequestHandler<GetToDoListQuery, GetToDoListResponse>
    {
        private readonly IToDoListRepository _toDoListRepository;

        public GetToDoListQueryHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<GetToDoListResponse> Handle(GetToDoListQuery request, CancellationToken cancellationToken)
        {
            var todo = await _toDoListRepository.GetByIdAsync(request.ToDoId);

            return new GetToDoListResponse().ToResponse(todo);

        }
    }
}
