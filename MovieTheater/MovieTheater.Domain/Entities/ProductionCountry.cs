namespace MovieTheater.Domain.Entities;

public class ProductionCountry
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Rank { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }
}