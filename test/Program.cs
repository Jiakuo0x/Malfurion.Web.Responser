using Responser;
using Responser.Exceptions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseMalfurionException();

app.MapGet("/ok", () => Response.Ok(new { a = 1 }));
app.MapGet("/bad", () => Response.BadRequest("Bad Request"));
app.MapGet("/ex", () =>
{
    throw new NotImplementedException();
});
app.MapGet("/bad-ex", () =>
{
    throw new BadRequest("211", "Bad Request nananna");
});

app.Run();