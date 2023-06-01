namespace Responser.Exceptions;

public class Unauthorized : ResponseException
{
    public Unauthorized(string message) : base(message)
    {
    }
}