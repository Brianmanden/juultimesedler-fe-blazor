using juultimesedler_fe_blazor.Shared.Models.DTOs;

namespace juultimesedler_fe_blazor.Shared;

public interface IProjectInterface
{
    Task<IEnumerable<GetProjectDTO>> GetProjects(HttpClient httpClient, string uri);
}
