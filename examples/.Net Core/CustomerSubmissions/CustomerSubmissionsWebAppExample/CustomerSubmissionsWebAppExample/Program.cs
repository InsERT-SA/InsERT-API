using CustomerSubmissionsWebAppExample.Client;
using CustomerSubmissionsWebAppExample.Components;
using CustomerSubmissionsWebAppExample.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddTransient<ICategoriesClient, CategoriesClient>()
    .AddTransient<IParametersClient, ParametersClient>()
    .AddTransient<ICustomerSubmissionClient, CustomerSubmissionClient>()
    .AddTransient<IAppSettings, AppSettings>()
    .AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient("customerSubmissionsApi", client => client.BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"]!));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
