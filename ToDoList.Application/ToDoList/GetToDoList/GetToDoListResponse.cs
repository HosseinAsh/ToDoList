namespace ToDoList.Application.ToDoList.GetToDoList
{
    public sealed class GetToDoListResponse
    {
        public string Description { get; init; }
        public string Title { get; init; }
        public string CurrentState { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime CompletedDate { get; init; }
        public DateTime DueDate { get; init; }
        internal GetToDoListResponse ToResponse(Domain.ToDoList.ToDoList todo)
        {
            return new GetToDoListResponse
            {
                Title = todo.Title,
                Description = todo.Description,
                CurrentState = todo.CurrentState.ToString(),

                CompletedDate = todo.CompletedDate is null ? DateTime.MaxValue : new DateTime(todo.CompletedDate ?? 0, DateTimeKind.Utc).ToLocalTime(),

                CreatedDate = new DateTime(todo.CreatedDate ?? 0, DateTimeKind.Utc).ToLocalTime(),

                DueDate = new DateTime(todo.DueDate, DateTimeKind.Utc).ToLocalTime()
            };
        }

        internal IEnumerable<GetToDoListResponse> ToResponses(IEnumerable<Domain.ToDoList.ToDoList> todos)
        {
            List<GetToDoListResponse> responses = [.. todos.Select(t => ToResponse(t))];

            return responses;
        }
    }
}
