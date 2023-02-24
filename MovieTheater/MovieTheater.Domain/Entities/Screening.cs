namespace MovieTheater.Domain.Entities;

public class Screening
{
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public decimal Price { get; set; }

    public virtual Movie Movie { get; set; }
    public Guid MovieId { get; set; }

    public virtual Hall Hall { get; set; }
    public Guid HallId { get; set; }
    
    public Guid? MovieLanguageId { get; set; }
    public virtual MovieLanguage? MovieLanguage { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; }
}