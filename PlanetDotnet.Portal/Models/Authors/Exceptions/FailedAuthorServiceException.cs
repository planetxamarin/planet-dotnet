// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace PlanetDotnet.Portal.Models.Authors.Exceptions
{
    public class FailedAuthorServiceException : Xeption
    {
        public FailedAuthorServiceException(Exception innerException)
            : base(message: "Failed Author service error occurred, contact support.",
                  innerException)
        { }
    }
}
