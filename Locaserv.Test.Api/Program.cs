using Locaserv.Test.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

Environment.SetEnvironmentVariable("API_KEY", builder.Configuration.GetValue<string>("ApiKey"));

services.SetSecurity();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();