// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Brokers.Apis;
using PlanetDotnet.Portal.Brokers.Loggings;
using PlanetDotnet.Portal.Models.Foundations.Previews;

namespace PlanetDotnet.Portal.Services.Foundations.Previews
{
    public partial class PreviewService : IPreviewService
    {
        private readonly IApiBroker apiBroker;
        private readonly ILoggingBroker loggingBroker;

        public PreviewService(
            IApiBroker apiBroker,
            ILoggingBroker loggingBroker)
        {
            this.apiBroker = apiBroker;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<Preview>> RetrieveAllPreviewsAsync() =>
            TryCatch(async () => await this.apiBroker.GetAllPreviewsAsync());
    }
}