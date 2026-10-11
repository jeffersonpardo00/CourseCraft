public class DataBaseService: IDataBaseService
{
    private IDataProvider _dataProvider;
    public DataBaseService(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }
    public async Task<string> SaveLessonsPlan(LessonResponse[] lessonResponses)
    {
        return await _dataProvider.SaveLessonsPlan(lessonResponses);
    }
}