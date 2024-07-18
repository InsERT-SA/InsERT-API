using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using MvcExample.Application.Options;
using MvcExample.Application.Services.InsertApiToken;
using MvcExample.Application.Services.Subiekt123;
using MvcExample.Infrastructure.Authentication;
using MvcExample.Infrastructure.Authorization;
using MvcExample.Infrastructure.Options;
using MvcExample.Infrastructure.Services.Subiekt123;
using System.IdentityModel.Tokens.Jwt;

namespace MvcExample.Infrastructure.Extensions
{
    internal static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            var insertApiOptions = builder.Configuration.GetSection(nameof(InsertApiOptions)).Get<InsertApiOptions>()
                ?? throw new InvalidOperationException($"No {nameof(InsertApiOptions)}");

            builder.Services
                .AddHttpClient()
                .AddSingleton<CustomCookieAuthEvents>()
                .AddSingleton(insertApiOptions)
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie(options =>
                {
                    options.EventsType = typeof(CustomCookieAuthEvents);
                })
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.Authority = insertApiOptions.Authority;
                    options.ClientId = insertApiOptions.ClientId;
                    options.ClientSecret = insertApiOptions.ClientSecret;
                    options.ClaimsIssuer = insertApiOptions.Issuer;
                    options.ResponseType = insertApiOptions.ResponseType;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.SaveTokens = true;

                    options.Scope.Clear();

                    foreach (var scope in insertApiOptions.Scopes)
                        options.Scope.Add(scope);
                });

            return builder;
        }

        public static WebApplicationBuilder AddAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddAuthorizationBuilder()
                .AddPolicy(PolicyDefaults.DefaultPolicyName, policy =>
                {
                    policy
                        .RequireAuthenticatedUser();
                });

            return builder;
        }

        public static WebApplicationBuilder AddMvc(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddControllersWithViews();

            return builder;
        }

        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            var subiekt123ApiOptions = builder.Configuration.GetSection(nameof(Subiekt123ApiOptions)).Get<Subiekt123ApiOptions>()
                ?? throw new InvalidOperationException($"No {nameof(InsertApiOptions)}");

            builder.Services
                .AddSingleton(subiekt123ApiOptions)
                .AddHttpContextAccessor()
                .AddTransient<IInsertApiTokenService, InsertApiTokenService>()
                .AddHttpClient<ISubiekt123Service, Subiekt123Service>(client =>
                {
                    client.BaseAddress = new Uri(subiekt123ApiOptions.Url);
                });

            return builder;
        }
    }
}