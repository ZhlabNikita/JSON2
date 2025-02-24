using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

string[] descriptions = { "Реализовать сортировку пузырьком", "Создать функцию для вычисления факториала", "Разработать REST API сервис", "Написать алгоритм Дейкстры" };
string[] levels = { "Легкий", "Средний", "Сложный" };
string[] languages = { "C#", "Python", "JavaScript", "C++" };

app.MapGet("/task", () =>
{
    var random = new Random();
    var task = new
    {
        Description = descriptions[random.Next(descriptions.Length)],
        Difficulty = levels[random.Next(levels.Length)],
        Language = languages[random.Next(languages.Length)]
    };

    return Results.Json(task, new JsonSerializerOptions { WriteIndented = true });
});

app.Run();