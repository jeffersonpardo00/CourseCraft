public interface IDataBaseService
{
    public Task<string> SaveLessonsPlan(LessonResponse[] lessonResponses);
}