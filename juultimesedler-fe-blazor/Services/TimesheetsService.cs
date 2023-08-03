using juultimesedler_fe_blazor.Shared.Models.DTOs;
using System.Net.Http.Json;

namespace juultimesedler_fe_blazor.Services;

public class TimesheetsService
{
    private HttpClient _http;
    private const string _baseUri = "https://localhost:44352/api";
    private const string _getTimesheetsEndpoint = _baseUri + "/gettimesheetweek";
    private const string _putTimesheetsEndpoint = _baseUri + "/puttimesheetweek";

    public TimesheetsService(HttpClient http)
    {
        _http = http;
    }

    public async Task<GetTimesheetDTO> GetCurrentTimesheetWeek()
    {
        return await _http.GetFromJsonAsync<GetTimesheetDTO>(_getTimesheetsEndpoint);
    }

    public async Task PutCurrentTimesheetWeek(PutTimesheetDTO timesheetCurrentWeek)
    {
        CancellationToken cancellationToken = CancellationToken.None;
        await _http.PutAsJsonAsync(_putTimesheetsEndpoint, timesheetCurrentWeek, cancellationToken);
    }
}