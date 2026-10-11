public interface IDataBaseService
{
    public Task<DBResult<string>> SaveLessonsPlan(LessonResponse[] lessonResponses);
}