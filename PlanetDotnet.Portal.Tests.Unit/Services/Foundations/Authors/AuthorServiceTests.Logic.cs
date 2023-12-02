// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Force.DeepCloner;
using Moq;
using PlanetDotnet.Portal.Models.Authors;
using Xunit;

namespace PlanetDotnet.Portal.Tests.Unit.Services.Foundations.Authors
{
    public partial class AuthorServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveAllAuthorsAsync()
        {
            // given
            List<Author> randomAuthors = CreateRandomAuthors();
            List<Author> rerievedAuthors = randomAuthors;
            List<Author> expetedAuthors = rerievedAuthors.DeepClone();

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllAuthorsAsync())
                    .ReturnsAsync(rerievedAuthors);

            // when
            List<Author> actualAuthors =
                await this.authorService.RetrieveAllAuthorsAsync();

            // then
            actualAuthors.Should().BeEquivalentTo(expetedAuthors);

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllAuthorsAsync(),
                    Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
