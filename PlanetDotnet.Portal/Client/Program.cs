// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PlanetDotnet.Portal.Client.Extensions;

namespace PlanetDotnet.Portal
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.ConfigurePlanetDotnet();

            await builder.Build().RunAsync();
        }
    }
}