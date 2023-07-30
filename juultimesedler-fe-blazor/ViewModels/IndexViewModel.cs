using juultimesedler_fe_blazor.Models;
using juultimesedler_fe_blazor.Services;
using juultimesedler_fe_blazor.Shared.Models.DTOs;

namespace juultimesedler_fe_blazor.ViewModels;

public class IndexViewModel
{
    private ProjectsService _projectsService;
    private TasksService _tasksService;
    private TimesheetsService _timesheetsService;

    public GetProjectDTO[]? Projects;
    public GetProjectDTO SelectedProject { get; set; }
    public TasksGroupDTO[]? GroupedTasks;
    public HashSet<string> SelectedTasks { get; set; }

    public string? TasksSearchText { get; set; }
    public GetTimesheetDTO Timesheet { get; set; }
    public TimeSpan? StartingTime { get; set; } = new TimeSpan(02, 35, 00);
    public TimeSpan? EndingTime { get; set; } = new TimeSpan(02, 35, 00);

    public IndexViewModel(ProjectsService projectService, TasksService tasksService, TimesheetsService timesheetsService)
    {
        _projectsService = projectService;
        _tasksService = tasksService;
        _timesheetsService = timesheetsService;
    }

    public void SetPredefinedMinutes(TimeType whichTime, int minutes)
    {
        if (whichTime == TimeType.EndingTime)
        {
            EndingTime = TimeSpan.Parse(EndingTime!.Value.Hours + ":" + minutes + ":00");
        }
        else
        {
            StartingTime = TimeSpan.Parse(StartingTime!.Value.Hours + ":" + minutes + ":00");
        }
        Console.WriteLine(EndingTime);
    }

    public async Task ClearProject() { SelectedProject = null; }

    public async Task<IEnumerable<GetProjectDTO>> ChooseProject(string project)
    {
        if (string.IsNullOrEmpty(project))
        {
            return Projects;
        }
        return Projects.Where(p => p.ProjectName.Contains(project, StringComparison.InvariantCultureIgnoreCase));
    }

    public async Task Initialize()
    {
        Projects = await _projectsService.GetProjects();
        GroupedTasks = await _tasksService.GetTasks();
        Timesheet = await _timesheetsService.GetCurrentTimesheetWeek();
    }

    //TODO BJA Create method to send form to BE
}
