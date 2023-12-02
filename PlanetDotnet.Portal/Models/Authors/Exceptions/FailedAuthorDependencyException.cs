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
