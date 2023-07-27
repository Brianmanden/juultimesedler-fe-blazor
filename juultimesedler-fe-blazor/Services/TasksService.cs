using juultimesedler_fe_blazor.Shared.Models.DTOs;
using System.Net.Http.Json;

namespace juultimesedler_fe_blazor.Services;

public class TasksService
{
    private HttpClient _http;
    private const string _baseUri = "https://localhost:44352/api";
    private const string _tasksEndpoint = _baseUri + "/tasks";

    public TasksService(HttpClient http)
    {
        _http = http;
    }

    public async Task<TasksGroupDTO[]> GetTasks()
    {
        return await _http.GetFromJsonAsync<TasksGroupDTO[]>(_tasksEndpoint);
    }

}
