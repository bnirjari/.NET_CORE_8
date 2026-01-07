namespace MyApp.Api.dtos;

public  record class UpdateDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate);