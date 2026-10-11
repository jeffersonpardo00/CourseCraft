public interface IDataProvider
{
    public Task<string> SaveLessonsPlan(LessonResponse[] lessonResponses);
}