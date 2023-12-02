// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using PlanetDotnet.Portal.Models.Foundations.GeoPositions;

namespace PlanetDotnet.Portal.Models.Views.AuthorViews
{
    public class AuthorView
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Location { get; set; }
        public string ShortBioOrTagLine { get; set; }
        public Uri WebSite { get; set; }
        public string TwitterHandle { get; set; }
        public string GravatarUrl { get; set; }
        public GeoPosition Position { get; set; }
    }
}
