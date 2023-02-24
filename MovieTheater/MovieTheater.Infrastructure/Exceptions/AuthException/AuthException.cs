namespace MovieTheater.Infrastructure.Exceptions.AuthException;

public class AuthException: Exception
{
    protected AuthException(string message):base(message){}
}