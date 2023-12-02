// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using PlanetDotnet.Portal.Models.Views.AuthorViews;
using PlanetDotnet.Portal.Models.Views.MapMarkers;

namespace PlanetDotnet.Portal.Services.Views.MapViews
{
    public class MapViewService : IMapViewService
    {
        private readonly IJSRuntime jsRuntime;

        public MapViewService(IJSRuntime jsRuntime) =>
             this.jsRuntime = jsRuntime;

        public async ValueTask LoadMapAsync(IEnumerable<AuthorView> authors)
        {
            var markers = CreateMarkers(authors).ToList();

            await this.jsRuntime.InvokeVoidAsync("loadMap", markers);
        }

        private static IEnumerable<MapMarker> CreateMarkers(
            IEnumerable<AuthorView> authors)
        {
            if (authors == null)
                return new List<MapMarker>();

            List<MapMarker> markers = new();

            foreach (var member in authors)
            {
                markers.Add(new MapMarker
                {
                    Id = member.Id,
                    Lat = member.Position.Lat,
                    Lng = member.Position.Lon,
                    Name = member.DisplayName,
                    Gravatar = member.Id, // Id is the garavatar hash
                });
            }

            return markers;
        }
    }
}
