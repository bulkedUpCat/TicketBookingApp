namespace MovieTheater.Infrastructure.Exceptions.AuthException;

public class UserWithGivenEmailWasNotFoundException: AuthException
{
    public UserWithGivenEmailWasNotFoundException(string email) :
        base($"User with email {email} was not found"){}
}