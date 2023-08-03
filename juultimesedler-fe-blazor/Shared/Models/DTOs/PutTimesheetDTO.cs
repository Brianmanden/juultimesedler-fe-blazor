namespace juultimesedler_fe_blazor.Shared.Models.DTOs;

public class PutTimesheetDTO
{
    public int WorkerId { get; set; }
    public int WeekNumber { get; set; }
    public List<WorkDay>? Workdays { get; set; }
}