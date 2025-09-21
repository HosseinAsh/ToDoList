namespace ToDoList.Api.Controllers
{
    public sealed record AddToDoListRequest(string Title, string Description, double RemainDate);
}
