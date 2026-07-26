public class Session
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Subject { get; set; }
    public DateTime LastAdjustement { get; set; }  
    public required string Content { get; set; }
    public required int Status { get; set; }
}