// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Foundations.Previews;

namespace PlanetDotnet.Portal.Services.Foundations.Previews
{
    public interface IPreviewService
    {
        ValueTask<List<Preview>> RetrieveAllPreviewsAsync();
    }
}