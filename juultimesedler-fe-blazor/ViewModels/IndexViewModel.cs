﻿using juultimesedler_fe_blazor.Services;
using juultimesedler_fe_blazor.Shared.Models;
using juultimesedler_fe_blazor.Shared.Models.DTOs;
using System.Reflection.Metadata;

namespace juultimesedler_fe_blazor.ViewModels;

public class IndexViewModel
{
    private UserService _userService;
    private ProjectsService _projectsService;
    private TasksService _tasksService;
    private TimesheetsService _timesheetsService;

    public bool IsLoading { get; set; }

    public User User { get; set; }

    public GetProjectDTO[]? Projects;
    public GetProjectDTO SelectedProject { get; set; }
    public TasksGroupDTO[]? GroupedTasks;
    public HashSet<string> SelectedTasks { get; set; }
    public string? Comments { get; set; }

    public string? TasksSearchText { get; set; }
    public GetTimesheetDTO Timesheet { get; set; }
    public TimeSpan? StartingTime { get; set; } // = new TimeSpan(02, 35, 00);
    public TimeSpan? EndingTime { get; set; } // = new TimeSpan(02, 35, 00);

    public IndexViewModel(UserService userService, ProjectsService projectService, TasksService tasksService, TimesheetsService timesheetsService)
    {
        _userService = userService;
        _projectsService = projectService;
        _tasksService = tasksService;
        _timesheetsService = timesheetsService;
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

    public async Task SendForm()
    {
        PutTimesheetDTO currentWeekTimesheet = new PutTimesheetDTO();
        currentWeekTimesheet.WorkerId = User.UserId;
        currentWeekTimesheet.WeekNumber = Timesheet.weekNumber;
        List<WorkDay> workDays = new List<WorkDay>
        {
            new WorkDay
            {
                SelectedProjectId = SelectedProject?.ProjectId ?? null,
                StartTime = StartingTime.ToString() ?? string.Empty,
                EndTime = EndingTime.ToString() ?? string.Empty,
                WorkdayComments = Comments,
                SelectedTasks = SelectedTasks,
                WeekDay = 0,
            },
            new WorkDay
            {
                SelectedProjectId = SelectedProject?.ProjectId ?? null,
                StartTime = StartingTime.ToString() ?? string.Empty,
                EndTime = EndingTime.ToString() ?? string.Empty,
                WorkdayComments = Comments,
                SelectedTasks = SelectedTasks,
                WeekDay = 1,
            },
        };
        currentWeekTimesheet.Workdays = workDays;

        await _timesheetsService.PutCurrentTimesheetWeek(currentWeekTimesheet);
    }

    public string FormattedWeekDate(int i)
    {
        string shortFormattedWeekdate = $"{Timesheet.weekDays[i].Substring(0, 3)}-{Timesheet.weekDates[i]}.";
        string fullFormattedWeekdate = $"{Timesheet.weekDays[i]} - {Timesheet.weekDates[i]}";

        return shortFormattedWeekdate;
        //return fullFormattedWeekdate;
    }

    public async Task Initialize()
    {
        User = await _userService.GetUser();
        Projects = await _projectsService.GetProjects();
        GroupedTasks = await _tasksService.GetTasks();
        Timesheet = await _timesheetsService.GetCurrentTimesheetWeek();
    }

}