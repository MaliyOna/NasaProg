namespace NasaPet.Models;

public class NewsRootModel : BaseModel
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Link { get; set; }
    public List<NewsModel> Events { get; set; } = [];
}
