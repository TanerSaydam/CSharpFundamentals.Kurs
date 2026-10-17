using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//service registration

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddCors();

builder.Services.AddResponseCompression(x =>
{
    x.EnableForHttps = true;
});

var app = builder.Build();
//middleware

app.MapOpenApi();
app.MapScalarApiReference();

app.UseCors(x =>
{
    x.AllowAnyMethod();
    x.AllowAnyHeader();
    x.AllowAnyOrigin();
    x.SetPreflightMaxAge(TimeSpan.FromMinutes(10));

    //eğer özelleştirmek istersek
    //x.WithOrigins("http://127.0.0.1:5500"); // adres 
    //x.WithMethods("GET", "POST", "PUT", "DELETE"); // metot
    //x.WithHeaders("company_id"); // header

    //Eğer SignalR ile Canlı iletişim yaparsak
    //x.SetIsOriginAllowed(x => true);
    //x.AllowCredentials();
});

app.UseResponseCompression();

app.MapControllers();

app.Run();