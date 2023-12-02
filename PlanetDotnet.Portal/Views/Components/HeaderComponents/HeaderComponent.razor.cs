// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace PlanetDotnet.Portal.Views.Components.HeaderComponents
{
    public partial class HeaderComponent : ComponentBase
    {
        private bool isMenuVisible = false;

        private void ToggleMenu()
        {
            isMenuVisible = !isMenuVisible;
        }
    }
}