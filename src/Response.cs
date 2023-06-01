namespace Responser;
using Dtos;
using Microsoft.AspNetCore.Http;

public static class Response
{
    public static IResult Ok() => Results.Ok<SuccessResponseDto>(new SuccessResponseDto());
    public static IResult Ok(object data) 
        => Results.Ok<SuccessResponseDto>(new SuccessResponseDto<object>(data));
    public static IResult Ok<T>(T data)
        => Results.Ok<SuccessResponseDto<T>>(new SuccessResponseDto<T>(data));

    public static IResult BadRequest(string message)
        => Results.BadRequest<FailureResponseDto>(new FailureResponseDto(message));

    public static IResult BadRequest(string code, string message)
        => Results.BadRequest<FailureResponseDto>(new FailureResponseDto(code, message));

    public static IResult Unauthorized()
        => Results.Unauthorized();
}