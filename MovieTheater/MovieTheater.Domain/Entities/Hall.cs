namespace MovieTheater.Domain.Entities;

public class Hall
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public virtual ICollection<Screening> Screenings { get; set; } = new List<Screening>();
}