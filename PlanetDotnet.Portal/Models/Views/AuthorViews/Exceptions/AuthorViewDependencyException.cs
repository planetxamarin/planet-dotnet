// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace PlanetDotnet.Portal.Models.Views.AuthorViews.Exceptions
{
    public class AuthorViewDependencyException : Exception
    {
        public AuthorViewDependencyException(Exception innerException)
            : base("Author view dependency error occurred, contact support.", innerException)
        { }
    }
}
