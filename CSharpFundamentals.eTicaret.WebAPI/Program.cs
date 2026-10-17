var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ApplicationDbContext>(opt =>
//{
//    opt.UseSqlServer("");
//}); //AI tercihi ve best practices

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();