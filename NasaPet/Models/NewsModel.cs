namespace NasaPet.Models;

public class NewsModel : BaseModel, IBaseModel
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public List<CategoriesModel>? Categories { get; set; } = new();
    public List<SourcesModel>? Sources { get; set; } = new();
    public List<GeometriesModel>? Geometries { get; set; } = new();
}

