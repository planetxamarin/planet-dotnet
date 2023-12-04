// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace PlanetDotnet.Portal.Models.Views.PreviewViews.Exceptions
{
    public class FailedPreviewViewServiceException : Xeption
    {
        public FailedPreviewViewServiceException(Exception innerException)
            : base(message: "Failed preview view service error occurred, please contact support", innerException)
        { }
    }
}
