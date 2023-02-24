namespace MovieTheater.Application.Shared.MovieDirector;

public class MovieDirectorModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public int Rank { get; set; }
}