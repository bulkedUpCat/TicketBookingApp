namespace MovieTheater.Infrastructure.Exceptions.AuthException;

public class PasswordsDontMatchException: AuthException
{
    public PasswordsDontMatchException(string password, string confirmPassword): 
        base($"Passwords {password} and {confirmPassword} don't match"){}
}