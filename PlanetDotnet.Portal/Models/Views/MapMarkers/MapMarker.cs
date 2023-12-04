// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace PlanetDotnet.Portal.Models.Views.MapMarkers
{
    public class MapMarker
    {
        public string Id { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Name { get; set; }
        public string Gravatar { get; set; }
    }
}
