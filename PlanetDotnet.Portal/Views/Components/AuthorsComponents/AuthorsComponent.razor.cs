// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using PlanetDotnet.Portal.Models.Views.AuthorsComponentStates;
using PlanetDotnet.Portal.Models.Views.AuthorViews;
using PlanetDotnet.Portal.Services.Views.AuthorViews;
using PlanetDotnet.Portal.Views.Bases;

namespace PlanetDotnet.Portal.Views.Components.AuthorsComponents
{
    public partial class AuthorsComponent : ComponentBase
    {
        [Inject]
        public IAuthorViewService AuthorViewService { get; set; }

        public AuthorsComponentState State { get; set; }

        public List<AuthorView> AuthorViews { get; set; }

        public string ErrorMessage { get; set; }

        public LabelBase ErrorLabel { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                this.AuthorViews =
                    await this.AuthorViewService.RetrieveAllAuthorViewsAsync();

                this.State = AuthorsComponentState.Content;
            }
            catch (Exception exception)
            {
                this.ErrorMessage = exception.Message;
                this.State = AuthorsComponentState.Error;
            }
        }
    }
}