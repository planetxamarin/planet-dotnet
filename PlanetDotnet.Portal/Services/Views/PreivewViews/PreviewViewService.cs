// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Brokers.Loggings;
using PlanetDotnet.Portal.Models.Foundations.Previews;
using PlanetDotnet.Portal.Models.Views.PreviewViews;
using PlanetDotnet.Portal.Services.Foundations.Previews;

namespace PlanetDotnet.Portal.Services.Views.PreivewViews
{
    public partial class PreviewViewService : IPreviewViewService
    {
        private readonly IPreviewService previewService;
        private readonly ILoggingBroker loggingBroker;

        public PreviewViewService(
            IPreviewService previewService,
            ILoggingBroker loggingBroker)
        {
            this.previewService = previewService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<PreviewView>> RetrieveAllPreviewViewsAsync() =>
        TryCatch(async () =>
        {
            List<Preview> previews =
                await this.previewService.RetrieveAllPreviewsAsync();

            var random = new Random();

            return previews.Select(AsPreviewView)
                .OrderBy(r => random.Next())
                .ToList();
        });

        private static Func<Preview, PreviewView> AsPreviewView =>
            preview => new PreviewView
            {
                AuthorName = preview.AuthorName,
                Body = preview.Body,
                Gravatar = preview.Gravatar,
                Link = preview.Link,
                PublishDate = preview.PublishDate,
                Title = preview.Title
            };
    }
}
