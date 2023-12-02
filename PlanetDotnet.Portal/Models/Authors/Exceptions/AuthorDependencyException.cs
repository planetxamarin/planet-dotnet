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
