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
