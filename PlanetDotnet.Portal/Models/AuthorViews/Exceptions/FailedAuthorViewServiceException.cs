// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace PlanetDotnet.Portal.Models.AuthorViews.Exceptions
{
    public class FailedAuthorViewServiceException : Xeption
    {
        public FailedAuthorViewServiceException(Exception innerException)
            : base(message: "Failed author view service error occurred, please contact support", innerException)
        { }
    }
}
