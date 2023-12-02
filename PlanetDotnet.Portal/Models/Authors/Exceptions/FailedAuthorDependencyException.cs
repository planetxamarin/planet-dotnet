// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using Xeptions;

namespace PlanetDotnet.Portal.Models.Authors.Exceptions
{
    public class FailedAuthorDependencyException : Xeption
    {
        public FailedAuthorDependencyException(Exception innerException)
            : base(message: "Failed Author dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
