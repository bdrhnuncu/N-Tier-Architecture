using Autofac;
using Autofac.Extensions.DependencyInjection;
using Kirala.com.Business.BusinessServices;
using Kirala.com.Business.DependencyResolvers.Autofac;
using Kirala.com.Business.Utilities.JWT;
using Kirala.com.DataAccess.Configuration;
using Kirala.com.WebAPI.Extensions;
using Kirala.com.WebAPI.Services;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddBusinessService();//Business Layer Services

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerService();

builder.Services.AddAuthService(builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>());

builder.Services.AddCors(x => x.AddDefaultPolicy(x =>
{
    x.WithOrigins("http://localhost:61230", "https://localhost:7279", "http://localhost:5279")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));


Logger log = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.MSSqlServer(ConfigureConnString.ConnectionString, sinkOptions: new MSSqlServerSinkOptions
    {
        TableName = "ErrorLogs",
        AutoCreateSqlTable = true
    }, null, null, LogEventLevel.Error,
    null, columnOptions: null, null, null)
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddSingleton(Log.Logger);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule<AutofacBusinessModule>();
});

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionMiddleware();//Global Exception Handler(For API) 

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
