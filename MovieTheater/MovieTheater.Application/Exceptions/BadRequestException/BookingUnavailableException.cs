namespace MovieTheater.Application.Exceptions.BadRequestException;

public class BookingUnavailableException : BadRequestException
{
    public BookingUnavailableException(){}
    public BookingUnavailableException(string message) : base(message){}
}