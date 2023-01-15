using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);
// services container

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddCors();
builder.Services.AddIdentityServices(builder.Configuration);

// middleware
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();


app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials()
.WithOrigins("https://localhost:4200"));
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();

