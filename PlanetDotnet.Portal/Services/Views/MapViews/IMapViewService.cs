﻿// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Views.AuthorViews;

namespace PlanetDotnet.Portal.Services.Views.MapViews
{
    public interface IMapViewService
    {
        ValueTask LoadMapAsync(IEnumerable<AuthorView> authors);
    }
}
