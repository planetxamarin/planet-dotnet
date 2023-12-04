// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Foundations.Previews;
using PlanetDotnet.Portal.Models.Foundations.Previews.Exceptions;
using RESTFulSense.WebAssembly.Exceptions;
using Xeptions;

namespace PlanetDotnet.Portal.Services.Foundations.Previews
{
    public partial class PreviewService
    {
        private delegate ValueTask<List<Preview>> ReturningPreviewsFunction();

        private async ValueTask<List<Preview>> TryCatch(ReturningPreviewsFunction returningPreviewsFunction)
        {
            try
            {
                return await returningPreviewsFunction();
            }
            catch (HttpRequestException httpRequestException)
            {
                var failedPreviewDependencyException =
                    new FailedPreviewDependencyException(httpRequestException);

                throw CreateAndLogCriticalDependencyException(failedPreviewDependencyException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var failedPreviewDependencyException =
                    new FailedPreviewDependencyException(httpResponseUrlNotFoundException);

                throw CreateAndLogCriticalDependencyException(failedPreviewDependencyException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var failedPreviewDependencyException =
                    new FailedPreviewDependencyException(httpResponseUnauthorizedException);

                throw CreateAndLogCriticalDependencyException(failedPreviewDependencyException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedPreviewDependencyException =
                    new FailedPreviewDependencyException(httpResponseException);

                throw CreateAndLogDependencyException(failedPreviewDependencyException);
            }
            catch (Exception exception)
            {
                var failedPreviewServiceException =
                    new FailedPreviewServiceException(exception);

                throw CreateAndLogPreviewServiceException(failedPreviewServiceException);
            }
        }

        private PreviewDependencyException CreateAndLogCriticalDependencyException(Xeption exception)
        {
            var PreviewDependencyException =
                new PreviewDependencyException(exception);

            this.loggingBroker.LogCritical(PreviewDependencyException);

            return PreviewDependencyException;
        }

        private PreviewDependencyException CreateAndLogDependencyException(Xeption exception)
        {
            var PreviewDependencyException =
                new PreviewDependencyException(exception);

            this.loggingBroker.LogError(PreviewDependencyException);

            return PreviewDependencyException;
        }

        private PreviewServiceException CreateAndLogPreviewServiceException(Xeption exception)
        {
            var PreviewServiceException =
                new PreviewServiceException(exception);

            this.loggingBroker.LogError(PreviewServiceException);

            return PreviewServiceException;
        }
    }
}