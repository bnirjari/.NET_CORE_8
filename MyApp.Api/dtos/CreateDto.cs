namespace MyApp.Api.dtos;

public record class CreateDto(
    string Name, string Genre, decimal Price, DateOnly ReleaseDate);
