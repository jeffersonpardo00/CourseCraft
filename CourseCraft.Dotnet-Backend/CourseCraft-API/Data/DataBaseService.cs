public class DataBaseService: IDataBaseService
{
    private IDataProvider _dataProvider;
    public DataBaseService(IDataProvider dataProvider)
    {
        _dataProvider = dataProvider;
    }
    public async Task<DBResult<string>> SaveLessonsPlan(LessonResponse[] lessonResponses)
    {
        var result = _dataProvider.SaveLessonsPlan(lessonResponses);


        return  DBResult<string>.Success("ok");
    }
}