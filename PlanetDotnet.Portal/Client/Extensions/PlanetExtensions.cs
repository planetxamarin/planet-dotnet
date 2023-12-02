// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

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

            return builder;
        }
    }
}
