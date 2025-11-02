namespace Squares.Application.Common.Exceptions;

public class InvalidSquareException : Exception
{
    public InvalidSquareException() { }

    public InvalidSquareException(string message) : base(message) { }

    public InvalidSquareException(
        string message,
        Exception innerException) : base(message, innerException) { }
}