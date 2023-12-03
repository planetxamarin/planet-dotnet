// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace PlanetDotnet.Portal.Models.Foundations.Previews.Exceptions
{
    public class FailedPreviewServiceException : Xeption
    {
        public FailedPreviewServiceException(Exception innerException)
            : base(message: "Failed Preview service error occurred, contact support.",
                  innerException)
        { }
    }
}
