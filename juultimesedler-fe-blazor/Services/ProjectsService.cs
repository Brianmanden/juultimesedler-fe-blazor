using juultimesedler_fe_blazor.Shared.Models.DTOs;
using System.Net.Http.Json;

namespace juultimesedler_fe_blazor.Services
{
    public class ProjectsService
    {
        private const string _baseUri = "https://localhost:44352/api";
        private const string _projectsEndpoint = _baseUri + "/projects";
        private HttpClient _http;

        public ProjectsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<GetProjectDTO[]> GetProjects()
        {
            return await _http.GetFromJsonAsync<GetProjectDTO[]>(_projectsEndpoint);
        }
    }
}
