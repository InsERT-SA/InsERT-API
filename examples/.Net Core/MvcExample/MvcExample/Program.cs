using MvcExample.Infrastructure.Extensions;

var app = WebApplication.CreateBuilder(args)
    .AddMvc()
    .AddAuthentication()
    .AddAuthorization()
    .AddServices()
    .Build();

app
    .UseErrorHandler(app.Environment)
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAuthentication()
    .UseAuthorization()
    .UseEndpoints();

app.Run();