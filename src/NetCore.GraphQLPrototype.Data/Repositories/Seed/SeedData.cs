using NetCore.GraphQLPrototype.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore.GraphQLPrototype.Data.Repositories.Seed
{
    public sealed class SeedData
    {
        public static IEnumerable<Author> Authors =>
            Books
                .Select(book =>
                    new Author
                    {
                        Id = book.Author.Id,
                        Name = book.Author.Name,
                        PublisherIds = new List<int> { book.Publisher.Id}
                    })
                .GroupBy(author => author.Id, (_, group) => group.FirstOrDefault())
                .OfType<Author>()
                .ToList();

        public static IEnumerable<Book> Books =>
            new List<Book>
            {
                new Book
                {
                    Isbn = "9781593275846",
                    Title = "Eloquent JavaScript, Second Edition",
                    SubTitle = "A Modern Introduction to Programming",
                    Description = "JavaScript lies at the heart of almost every modern web application, from social apps to the newest browser-based games. Though simple for beginners to pick up and play with, JavaScript is a flexible, complex language that you can use to build full-scale applications.",
                    Pages = 472,
                    PublishedAt = new DateTime(2014, 12, 14),
                    Author = new Author
                    {
                        Id = 1,
                        Name = "Marijn Haverbeke"
                    },
                    Publisher = new Publisher
                    {
                        Id = 1,
                        Name = "No Starch Press"
                    }
                },
                new Book
                {
                    Isbn = "9781449331818",
                    Title = "Learning JavaScript Design Patterns",
                    SubTitle = "A JavaScript and jQuery Developer's Guide",
                    Description = "With Learning JavaScript Design Patterns, you'll learn how to write beautiful, structured, and maintainable JavaScript by applying classical and modern design patterns to the language. If you want to keep your code efficient, more manageable, and up-to-date with the latest best practices, this book is for you.",
                    Pages = 254,
                    PublishedAt = new DateTime(2012, 7, 1),
                    Author = new Author
                    {
                        Id = 2,
                        Name = "Addy Osmani"
                    },
                    Publisher = new Publisher
                    {
                        Id = 2,
                        Name = "O'Reilly Media"
                    }
                },
                new Book
                {
                    Isbn = "9781449365035",
                    Title = "Speaking JavaScript",
                    SubTitle = "An In-Depth Guide for Programmers",
                        Description = "Like it or not, JavaScript is everywhere these days-from browser to server to mobile-and now you, too, need to learn the language or dive deeper than you have. This concise book guides you into and through JavaScript, written by a veteran programmer who once found himself in the same position.",
                        Pages = 460,
                        PublishedAt = new DateTime(2014, 2, 1),
                        Author = new Author
                        {
                            Id = 3,
                            Name = "Axel Rauschmayer"
                        },
                        Publisher = new Publisher
                        {
                            Id = 2,
                            Name = "O'Reilly Media"
                        }
                    },
                new Book
                {
                    Isbn = "9781491950296",
                    Title = "Programming JavaScript Applications",
                    SubTitle = "Robust Web Architecture with Node, HTML5, and Modern JS Libraries",
                    Description = "Take advantage of JavaScript's power to build robust web-scale or enterprise applications that are easy to extend and maintain. By applying the design patterns outlined in this practical book, experienced JavaScript developers will learn how to write flexible and resilient code that's easier-yes, easier-to work with as your code base grows.",
                    Pages = 254,
                    PublishedAt = new DateTime(2014, 7, 1),
                    Author = new Author
                    {
                        Id = 4,
                        Name = "Eric Elliott"
                    },
                    Publisher = new Publisher
                    {
                        Id = 2,
                        Name = "O'Reilly Media"
                    }
                },
                new Book
                {
                    Isbn = "9781593277574",
                    Title = "Understanding ECMAScript 6",
                    SubTitle = "The Definitive Guide for JavaScript Developers",
                    Description = "ECMAScript 6 represents the biggest update to the core of JavaScript in the history of the language. In Understanding ECMAScript 6, expert developer Nicholas C. Zakas provides a complete guide to the object types, syntax, and other exciting changes that ECMAScript 6 brings to JavaScript.",
                    Pages = 352,
                    PublishedAt = new DateTime(2016, 9, 3),
                    Author = new Author
                    {
                        Id = 5,
                        Name = "Nicholas C. Zakas"
                    },
                    Publisher = new Publisher
                    {
                        Id = 1,
                        Name = "No Starch Press"
                    }
                },
                new Book
                {
                    Isbn = "9781491904244",
                    Title = "You Don't Know JS",
                    SubTitle = "ES6 & Beyond",
                    Description = "No matter how much experience you have with JavaScript, odds are you don’t fully understand the language. As part of the \"You Don’t Know JS\" series, this compact guide focuses on new features available in ECMAScript 6 (ES6), the latest version of the standard upon which JavaScript is built.",
                    Pages = 278,
                    PublishedAt = new DateTime(2015, 12, 27),
                    Author = new Author
                    {
                        Id = 6,
                        Name = "Kyle Simpson"
                    },
                    Publisher = new Publisher
                    {
                        Id = 2,
                        Name = "O'Reilly Media"
                    }
                },
                new Book
                {
                    Isbn = "9781449325862",
                    Title = "Git Pocket Guide",
                    SubTitle = "A Working Introduction",
                    Description = "This pocket guide is the perfect on-the-job companion to Git, the distributed version control system. It provides a compact, readable introduction to Git for new users, as well as a reference to common commands and procedures for those of you with Git experience.",
                    Pages = 234,
                    PublishedAt = new DateTime(2013, 8, 2),
                    Author = new Author
                    {
                        Id = 7,
                        Name = "Richard E. Silverman"
                    },
                    Publisher = new Publisher
                    {
                        Id = 2,
                        Name = "O'Reilly Media"
                    }
                },
                new Book
                {
                    Isbn = "9781449337711",
                    Title = "Designing Evolvable Web APIs with ASP.NET",
                    SubTitle = "Harnessing the Power of the Web",
                    Description = "Design and build Web APIs for a broad range of clients—including browsers and mobile devices—that can adapt to change over time. This practical, hands-on guide takes you through the theory and tools you need to build evolvable HTTP services with Microsoft’s ASP.NET Web API framework. In the process, you’ll learn how design and implement a real-world Web API.",
                    Pages = 538,
                    PublishedAt = new DateTime(2014, 4, 7),
                    Author = new Author
                    {
                        Id = 8,
                        Name = "Glenn Block, et al."
                    },
                    Publisher = new Publisher
                    {
                        Id = 2,
                        Name = "O'Reilly Media"
                    }
                }
            };

        public static IEnumerable<Publisher> Publishers =>
            Books
                .Select(book =>
                    new Publisher
                    {
                        Id = book.Publisher.Id,
                        Name = book.Publisher.Name,
                    })
                .GroupBy(publisher => publisher.Id, (_, group) => group.FirstOrDefault())
                .OfType<Publisher>()
                .ToList();
    }
}
