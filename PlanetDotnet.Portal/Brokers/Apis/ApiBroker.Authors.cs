// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Authors;

namespace PlanetDotnet.Portal.Brokers.Apis
{
    public partial class ApiBroker
    {
        private const string AuthorsRelativeUrl = "api/authors";

        public async ValueTask<List<Author>> GetAllAuthorsAsync() =>
            await this.GetAsync<List<Author>>(AuthorsRelativeUrl);
    }
}