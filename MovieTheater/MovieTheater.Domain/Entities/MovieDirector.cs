namespace MovieTheater.Domain.Entities;

public class MovieDirector
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int Rank { get; set; }
    
    public virtual ICollection<Movie> Movies { get; set; }
}