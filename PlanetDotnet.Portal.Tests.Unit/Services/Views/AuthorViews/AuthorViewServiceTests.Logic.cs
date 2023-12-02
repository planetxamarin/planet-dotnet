// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using PlanetDotnet.Portal.Models.Authors;
using PlanetDotnet.Portal.Models.AuthorViews;
using Xunit;

namespace PlanetDotnet.Portal.Tests.Unit.Services.Views.AuthorViews
{
    public partial class AuthorViewServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllAuthorViewsAsync()
        {
            // given
            List<dynamic> dynamicAuthorViewPropertiesCollection =
                CreateRandomAuthorViewCollections();

            List<Author> randomAuthors =
                dynamicAuthorViewPropertiesCollection.Select(property =>
                    new Author
                    {
                        FirstName = property.DisplayName,
                        LastName = "",
                        StateOrRegion = property.Location,
                        ShortBioOrTagLine = property.ShortBioOrTagLine,
                        WebSite = property.WebSite,
                        TwitterHandle = property.TwitterHandle,
                        GravatarHash = ExtractHashFromGravatarUrl(property.GravatarUrl),
                        Position = property.Position,
                    }).ToList();

            List<Author> retrievedAuthors = randomAuthors;

            List<AuthorView> randomAuthorViews =
                dynamicAuthorViewPropertiesCollection.Select(property =>
                    new AuthorView
                    {
                        DisplayName = property.DisplayName,
                        GravatarUrl = property.GravatarUrl,
                        Location = property.Location,
                        Position = property.Position,
                        ShortBioOrTagLine = property.ShortBioOrTagLine,
                        WebSite = property.WebSite,
                        TwitterHandle = property.TwitterHandle
                    }).ToList();

            List<AuthorView> expectedAuthorViews = randomAuthorViews;

            this.authorServiceMock.Setup(service =>
                service.RetrieveAllAuthorsAsync())
                    .ReturnsAsync(retrievedAuthors);

            // when
            List<AuthorView> retrievedAuthorViews =
                await this.authorViewService.RetrieveAllAuthorViewsAsync();

            // then
            retrievedAuthorViews.Should().BeEquivalentTo(expectedAuthorViews);

            this.authorServiceMock.Verify(service =>
                service.RetrieveAllAuthorsAsync(),
                    Times.Once());

            this.authorServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
