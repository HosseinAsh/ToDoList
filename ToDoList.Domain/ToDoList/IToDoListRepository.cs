namespace ToDoList.Domain.ToDoList
{
    public interface IToDoListRepository
    {
        Task<ToDoList?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default);
        Task<IEnumerable<ToDoList>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Guid> Add(ToDoList entity);
        public Task Update(ToDoList entity);
        public Task Delete(ToDoList entity);
        public Task GeneratePDF(ToDoList entity);
    }
}
