using MediatR;
using ToDoList.Domain.ToDoList;

namespace ToDoList.Application.ToDoList.DeleteToDoList
{
    internal sealed class DeleteToDoListCommandHandler : IRequestHandler<DeleteToDoListCommand>
    {
        private readonly IToDoListRepository _todoRepository;

        public DeleteToDoListCommandHandler(IToDoListRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task Handle(DeleteToDoListCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetByIdAsync(Guid.Parse(request.ToDoId), cancellationToken);

            if (todo == null)
                throw new Exception("we do not find any todo list item");

            todo.RemovePosibility();

            await _todoRepository.Delete(todo);
        }
    }
}
