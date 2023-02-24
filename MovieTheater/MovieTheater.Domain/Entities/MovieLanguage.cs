namespace MovieTheater.Domain.Entities;

public class MovieLanguage
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<Movie> Movies { get; set; }
    public virtual ICollection<Screening> Screenings { get; set; }
}