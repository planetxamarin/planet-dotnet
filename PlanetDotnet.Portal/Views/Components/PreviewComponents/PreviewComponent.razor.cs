// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using PlanetDotnet.Portal.Models.Views.PreviewViews;

namespace PlanetDotnet.Portal.Views.Components.PreviewComponents
{
    public partial class PreviewComponent : ComponentBase
    {
        [Parameter]
        public PreviewView Preview { get; set; }
    }
}