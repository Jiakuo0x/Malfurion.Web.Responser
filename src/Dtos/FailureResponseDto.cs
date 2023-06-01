namespace Responser.Dtos;

internal class FailureResponseDto : ResponseDto
{
    public FailureResponseDto(string message)
    {
        ErrorMessage = message;
    }
    public FailureResponseDto(string code, string message)
    {
        ErrorCode = code;
        ErrorMessage = message;
    }
    
    public string? ErrorCode { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}