using System;
using Xeptions;

namespace PlanetDotnet.Portal.Models.Foundations.Previews.Exceptions
{
    public class FailedPreviewDependencyException : Xeption
    {
        public FailedPreviewDependencyException(Exception innerException)
            : base(message: "Failed Preview dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
