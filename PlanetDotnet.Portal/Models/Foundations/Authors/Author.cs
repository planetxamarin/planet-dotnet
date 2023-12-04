// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using PlanetDotnet.Portal.Models.Foundations.GeoPositions;

namespace PlanetDotnet.Portal.Models.Foundations.Authors
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StateOrRegion { get; set; }
        public string EmailAddress { get; set; }
        public string TagOrBio { get; set; }
        public Uri WebSite { get; set; }
        public string TwitterHandle { get; set; }
        public string GitHubHandle { get; set; }
        public string GravatarHash { get; set; }
        public IEnumerable<Uri> FeedUris { get; set; }
        public GeoPosition Position { get; set; }
        public string LanguageCode { get; set; }
    }
}
