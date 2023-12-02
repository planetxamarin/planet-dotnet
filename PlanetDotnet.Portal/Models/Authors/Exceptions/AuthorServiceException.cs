using Xeptions;

namespace PlanetDotnet.Portal.Models.Authors.Exceptions
{
    public class AuthorServiceException : Xeption
    {
        public AuthorServiceException(Xeption innerException)
            : base(message: "Author service error occurred, contact support.",
                  innerException)
        { }
    }
}
