using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Authentication.AddJwtBearer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Setup();

// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

public static class Extensions {
    public static WebApplication Setup(this WebApplication app) {
        app.MapGet("/", () => "Hello, World!");
        app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}")
            .RequireAuthorization();
        app.MapGet("/special-secret", () => "This is a special secret!")
            .RequireAuthorization(p => p.RequireClaim("scope", "myapi:secrets"));

        return app;
    }
}