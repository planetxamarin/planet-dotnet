// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PlanetDotnet.Portal.Models.Views.AuthorViews;
using PlanetDotnet.Portal.Models.Views.AuthorViews.Exceptions;
using Xunit;

namespace PlanetDotnet.Portal.Tests.Unit.Services.Views.AuthorViews
{
    public partial class AuthorViewServiceTests
    {
        [Theory]
        [MemberData(nameof(DependencyExceptions))]
        public async Task ShouldThrowAuthorViewDependencyExceptionIfDependencyErrorOccursAndLogItAsync(
           Exception dependencyException)
        {
            // given
            var expectedAuthorViewDependencyException =
                new AuthorViewDependencyException(dependencyException);

            this.authorServiceMock.Setup(service =>
                service.RetrieveAllAuthorsAsync())
                    .ThrowsAsync(dependencyException);

            // when
            ValueTask<List<AuthorView>> retrieveAllAuthorViewsTask =
                this.authorViewService.RetrieveAllAuthorViewsAsync();

            // then
            await Assert.ThrowsAsync<AuthorViewDependencyException>(() =>
                retrieveAllAuthorViewsTask.AsTask());

            this.authorServiceMock.Verify(service =>
                service.RetrieveAllAuthorsAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedAuthorViewDependencyException))),
                        Times.Once);

            this.authorServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowAuthorViewServiceExceptionIfServiceErrorOccursAndLogItAsync()
        {
            // given
            var serviceException = new Exception();

            var failedAuthorViewServiceException =
                new FailedAuthorViewServiceException(serviceException);

            var expectedAuthorViewServiceException =
                new AuthorViewServiceException(failedAuthorViewServiceException);

            this.authorServiceMock.Setup(service =>
                service.RetrieveAllAuthorsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<List<AuthorView>> retrieveAllAuthorViewsTask =
                this.authorViewService.RetrieveAllAuthorViewsAsync();

            // then
            await Assert.ThrowsAsync<AuthorViewServiceException>(() =>
                retrieveAllAuthorViewsTask.AsTask());

            this.authorServiceMock.Verify(service =>
                service.RetrieveAllAuthorsAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedAuthorViewServiceException))),
                        Times.Once);

            this.authorServiceMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
