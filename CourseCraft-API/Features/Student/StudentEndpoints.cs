using Microsoft.AspNetCore.Http.HttpResults;

public static class StudentEndpoints
{
    public static void MapStudentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/student").WithTags("Students");
        group.MapGet("/{id}", GetById);
    }

    private static async Task<IResult> GetById(int id, IStudentService service)
    {
        var result = await service.GetStudentByIdAsync(id);
        return result.ToHttpResult();
    }

}