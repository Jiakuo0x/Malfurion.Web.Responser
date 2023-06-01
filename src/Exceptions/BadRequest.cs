namespace Responser.Exceptions;

public class BadRequest : ResponseException
{
    public string? Code { get; } = null;
    public BadRequest(string message) : base(message)
    {
    }
    public BadRequest(string code, string message) : base(message)
    {
        Code = code;
    }
}