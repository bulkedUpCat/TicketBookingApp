namespace MovieTheater.Infrastructure.Exceptions.AuthException;

public class InvalidCredentialsException: AuthException
{
    public InvalidCredentialsException(string message): base(message){}
}