﻿namespace Schema.NET.Test
{
    using System;
    using System.Collections.Generic;
    using Xunit;

    public class BookTest
    {
        [Fact]
        public void ToString_BookGoogleStructuredData_ReturnsExpectedJsonLd()
        {
            var book = new Book()
            {
                Name = "The Catcher in the Rye",
                Author = new Person()
                {
                    Name = "J.D. Salinger"
                },
                Url = new Uri("http://www.barnesandnoble.com/store/info/offer/JDSalinger"),
                WorkExample = new List<CreativeWork>()
                {
                    new Book()
                    {
                        Isbn = "031676948",
                        BookEdition = "2nd Edition",
                        BookFormat = BookFormatType.Hardcover,
                        PotentialAction = new ReadAction()
                        {
                            Target = new EntryPoint()
                            {
                                UrlTemplate = "http://www.barnesandnoble.com/store/info/offer/0316769487?purchase=true",
                                ActionPlatform = new List<Uri>()
                                {
                                    new Uri("http://schema.org/DesktopWebPlatform"),
                                    new Uri("http://schema.org/IOSPlatform"),
                                    new Uri("http://schema.org/AndroidPlatform")
                                }
                            },
                            ExpectsAcceptanceOf = new Offer()
                            {
                                Price = 6.99M,
                                PriceCurrency = "USD",
                                EligibleRegion = new Country()
                                {
                                    Name = "US"
                                },
                                Availability = ItemAvailability.InStock
                            }
                        },
                    },
                    new Book()
                    {
                        Isbn = "031676947",
                        BookEdition = "1st Edition",
                        BookFormat = BookFormatType.EBook,
                        PotentialAction = new ReadAction()
                        {
                            Target = new EntryPoint()
                            {
                                UrlTemplate = "http://www.barnesandnoble.com/store/info/offer/031676947?purchase=true",
                                ActionPlatform = new List<Uri>()
                                {
                                    new Uri("http://schema.org/DesktopWebPlatform"),
                                    new Uri("http://schema.org/IOSPlatform"),
                                    new Uri("http://schema.org/AndroidPlatform")
                                }
                            },
                            ExpectsAcceptanceOf = new Offer()
                            {
                                Price = 1.99M,
                                PriceCurrency = "USD",
                                EligibleRegion = new Country()
                                {
                                    Name = "UK"
                                },
                                Availability = ItemAvailability.InStock
                            }
                        },
                    }
                }
            };
            var expectedJson =
                "{" +
                    "\"@context\":\"http://schema.org\"," +
                    "\"@type\":\"Book\"," +
                    "\"name\":\"The Catcher in the Rye\"," +
                    "\"url\":\"http://www.barnesandnoble.com/store/info/offer/JDSalinger\"," +
                    "\"author\":{" +
                        "\"@type\":\"Person\"," +
                        "\"name\":\"J.D. Salinger\"" +
                    "}," +
                    "\"workExample\":[" +
                        "{" +
                            "\"@type\":\"Book\"," +
                            "\"potentialAction\":{" +
                                "\"@type\":\"ReadAction\"," +
                                "\"target\":{" +
                                    "\"@type\":\"EntryPoint\"," +
                                    "\"actionPlatform\":[" +
                                        "\"http://schema.org/DesktopWebPlatform\"," +
                                        "\"http://schema.org/IOSPlatform\"," +
                                        "\"http://schema.org/AndroidPlatform\"" +
                                    "]," +
                                    "\"urlTemplate\":\"http://www.barnesandnoble.com/store/info/offer/0316769487?purchase=true\"" +
                                "}," +
                                "\"expectsAcceptanceOf\":{" +
                                    "\"@type\":\"Offer\"," +
                                    "\"availability\":\"http://schema.org/InStock\"," +
                                    "\"eligibleRegion\":{" +
                                        "\"@type\":\"Country\"," +
                                        "\"name\":\"US\"" +
                                    "}," +
                                    "\"price\":6.99," +
                                    "\"priceCurrency\":\"USD\"" +
                                "}" +
                            "}," +
                            "\"bookEdition\":\"2nd Edition\"," +
                            "\"bookFormat\":\"http://schema.org/Hardcover\"," +
                            "\"isbn\":\"031676948\"" +
                        "}," +
                        "{" +
                            "\"@type\":\"Book\"," +
                            "\"potentialAction\":{" +
                                "\"@type\":\"ReadAction\"," +
                                "\"target\":{" +
                                    "\"@type\":\"EntryPoint\"," +
                                    "\"actionPlatform\":[" +
                                        "\"http://schema.org/DesktopWebPlatform\"," +
                                        "\"http://schema.org/IOSPlatform\"," +
                                        "\"http://schema.org/AndroidPlatform\"" +
                                    "]," +
                                    "\"urlTemplate\":\"http://www.barnesandnoble.com/store/info/offer/031676947?purchase=true\"" +
                                "}," +
                                "\"expectsAcceptanceOf\":{" +
                                    "\"@type\":\"Offer\"," +
                                    "\"availability\":\"http://schema.org/InStock\"," +
                                    "\"eligibleRegion\":{" +
                                        "\"@type\":\"Country\"," +
                                        "\"name\":\"UK\"" +
                                    "}," +
                                    "\"price\":1.99," +
                                    "\"priceCurrency\":\"USD\"" +
                                "}" +
                            "}," +
                            "\"bookEdition\":\"1st Edition\"," +
                            "\"bookFormat\":\"http://schema.org/EBook\"," +
                            "\"isbn\":\"031676947\"" +
                        "}" +
                    "]" +
                "}";

            var json = book.ToString();

            Assert.Equal(expectedJson, json);
        }
    }
}
