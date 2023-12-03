// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace PlanetDotnet.Portal.Views.Bases
{
    public partial class LabelBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Color { get; set; }

        public void SetValue(string value)
        {
            this.Value = value;
            InvokeAsync(StateHasChanged);
        }

        public void SetColor(string color)
        {
            this.Color = color;
            InvokeAsync(StateHasChanged);
        }
    }
}
