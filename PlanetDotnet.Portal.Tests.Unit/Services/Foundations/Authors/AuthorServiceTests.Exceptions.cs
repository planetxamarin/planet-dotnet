// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using PlanetDotnet.Portal.Models.Foundations.Authors;
using PlanetDotnet.Portal.Models.Foundations.Authors.Exceptions;
using Xunit;

namespace PlanetDotnet.Portal.Tests.Unit.Services.Foundations.Authors
{
    public partial class AuthorServiceTests
    {
        [Theory]
        [MemberData(nameof(CriticalApiException))]
        public async Task ShouldThrowCriticalDependencyExceptionOnRetrieveAllIfCriticalDependencyExceptionOccursAndLogItAsync(
           Exception criticalDependencyException)
        {
            // given
            var failedAuthorDependencyException =
                new FailedAuthorDependencyException(
                    criticalDependencyException);

            var expectedAuthorDependencyException =
                new AuthorDependencyException(
                    failedAuthorDependencyException);

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllAuthorsAsync())
                    .ThrowsAsync(criticalDependencyException);

            // when
            ValueTask<List<Author>> retrievedAuthorsTask =
                this.authorService.RetrieveAllAuthorsAsync();

            // then
            await Assert.ThrowsAsync<AuthorDependencyException>(() =>
               retrievedAuthorsTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllAuthorsAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogCritical(It.Is(SameExceptionAs(
                    expectedAuthorDependencyException))),
                        Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(DependencyApiException))]
        public async Task ShouldThrowDependencyExceptionOnRetrieveAllIfDependencyApiErrorOccursAndLogItAsync(
            Exception dependencyApiException)
        {
            // given
            var failedAuthorDependencyException =
                new FailedAuthorDependencyException(dependencyApiException);

            var expectedAuthorDependencyException =
                new AuthorDependencyException(failedAuthorDependencyException);

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllAuthorsAsync())
                    .ThrowsAsync(dependencyApiException);
            // when
            ValueTask<List<Author>> retrievedAuthorsTask =
                this.authorService.RetrieveAllAuthorsAsync();

            // then
            await Assert.ThrowsAsync<AuthorDependencyException>(() =>
                retrievedAuthorsTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllAuthorsAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedAuthorDependencyException))),
                        Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRetrieveAllIfServiceErrorOccursAndLogItAsync()
        {
            // given
            var serviceException = new Exception();

            var failedAuthorServiceExcption =
                new FailedAuthorServiceException(serviceException);

            var expectedAuthorServiceException =
                new AuthorServiceException(failedAuthorServiceExcption);

            this.apiBrokerMock.Setup(broker =>
                broker.GetAllAuthorsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<List<Author>> retrievedAuthorTask =
                this.authorService.RetrieveAllAuthorsAsync();

            // then
            await Assert.ThrowsAsync<AuthorServiceException>(() =>
                retrievedAuthorTask.AsTask());

            this.apiBrokerMock.Verify(broker =>
                broker.GetAllAuthorsAsync(),
                    Times.Once);

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedAuthorServiceException))),
                        Times.Once);

            this.apiBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
