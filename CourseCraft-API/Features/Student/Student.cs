public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string LastName2 { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate{ get; set; }
    public int LearningLevel { get; set; }
    public Interest[] Interests { get; set; }
    public Note[] Notes { get; set; }
}

public class Note
{
    public int Id { get; set; }
    public string Text { get; set; }
}

public class Interest
{
    public int Id { get; set; }
    public string Text { get; set; }
}