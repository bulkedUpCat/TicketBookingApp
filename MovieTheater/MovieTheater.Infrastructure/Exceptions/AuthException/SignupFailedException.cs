namespace MovieTheater.Infrastructure.Exceptions.AuthException;

public class SignupFailedException: AuthException
{
    public SignupFailedException(string message) : base($"Couldn't sign you up. {message}"){}
}