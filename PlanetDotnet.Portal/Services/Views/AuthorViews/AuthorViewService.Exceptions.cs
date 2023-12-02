// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlanetDotnet.Portal.Models.Foundations.Authors.Exceptions;
using PlanetDotnet.Portal.Models.Views.AuthorViews;
using PlanetDotnet.Portal.Models.Views.AuthorViews.Exceptions;

namespace PlanetDotnet.Portal.Services.Views.AuthorViews
{
    public partial class AuthorViewService : IAuthorViewService
    {

        private delegate ValueTask<List<AuthorView>> ReturningAuthorViewsFunction();

        private async ValueTask<List<AuthorView>> TryCatch(ReturningAuthorViewsFunction returningAuthorViewsFunction)
        {
            try
            {
                return await returningAuthorViewsFunction();
            }
            catch (AuthorDependencyException authorDependencyException)
            {
                throw CreateAndLogDependencyException(authorDependencyException);
            }
            catch (AuthorServiceException authorServiceException)
            {
                throw CreateAndLogDependencyException(authorServiceException);
            }
            catch (Exception serviceException)
            {
                var failedAuthorViewServiceException = new FailedAuthorViewServiceException(serviceException);

                throw CreateAndLogServiceException(failedAuthorViewServiceException);
            }
        }

        private AuthorViewDependencyException CreateAndLogDependencyException(Exception exception)
        {
            var authorViewDependencyException = new AuthorViewDependencyException(exception);
            this.loggingBroker.LogError(authorViewDependencyException);

            return authorViewDependencyException;
        }

        private AuthorViewServiceException CreateAndLogServiceException(Exception exception)
        {
            var authorViewServiceException = new AuthorViewServiceException(exception);
            this.loggingBroker.LogError(authorViewServiceException);

            return authorViewServiceException;
        }
    }
}
