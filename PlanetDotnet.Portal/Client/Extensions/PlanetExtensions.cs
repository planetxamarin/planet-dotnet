// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PlanetDotnet.Portal.Brokers.Apis;
using PlanetDotnet.Portal.Brokers.Loggings;
using PlanetDotnet.Portal.Services.Foundations.Authors;
using PlanetDotnet.Portal.Services.Views.AuthorViews;

namespace PlanetDotnet.Portal.Client.Extensions
{
    public static class PlanetExtensions
    {
        public static WebAssemblyHostBuilder ConfigurePlanetDotnet(
            this WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient());
            builder.Services.AddBrokers();
            builder.Services.AddFoundationServices();
            builder.Services.AddViewServices();

            return builder;
        }

        private static void AddBrokers(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddScoped<ILoggingBroker, LoggingBroker>();
            services.AddScoped<IApiBroker, ApiBroker>();
        }

        private static void AddFoundationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
        }

        private static void AddViewServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorViewService, AuthorViewService>();
        }
    }
}
