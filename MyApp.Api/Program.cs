
using MyApp.Api.dtos;
var builder = WebApplication.CreateBuilder(args);


//BASIC MINIMAL API TEMPLATE
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/

//DTOS EXAMPLE MINIMAL API -GET
 /* List<AppDto> apps = [
    new (1, "App One", "Productivity", 9.99m, new DateOnly(2023, 1, 15)),
    new (2, "App Two", "Games", 4.99m, new DateOnly(2022, 11, 30)),
    new (3, "App Three", "Education", 14.99m, new DateOnly(2023, 3, 10))];

    app.MapGet("/apps",() => apps); //Minimal API

    app.MapGet("/appa/{id}", (int id) => apps.Find(a => a.Id == id) ); //Minimal API with parameter*/

//DTOS EXAMPLE MINIMAL API -POST
 List<AppDto> apps = [
    new (1, "App One", "Productivity", 9.99m, new DateOnly(2023, 1, 15)),
    new (2, "App Two", "Games", 4.99m, new DateOnly(2022, 11, 30)),
    new (3, "App Three", "Education", 14.99m, new DateOnly(2023, 3, 10))];

    app.MapGet("/apps",() => apps); //Minimal API

    app.MapGet("/appa/{id}", (int id) => apps.Find(a => a.Id == id) ); //Minimal API with parameter

    app.MapPost("/apps", (CreateDto createDto) => {
        var newApp = new AppDto(
            apps.Count + 1,
            createDto.Name,
            createDto.Genre,
            createDto.Price,
            createDto.ReleaseDate
        );
        apps.Add(newApp);
        return Results.Created($"/appa/{newApp.Id}", newApp);
    });

//DTOS EXAMPLE MINIMAL API -UPDATE
app.MapPut("/apps/{id}", (UpdateDto updateDto) => {
    var existingApp = apps.Find(a => a.Id == updateDto.Id);
    if (existingApp is null)
    {
        return Results.NotFound();
    }

    var updatedApp = new AppDto(
        updateDto.Id,
        updateDto.Name,
        updateDto.Genre,
        updateDto.Price,
        updateDto.ReleaseDate
    );

    apps.Remove(existingApp);
    apps.Add(updatedApp);

    return Results.Ok(updatedApp);
});

//DTOS EXAMPLE MINIMAL API -DELETE
app.MapDelete("/apps/{id}", (int id) => {
    apps.RemoveAll(a => a.Id == id);
    return Results.NoContent();
});

app.Run();