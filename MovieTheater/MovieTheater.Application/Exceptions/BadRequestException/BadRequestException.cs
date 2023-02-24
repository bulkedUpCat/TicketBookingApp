namespace MovieTheater.Application.Exceptions.BadRequestException;

public class BadRequestException: Exception
{
    protected BadRequestException(){}
    protected BadRequestException(string message) : base(message){}
}