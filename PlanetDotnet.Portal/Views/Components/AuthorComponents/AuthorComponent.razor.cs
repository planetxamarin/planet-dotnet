// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using PlanetDotnet.Portal.Models.Views.AuthorViews;

namespace PlanetDotnet.Portal.Views.Components.AuthorComponents
{
    public partial class AuthorComponent : ComponentBase
    {
        [Parameter]
        public AuthorView Author { get; set; }
    }
}