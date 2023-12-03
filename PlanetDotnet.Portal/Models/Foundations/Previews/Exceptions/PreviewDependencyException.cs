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
