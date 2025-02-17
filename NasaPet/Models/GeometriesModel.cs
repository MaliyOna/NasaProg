namespace NasaPet.Models;

public class GeometriesModel
{
    public DateTime Date { get; set; }
    public string? Type { get; set; }
    public string[]? Coordinates { get; set; } = [];

    public string CoordinatesString => Coordinates == null
        ? string.Empty
        : string.Join(", ", Coordinates);
}
