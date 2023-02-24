namespace MovieTheater.Domain.Entities;

public class MovieImage
{
    public Guid Id { get; set; }
    public string Path { get; set; }
    
    public Guid MovieId { get; set; }
    public virtual Movie Movie { get; set; }
}