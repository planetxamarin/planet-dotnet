// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace PlanetDotnet.Portal.Models.Foundations.Authors.Exceptions
{
    public class AuthorServiceException : Xeption
    {
        public AuthorServiceException(Xeption innerException)
            : base(message: "Author service error occurred, contact support.",
                  innerException)
        { }
    }
}
