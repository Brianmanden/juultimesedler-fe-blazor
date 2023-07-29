namespace juultimesedler_fe_blazor.Shared.Models.DTOs;

public class GetTimesheetDTO
{
    public int weekNumber { get; set; }
    public string[] weekDays { get; set; }
    public int[] weekDates { get; set; }
}