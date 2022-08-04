using MvcExample.Infrastructure.Authentication;

namespace MvcExample.Infrastructure.Extensions
{
    internal static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder applicationBuilder, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
                return applicationBuilder;
            
            return applicationBuilder
                .UseExceptionHandler("/Home/Error")
                .UseHsts(); // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        }

        public static IApplicationBuilder UseEndpoints(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints
                    .MapDefaultControllerRoute()
                    .RequireAuthorization(PolicyDefaults.DefaultPolicyName);
            });

            return applicationBuilder;
        }
    }
}
