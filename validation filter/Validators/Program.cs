using Microsoft.AspNetCore.Mvc;
using Validators.Model;
using Validators.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IValidator<Review>,ReviewValidator>();
builder.Services.AddTransient<IEndpointFilter, ValidationFilter<Review>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapPost("/review", ([FromBody] Review review) =>
{
    return Results.Ok();
})
.WithName("CreateReview")
.WithOpenApi()
.AddEndpointFilter<ValidationFilter<Review>>();

app.Run();
