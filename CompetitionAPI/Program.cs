using CompetitionAPI.Data;
using CompetitionAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;



var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("Default")));


var app = builder.Build();

app.UseCors(x => x.AllowAnyMethod()
                .AllowAnyHeader()             
                .SetIsOriginAllowed(origin => true));




app.MapGet("/", async (ApplicationDbContext context) =>
{
        var result = await context.CompetitionResults.FirstOrDefaultAsync();

        return result;
});


app.MapPost("/", async (string value, ApplicationDbContext context) =>
{
    var entry = await context.CompetitionResults.FirstOrDefaultAsync();
    entry.Result = value;

    await context.SaveChangesAsync();
});


app.Run();


