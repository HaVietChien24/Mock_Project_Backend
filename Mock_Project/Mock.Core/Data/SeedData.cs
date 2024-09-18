using Mock.Core.Models;

namespace Mock.Core.Data
{
    public static class SeedData
    {
        public static List<User> SeedUser()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    FirstName = "Josh",
                    LastName = "Miller",
                    ImageUrl = null,
                    Email = "josh@gmail.com",
                    Phone = "1234567890",
                    Username = "josh_miller",
                    Password = "$2a$12$PWrcJdxqn2qbniRRBOOFVOhpx925EOLuMJmEX1ZfOhsU0znIClGOu", // Ncs@14082011
                    IsActive = true,
                    IsAdmin = true
                },
                new User
                {
                    Id = 2,
                    FirstName = "Mark",
                    LastName = "Smith",
                    ImageUrl = null,
                    Email = "mark@gmail.com",
                    Phone = "0987654321",
                    Username = "mark_smith",
                    Password = "$2a$12$PWrcJdxqn2qbniRRBOOFVOhpx925EOLuMJmEX1ZfOhsU0znIClGOu", // Ncs@14082011
                    IsActive = true,
                    IsAdmin = true
                },
                new User
                {
                    Id = 3,
                    FirstName = "Jessica",
                    LastName = "Johnson",
                    ImageUrl = null,
                    Email = "jessica@gmail.com",
                    Phone = "09022254566",
                    Username = "jessica_johnson",
                    Password = "$2a$12$PWrcJdxqn2qbniRRBOOFVOhpx925EOLuMJmEX1ZfOhsU0znIClGOu", // Ncs@14082011
                    IsActive = true,
                    IsAdmin = true
                }
            };
        }

    //    public static List<Book> SeedBook()
    //    {
    //        return new List<Book>()
    //        {
    //            new Book { Id = 1, Title = "Dune", Description = "Epic science fiction novel.", Author = "Frank Herbert", Publisher = "Chilton Books", PublishedYear = 1965, ISBN = "9780441172719", Amount = 15, ImageUrl = "/images/dune.jpg" },
    //new Book { Id = 2, Title = "The Hobbit", Description = "Fantasy adventure about a hobbit's journey.", Author = "J.R.R. Tolkien", Publisher = "George Allen & Unwin", PublishedYear = 1937, ISBN = "9780547928227", Amount = 10, ImageUrl = "/images/hobbit.jpg" },
    //new Book { Id = 3, Title = "The Da Vinci Code", Description = "Mystery thriller about a hidden code in religious art.", Author = "Dan Brown", Publisher = "Doubleday", PublishedYear = 2003, ISBN = "9780307474278", Amount = 20, ImageUrl = "/images/davinci.jpg" },
    //new Book { Id = 4, Title = "Gone Girl", Description = "Psychological thriller about a wife's disappearance.", Author = "Gillian Flynn", Publisher = "Crown Publishing", PublishedYear = 2012, ISBN = "9780307588371", Amount = 8, ImageUrl = "/images/gonegirl.jpg" },
    //new Book { Id = 5, Title = "Pride and Prejudice", Description = "Classic romance novel about social standing and marriage.", Author = "Jane Austen", Publisher = "T. Egerton", PublishedYear = 1813, ISBN = "9780141439518", Amount = 12, ImageUrl = "/images/pride.jpg" },
    //new Book { Id = 6, Title = "The Book Thief", Description = "Historical novel set in Nazi Germany.", Author = "Markus Zusak", Publisher = "Picador", PublishedYear = 2005, ISBN = "9780375842207", Amount = 18, ImageUrl = "/images/bookthief.jpg" },
    //new Book { Id = 7, Title = "Sapiens: A Brief History of Humankind", Description = "Non-fiction book about the history of humanity.", Author = "Yuval Noah Harari", Publisher = "Harper", PublishedYear = 2011, ISBN = "9780062316097", Amount = 25, ImageUrl = "/images/sapiens.jpg" },
    //new Book { Id = 8, Title = "The Shining", Description = "Horror novel about a haunted hotel.", Author = "Stephen King", Publisher = "Doubleday", PublishedYear = 1977, ISBN = "9780307743657", Amount = 9, ImageUrl = "/images/shining.jpg" },
    //new Book { Id = 9, Title = "The Adventures of Sherlock Holmes", Description = "Detective stories featuring Sherlock Holmes.", Author = "Arthur Conan Doyle", Publisher = "George Newnes", PublishedYear = 1892, ISBN = "9780141034379", Amount = 14, ImageUrl = "/images/sherlock.jpg" },
    //new Book { Id = 10, Title = "The Diary of a Young Girl", Description = "Autobiographical account by Anne Frank.", Author = "Anne Frank", Publisher = "Contact Publishing", PublishedYear = 1947, ISBN = "9780553296983", Amount = 7, ImageUrl = "/images/diary.jpg" }

    //    };
    //    }





    }
}
