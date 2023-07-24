using juultimesedler_fe_blazor.Shared.Models.DTOs;
using System.Net.Http.Json;

namespace juultimesedler_fe_blazor.Shared;

public class ProjectService : IProjectInterface
{
    public async Task<IEnumerable<GetProjectDTO>> GetProjects(HttpClient httpClient, string uri)
    {
        return await httpClient.GetFromJsonAsync<List<GetProjectDTO>>(uri);
    }
}
