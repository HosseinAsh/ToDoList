using MediatR;
using ToDoList.Domain.ToDoList;

namespace ToDoList.Application.ToDoList.AddToDoList
{
    internal sealed class AddToDoListCommandHandler : IRequestHandler<AddToDoListCommand, Guid>
    {
        private readonly IToDoListRepository _toDoListRepository;

        public AddToDoListCommandHandler(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        public async Task<Guid> Handle(AddToDoListCommand request, CancellationToken cancellationToken)
        {
            var todo = new Domain.ToDoList.ToDoList(request.Description, request.Title, request.DueDate.Ticks).CreateToDoList();

            return await _toDoListRepository.Add(todo);
        }
    }
}
