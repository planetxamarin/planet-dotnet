using Xeptions;

namespace PlanetDotnet.Portal.Models.Foundations.Previews.Exceptions
{
    public class PreviewServiceException : Xeption
    {
        public PreviewServiceException(Xeption innerException)
            : base(message: "Preview service error occurred, contact support.",
                  innerException)
        { }
    }
}
