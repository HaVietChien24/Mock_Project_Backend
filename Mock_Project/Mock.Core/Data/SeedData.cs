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

    }
}
