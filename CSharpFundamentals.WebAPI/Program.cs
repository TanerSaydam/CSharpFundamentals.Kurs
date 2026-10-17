var builder = WebApplication.CreateBuilder(args);
//service registration

builder.Services.AddControllers();

var app = builder.Build();
//middleware

app.MapControllers();

app.Run();