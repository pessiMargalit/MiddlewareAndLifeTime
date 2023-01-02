using MiddleWares;
using ServiceLifetime;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<IOperationTransient,Operation>();

builder.Services.AddSingleton<IOperationSingleton, Operation>();

builder.Services.AddScoped<IOperationScoped, Operation>();

builder.Services.AddTransient<ICheckLifetime, Dependency>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.UseMiddleware();

app.Run();