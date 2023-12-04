// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Foundations.Authors;

namespace PlanetDotnet.Portal.Services.Foundations.Authors
{
    public interface IAuthorService
    {
        ValueTask<List<Author>> RetrieveAllAuthorsAsync();
    }
}