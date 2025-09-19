namespace ToDoList.Domain.Abstractions
{
    public static class ErrorMessages
    {

        public static string EveryTaskShouldHaveCreateDate = "why your task has not created date?!";
        public static string CompleteTaskShouldHaveDate = "Completed task should have date";
        public static string EveryTaskShouldHaveTitle = "title should not be null or empty";
        public static string EveryTaskShouldHaveDescription = "descroption should not be null or empty";
        public static string DescriptionShouldHaveMoreThan2Length = "your description is too small";
        public static string CompletedTaskCanNotBeChange = "we can not chnage state of done or rejected task";

    }
}
