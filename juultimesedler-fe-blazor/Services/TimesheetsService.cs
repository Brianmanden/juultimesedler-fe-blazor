using juultimesedler_fe_blazor.Shared.Models.DTOs;
using System.Net.Http.Json;

namespace juultimesedler_fe_blazor.Services;

public class TimesheetsService
{
    private HttpClient _http;
    private const string _baseUri = "https://localhost:44352/api";
    private const string _timesheetsEndpoint = _baseUri + "/gettimesheetweek";

    public TimesheetsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<GetTimesheetDTO> GetCurrentTimesheetWeek()
    {
        return await _http.GetFromJsonAsync<GetTimesheetDTO>(_timesheetsEndpoint);
    }
}
