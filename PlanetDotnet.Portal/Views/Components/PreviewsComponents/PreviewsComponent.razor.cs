// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PlanetDotnet.Portal.Models.Views.PreviewsComponentStates;
using PlanetDotnet.Portal.Models.Views.PreviewViews;
using PlanetDotnet.Portal.Services.Views.PreivewViews;
using PlanetDotnet.Portal.Views.Bases;

namespace PlanetDotnet.Portal.Views.Components.PreviewsComponents
{
    public partial class PreviewsComponent : ComponentBase
    {
        [Inject]
        public IPreviewViewService PreviewViewService { get; set; }

        public PreviewsComponentState State { get; set; }

        public List<PreviewView> PreviewViews { get; set; }

        public string ErrorMessage { get; set; }
        public LabelBase ErrorLabel { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                this.PreviewViews =
                    await this.PreviewViewService.RetrieveAllPreviewViewsAsync();

                this.State = PreviewsComponentState.Content;
            }
            catch (Exception exception)
            {
                this.ErrorMessage = exception.Message;
                this.State = PreviewsComponentState.Error;
            }
        }
    }
}