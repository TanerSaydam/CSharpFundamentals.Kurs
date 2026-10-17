using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationDbContext>(opt =>
//{
//    opt.UseSqlServer("");
//}); //AI tercihi ve best practices

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddResponseCompression(x => x.EnableForHttps = true);

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.UseCors(x => x
.AllowAnyHeader()
.AllowAnyOrigin()
.AllowAnyMethod()
.SetPreflightMaxAge(TimeSpan.FromMinutes(10))
);

app.UseResponseCompression();

app.MapGet("/hello", () =>
{
    return Results.Ok();
}); //Minimal API

app.MapControllers();

app.Run();