﻿// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Brokers.Loggings;
using PlanetDotnet.Portal.Models.Foundations.Authors;
using PlanetDotnet.Portal.Models.Views.AuthorViews;
using PlanetDotnet.Portal.Services.Foundations.Authors;

namespace PlanetDotnet.Portal.Services.Views.AuthorViews
{
    public partial class AuthorViewService : IAuthorViewService
    {
        private readonly IAuthorService authorService;
        private readonly ILoggingBroker loggingBroker;

        public AuthorViewService(
            IAuthorService authorService,
            ILoggingBroker loggingBroker)
        {
            this.authorService = authorService;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<List<AuthorView>> RetrieveAllAuthorViewsAsync() =>
        TryCatch(async () =>
        {
            List<Author> authors =
                await this.authorService.RetrieveAllAuthorsAsync();

            var random = new Random();

            return authors.Select(AsAuthorView)
                .OrderBy(r => random.Next())
                .ToList();
        });

        private static Func<Author, AuthorView> AsAuthorView =>
            author => new AuthorView
            {
                Id = author.GravatarHash,
                DisplayName = $"{author.FirstName} {author.LastName}".Trim(),
                Location = author.StateOrRegion,
                GravatarUrl = $"//www.gravatar.com/avatar/{author.GravatarHash}.jpg?s=200&d=mm",
                Position = author.Position,
                ShortBioOrTagLine = author.TagOrBio,
                TwitterHandle = author.TwitterHandle,
                WebSite = author.WebSite
            };
    }
}
