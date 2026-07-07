
public static class StudentEndpoints
{
    public static void MapStudentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/student").WithTags("Students");
        group.MapGet("/{id}", GetById);
        group.MapPost("/new", Create);
    }

    private static async Task<IResult> GetById(int id, IStudentService service)
    {
        var result = await service.GetStudentByIdAsync(id);
        return result.ToHttpResult();
    }

    private static async Task<IResult> Create(
        CreateStudentRequest createStudentReq,
        IStudentService service)
    {
        var result = await service.CreateStudentAsync(createStudentReq);
        return result.ToHttpResult();
    }

}