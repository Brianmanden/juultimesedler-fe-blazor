using juultimesedler_fe_blazor.Shared.Models.DTOs;

namespace juultimesedler_fe_blazor.ExtensionMethods;

public static class ProjectsExtensions
{
    public static List<string> GetProjectNames(this GetProjectDTO[]? projects)
    {
        return projects.Select(project => project.ProjectName).ToList();
    }
}
