// ---------------------------------------------------------------
// Copyright (c) 2023 Planet Dotnet. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using KellermanSoftware.CompareNetObjects;
using Moq;
using PlanetDotnet.Portal.Brokers.Loggings;
using PlanetDotnet.Portal.Models.Authors;
using PlanetDotnet.Portal.Models.Authors.Exceptions;
using PlanetDotnet.Portal.Models.AuthorViews;
using PlanetDotnet.Portal.Models.GeoPositions;
using PlanetDotnet.Portal.Services.Foundations.Authors;
using PlanetDotnet.Portal.Services.Views.AuthorViews;
using Tynamix.ObjectFiller;
using Xunit;

namespace PlanetDotnet.Portal.Tests.Unit.Services.Views.AuthorViews
{
    public partial class AuthorViewServiceTests
    {
        private readonly Mock<IAuthorService> authorServiceMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly ICompareLogic compareLogic;
        private readonly IAuthorViewService authorViewService;

        public AuthorViewServiceTests()
        {
            this.authorServiceMock = new Mock<IAuthorService>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.compareLogic = new CompareLogic();

            this.authorViewService = new AuthorViewService(
                authorService: this.authorServiceMock.Object,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        public static TheoryData DependencyExceptions()
        {
            var innerException = new Xeptions.Xeption();

            var authorDependencyException =
                new AuthorDependencyException(innerException);

            var authorServiceException =
                new AuthorServiceException(innerException);

            return new TheoryData<Exception>
            {
                authorDependencyException,
                authorServiceException
            };
        }

        private static dynamic CreateRandomAuthorViewProperties()
        {
            GeoPosition randomGeoPostion = GetRandomGeoPosition();

            return new
            {
                DisplayName = GetRandomName(),
                Location = GetRandomString(),
                ShortBioOrTagLine = GetRandomString(),
                WebSite = new Uri(GetRandomRoute()),
                TwitterHandle = GetRandomString(),
                GravatarUrl = GetRandomRoute(),
                Position = randomGeoPostion
            };
        }

        private static List<dynamic> CreateRandomAuthorViewCollections()
        {
            int randomCount = GetRandomNumber();

            return Enumerable.Range(0, randomCount).Select(item =>
            {
                GeoPosition randomGeoPostion = GetRandomGeoPosition();

                return new
                {
                    DisplayName = GetRandomName(),
                    Location = GetRandomString(),
                    ShortBioOrTagLine = GetRandomString(),
                    WebSite = new Uri(GetRandomRoute()),
                    TwitterHandle = GetRandomString(),
                    GravatarUrl = GenerateRandomGravatarUrl(),
                    Position = randomGeoPostion
                };

            }).ToList<dynamic>();
        }

        private static int GetRandomNumber() => new IntRange(min: 2, max: 10).GetValue();

        private Expression<Func<Author, bool>> SameAuthorAs(Author expectedAuthor)
        {
            return actualAuthor => this.compareLogic.Compare(expectedAuthor, actualAuthor)
                .AreEqual;
        }

        private static DateTimeOffset GetRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static AuthorView CreateRandomAuthorView() =>
            CreateAuthorViewFiller().Create();

        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException => actualException.Message == expectedException.Message
                && actualException.InnerException.Message == expectedException.InnerException.Message;
        }

        private static string GetRandomRoute() =>
            new RandomUrl().GetValue();

        private static string GetRandomName() =>
            new RealNames(NameStyle.FirstName).GetValue();

        private static string GetRandomString() =>
            new MnemonicString().GetValue();

        private static GeoPosition GetRandomGeoPosition() =>
            new Filler<GeoPosition>().Create();

        private static Filler<AuthorView> CreateAuthorViewFiller()
        {
            var filler = new Filler<AuthorView>();

            filler.Setup()
                .OnType<DateTimeOffset>().Use(DateTimeOffset.UtcNow);

            return filler;
        }

        private static string GenerateRandomGravatarUrl()
        {
            string randomEmail = GetRandomString()?.Replace(" ", "") + "@example.com";
            string hash = CalculateMD5Hash(randomEmail);
            return $"//www.gravatar.com/avatar/{hash}.jpg?s=200&d=mm";
        }

        private static string CalculateMD5Hash(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = MD5.HashData(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString().ToLower();
        }

        private static string ExtractHashFromGravatarUrl(string url)
        {
            int hashStartIndex = url.IndexOf("avatar/") + "avatar/".Length;

            int hashEndIndex = url.IndexOf(".jpg", hashStartIndex); 

            return url[hashStartIndex..hashEndIndex];
        }
    }
}
