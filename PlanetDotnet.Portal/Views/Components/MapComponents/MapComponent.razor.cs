// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PlanetDotnet.Portal.Models.Views.AuthorViews;
using PlanetDotnet.Portal.Services.Views.MapViews;

namespace PlanetDotnet.Portal.Views.Components.MapComponents
{
    public partial class MapComponent : ComponentBase
    {
        [Inject]
        public IMapViewService MapViewService { get; set; }

        [Parameter]
        public IReadOnlyList<AuthorView> AuthorViews { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await this.MapViewService.LoadMapAsync(AuthorViews);
            }
        }
    }
}