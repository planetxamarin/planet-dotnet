// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace PlanetDotnet.Portal.Models.Authors.Exceptions
{
    public class AuthorDependencyException : Xeption
    {
        public AuthorDependencyException(Xeption innerException)
            : base(message: "Author dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
