namespace MovieTheater.Infrastructure.Exceptions.AuthException;

public class InvalidPasswordOrEmailException: AuthException
{
    public InvalidPasswordOrEmailException(string password) : base("Invalid password or email"){}
}