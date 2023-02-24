namespace MovieTheater.Infrastructure.Auth.Models;

public class JwtResponse
{
    public string Token { get; set; }
    public DateTime ValidTo { get; set; }
}