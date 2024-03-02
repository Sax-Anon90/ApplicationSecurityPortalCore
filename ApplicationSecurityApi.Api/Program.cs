using Serilog;
using ApplicationSecurity.Application;
using ApplicationSecurity.Infrustructure;
using ApplicationSecurity.Persistence;
using ApplicationSecurityApi.Api.Middleware;
using ApplicationSecurityApi.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logDirectory = builder.Configuration["LoggingConfig:LoggerPathConfig"];

builder.Host.UseSerilog((context, loggerConfig) =>
loggerConfig.ReadFrom.Configuration(context.Configuration)
.WriteTo.Console());
//.WriteTo.File(logDirectory, rollingInterval: RollingInterval.Day));

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo
    .Console().CreateLogger();

builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrustructureServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
});

builder.Services.AddApiVersioningConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwtBearerTokenSwaggerExtension();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
