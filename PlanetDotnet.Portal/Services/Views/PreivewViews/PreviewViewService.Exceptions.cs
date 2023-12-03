// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Foundations.Previews.Exceptions;
using PlanetDotnet.Portal.Models.Views.PreviewViews;
using PlanetDotnet.Portal.Models.Views.PreviewViews.Exceptions;

namespace PlanetDotnet.Portal.Services.Views.PreivewViews
{
    public partial class PreviewViewService
    {

        private delegate ValueTask<List<PreviewView>> ReturningPreviewViewsFunction();

        private async ValueTask<List<PreviewView>> TryCatch(ReturningPreviewViewsFunction returningPreviewViewsFunction)
        {
            try
            {
                return await returningPreviewViewsFunction();
            }
            catch (PreviewDependencyException previewDependencyException)
            {
                throw CreateAndLogDependencyException(previewDependencyException);
            }
            catch (PreviewServiceException previewServiceException)
            {
                throw CreateAndLogDependencyException(previewServiceException);
            }
            catch (Exception serviceException)
            {
                var failedPreviewViewServiceException = new FailedPreviewViewServiceException(serviceException);

                throw CreateAndLogServiceException(failedPreviewViewServiceException);
            }
        }

        private PreviewViewDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var previewViewDependencyException = new PreviewViewDependencyException(exception);
            this.loggingBroker.LogError(previewViewDependencyException);

            return previewViewDependencyException;
        }

        private PreviewViewServiceException CreateAndLogServiceException(Exception exception)
        {
            var previewViewServiceException = new PreviewViewServiceException(exception);
            this.loggingBroker.LogError(previewViewServiceException);

            return previewViewServiceException;
        }
    }
}
