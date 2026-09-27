var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddHttpClient<IChatAIService, GeminiService>();
var app = builder.Build();

app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapStudentsEndpoints();
app.MapLessonEndpoints();
app.MapChatAIEndpoints();

app.Run();
