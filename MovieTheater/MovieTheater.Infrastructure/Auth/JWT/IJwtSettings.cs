namespace MovieTheater.Infrastructure.Auth.JWT;

public interface IJwtSettings
{
    string Key { get; set; }
    string Issuer { get; set; }
    string Audience { get; set; }
}