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
        public long DueDate { get; private set; }
        public long? CompletedDate { get; private set; }
        public void ValidateInvariates()
        {
            if (CreatedDate is null)
                throw new Exception(ErrorMessages.EveryTaskShouldHaveCreateDate);

            if ((CurrentState != State.Done || CurrentState != State.Reject) && CompletedDate is null)
                throw new Exception(ErrorMessages.CompleteTaskShouldHaveDate);

            if (string.IsNullOrEmpty(Title))
                throw new Exception(ErrorMessages.EveryTaskShouldHaveTitle);

            if (string.IsNullOrEmpty(Description))
                throw new Exception(ErrorMessages.EveryTaskShouldHaveDescription);

            if (Description.Length < 2)
                throw new Exception(ErrorMessages.DescriptionShouldHaveMoreThan2Length);
        }

        public ToDoList(string description, string title, long dueDate)
        {
            Id = Guid.NewGuid();
            Description = description;
            Title = title;
            DueDate = dueDate;
        }
        public ToDoList(Guid id, string description, string title)
        {
            Id = id;
            Description = description;
            Title = title;
        }
        private ToDoList()
        {
            
        }
        public ToDoList CreateToDoList()
        {
            RaiseDomainEvent(new ToDoListCreatedDomainEvent(Id));

            CreatedDate = DateTime.UtcNow.Millisecond;
            CurrentState = State.New;
            return this;
        }
        public void RemovePosibility()
        {
            if (CurrentState == State.Done)
            {
                throw new Exception("we can not remove done tasks");
            }
        }
        public void ChangeState(State state)
        {
            if (CurrentState == State.Done || CurrentState == State.Reject)
                throw new Exception(ErrorMessages.CompletedTaskCanNotBeChange);

            CurrentState = state;
        }
        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new Exception(ErrorMessages.EveryTaskShouldHaveDescription);
            Description = description;
        }
        public void ChangeTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception(ErrorMessages.EveryTaskShouldHaveTitle);
            Title = title;
        }

    }
}
