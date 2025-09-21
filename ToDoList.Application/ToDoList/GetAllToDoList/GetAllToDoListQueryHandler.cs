using MediatR;
using ToDoList.Application.ToDoList.GetToDoList;
using ToDoList.Domain.ToDoList;

namespace ToDoList.Application.ToDoList.GetAllToDoList
{
    internal sealed class GetAllToDoListQueryHandler : IRequestHandler<GetAllToDoListQuery, IEnumerable<GetToDoListResponse>>
    {
        private readonly IToDoListRepository _todoRepository;

        public GetAllToDoListQueryHandler(IToDoListRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<GetToDoListResponse>> Handle(GetAllToDoListQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoRepository.GetAllAsync(cancellationToken);

            return new GetToDoListResponse().ToResponses(todos);

        }
    }
}
