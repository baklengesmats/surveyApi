using Microsoft.AspNetCore.Diagnostics;
using SurveyApi.Common.Exceptions;
using SurveyApi.Repositories;
using SurveyApi.Repositories.Mock;
using SurveyApi.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
         policy => policy.WithOrigins("http://localhost:3000")
                         .AllowAnyHeader()
                         .AllowAnyMethod());
});
builder.Services.AddSingleton<ISurveyRepository, MockSurveyRepository>();
builder.Services.AddSingleton<ISurveyResponseRepository, MockSurveyResponseRepository>();
builder.Services.AddScoped<ISurveyService, SurveyService>();
builder.Services.AddScoped<ISurveyResponseService, SurveyResponseService>();
builder.Services.AddScoped<ICompareBenchmarkService, CompareBenchmarkService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowReactApp");
app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.ContentType = "application/json";
        var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (exceptionFeature != null)
        {
            // If it's a custom HttpException, use its status code; otherwise, default to 500.
            int statusCode = exceptionFeature.Error is HttpException httpEx
                ? httpEx.StatusCode
                : StatusCodes.Status500InternalServerError;

            context.Response.StatusCode = statusCode;

            var errorResponse = new
            {
                StatusCode = statusCode,
                Message = exceptionFeature.Error.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    });
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
