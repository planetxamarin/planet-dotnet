// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Authors;
using PlanetDotnet.Portal.Models.Authors.Exceptions;
using RESTFulSense.WebAssembly.Exceptions;
using Xeptions;

namespace PlanetDotnet.Portal.Services.Foundations.Authors
{
    public partial class AuthorService
    {
        private delegate ValueTask<List<Author>> ReturningAuthorsFunction();

        private async ValueTask<List<Author>> TryCatch(ReturningAuthorsFunction returningAuthorsFunction)
        {
            try
            {
                return await returningAuthorsFunction();
            }
            catch (HttpRequestException httpRequestException)
            {
                var failedAuthorDependencyException =
                    new FailedAuthorDependencyException(httpRequestException);

                throw CreateAndLogCriticalDependencyException(failedAuthorDependencyException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedAuthorDependencyException =
                    new FailedAuthorDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedAuthorDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var failedAuthorDependencyException =
                    new FailedAuthorDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedAuthorDependencyException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedAuthorDependencyException =
                    new FailedAuthorDependencyException(httpResponseException);

                throw CreateAndLogDependencyException(failedAuthorDependencyException);
            }
            catch (Exception exception)
            {
                var failedAuthorServiceException =
                    new FailedAuthorServiceException(exception);

                throw CreateAndLogAuthorServiceException(failedAuthorServiceException);
            }
        }

        private AuthorDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var AuthorDependencyException =
                new AuthorDependencyException(exception);

            this.loggingBroker.LogCritical(AuthorDependencyException);

            return AuthorDependencyException;
        }

        private AuthorDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var AuthorDependencyException =
                new AuthorDependencyException(exception);

            this.loggingBroker.LogError(AuthorDependencyException);

            return AuthorDependencyException;
        }

        private AuthorServiceException CreateAndLogAuthorServiceException(Xeption exception)
        {
            var AuthorServiceException =
                new AuthorServiceException(exception);

            this.loggingBroker.LogError(AuthorServiceException);

            return AuthorServiceException;
        }
    }
}