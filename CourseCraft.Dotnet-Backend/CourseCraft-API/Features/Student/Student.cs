public class Student
{
    required public int Id { get; set; }
    required public string  FirstName { get; set; } 
    public  string?  MiddleName  { get; set; } 
    required public string LastName { get; set; }
    public string? LastName2 { get; set; }
    required public string Email { get; set; }
    required public DateTime BirthDate{ get; set; }
    public int LearningLevel { get; set; }
    public Interest[]? Interests { get; set; }
    public Note[]? Notes { get; set; }
}

public class Note
{
    public int Id { get; set; }
    public string? Text { get; set; }
}

public class Interest
{
    public int Id { get; set; }
    public string? Text { get; set; }
}