using ServiceOrdersExample;
using ServiceOrdersExample.Example;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddMvc()
    .AddRazorPagesOptions(options =>
    {
        // œcie¿ki do formularza i œledzenia zleceñ serwisowych musz¹ zostaæ utworzone zgodnie z konwencj¹:
        // adresPodstawowy/formularz - link do formularza
        // adresPodstawowy/{idZg³oszeniaSerwisowego} - link do œledzenia zleceñ
        options.Conventions.AddPageRoute("/ServiceOrdersPages/Formularz", "zgloszeniaSerwisowe/formularz");
        options.Conventions.AddPageRoute("/ServiceOrdersPages/HistoriaZgloszenia", "zgloszeniaSerwisowe/{urlIdZgloszenia}");

    });

builder.Services.AddSingleton<IAppSettings, AppSettings>();
builder.Services.AddSingleton<ServiceOrdersAPIClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseExceptionHandler("/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
