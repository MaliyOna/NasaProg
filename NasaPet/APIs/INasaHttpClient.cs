using NasaPet.Models;

namespace NasaPet.APIs;

public interface INasaHttpClient<T> where T : IBaseModel
{
    Task<T>? GetListAsync(string url, string urlParams);
}

