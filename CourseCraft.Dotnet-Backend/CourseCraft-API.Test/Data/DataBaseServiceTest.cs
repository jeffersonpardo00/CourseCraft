using System.Runtime.CompilerServices;

namespace CourseCraft_API.Test;
public class DataBaseServiceTest
{
    DataBaseService baseService = new DataBaseService(new MockDataProvider());

    [Fact]
    public async Task SaveLessonsPlan_ReturnsSuccess_WhenCorrectlySaved()
    {
        
    }

    [Fact]
    public async Task SaveLessonsPlan_ReturnsUnaviable_WhenTheDataBaseIsDown()
    {
        
    }

    [Fact]
    public async Task SaveLessonsPlan_ReturnsNullDataError_WhenSendingNullParams()
    {
        
    }

    [Fact]
    public async Task SaveLessonsPlan_ReturnsNullException_WhenSendingNullParams()
    {
        
    }

}

public class MockDataProvider : IDataProvider
{
    public Task<string> SaveLessonsPlan(LessonResponse[] lessonResponses)
    {
        throw new NotImplementedException();
    }
}