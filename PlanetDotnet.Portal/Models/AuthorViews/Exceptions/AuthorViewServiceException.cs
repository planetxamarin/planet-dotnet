// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace PlanetDotnet.Portal.Models.AuthorViews.Exceptions
{
    public class AuthorViewServiceException : Exception
    {
        public AuthorViewServiceException(Exception innerException)
            : base("Author View service error occured, contact support.", innerException) { }
    }
}
