// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using Xeptions;

namespace PlanetDotnet.Portal.Models.Foundations.Previews.Exceptions
{
    public class PreviewDependencyException : Xeption
    {
        public PreviewDependencyException(Xeption innerException)
            : base(message: "Preview dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
