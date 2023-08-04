using juultimesedler_fe_blazor;
using juultimesedler_fe_blazor.Services;
using juultimesedler_fe_blazor.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region App services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ProjectsService>();
builder.Services.AddScoped<TasksService>();
builder.Services.AddScoped<TimesheetsService>();
#endregion

builder.Services.AddScoped<IndexViewModel>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
