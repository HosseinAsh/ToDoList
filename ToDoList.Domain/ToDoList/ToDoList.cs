using ToDoList.Domain.Abstractions;
using ToDoList.Domain.ToDoList.Events;

namespace ToDoList.Domain.ToDoList
{
    public class ToDoList : Entity
    {
        public string Description { get; private set; }
        public string Title { get; private set; }
        public State CurrentState { get; private set; }
        public long? CreatedDate { get; private set; }
        public long? CompletedDate { get; private set; }
        public void ValidateInvariates()
        {
            if (CreatedDate is null)
                throw new Exception("why your task has not created date?!");

            if ((CurrentState != State.Done || CurrentState != State.Reject) && CompletedDate is null)
                throw new Exception("Completed task should have date");

            if (string.IsNullOrEmpty(Title))
                throw new Exception("title should not be null or empty");

            if (string.IsNullOrEmpty(Description))
                throw new Exception("descroption should not be null or empty");

            if (Description.Length < 2)
                throw new Exception("your description is too small");
        }
        public ToDoList(string description, string title, State currentState)
        {
            Id = Guid.NewGuid();
            Description = description;
            Title = title;
            CurrentState = currentState;
        }
        public ToDoList CreateToDoList(string description, string title, long? createdDate)
        {
            var todoList = new ToDoList(description, title, State.New);

            todoList.RaiseDomainEvent(new ToDoListCreatedDomainEvent(todoList.Id));

            CreatedDate = DateTime.UtcNow.Millisecond;

            return todoList;
        }
        public void ChangeState(State state)
        {
            if (CurrentState == State.Done || CurrentState == State.Reject)
                throw new Exception();

            CurrentState = state;
        }
        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception();
            Description = description;
        }
        public void ChangeTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception();
            Title = title;
        }

    }
}