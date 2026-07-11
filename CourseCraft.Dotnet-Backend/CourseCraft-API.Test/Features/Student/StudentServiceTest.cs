namespace CourseCraft_API.Test;

public class StudentServiceTest
{

    StudentService studentService = new StudentService();

    [Fact]
    public async Task GetStudentByIdAsync_ReturnsSuccess_WhenStudentExists()
    {
        //Arrange
        var newStudent =
            new StudentResponse(
                "Molley",
                null,
                "Mol",
                null,
                "molie.mol@gmail.com",
                new DateTime(2016, 1, 1),
                2,
                ["drawing","basketball"],
                ["note1"]
            );

        //Act
        var result = await studentService.GetStudentByIdAsync(1);

        //Assert
          // Assert
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equivalent(newStudent, result.Value); 

    }

     [Fact]
    public async Task GetStudentByIdAsync_ReturnsNotFound_WhenStudentDoesNotExist()
    {

        // Act
        var result = await studentService.GetStudentByIdAsync(999);

        // Assert
        Assert.False(result.IsSuccess);
        Assert.Null(result.Value);
        Assert.NotNull(result.Error);
        Assert.Equal(ResultErrorType.NotFound, result.Error!.Type);
        Assert.Equal("Student not found.", result.Error.Message); 
    }

    [Fact]
    public async Task CreateStudentAsync_retrieves_correctInsertion()
    {
        //Arrange
         var newStudent = new CreateStudentRequest
        (
            "Jeferson", 
            "Andres",
            "Pardo",
            "Gomez",
            "jeferson.pardo@colegioVoluntario.org.co",
             new DateTime(2010, 5, 16),
            2,
            ["brain roots", "minecraft"],
            null
        );
        //Act
        var result = await studentService.CreateStudentAsync(newStudent);
        //Assert
        Assert.IsType<Result<StudentResponse>>(result);
        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value);
        Assert.Equal(newStudent.FirstName, result.Value.FirstName);
        Assert.Equal(newStudent.Email, result.Value.Email);
        Assert.Equal(newStudent.BirthDate, result.Value.BirthDate);
        Assert.Equal(newStudent.LearningLevel, result.Value.LearningLevel);   // xUnit's Assert.Equal on collections DOES do element-wise comparison
        Assert.Equal(newStudent.Interests, result.Value.Interests);   // xUnit's Assert.Equal on collections DOES do element-wise comparison
        Assert.Equal(newStudent.Notes, result.Value.Notes);
        
    }
}
