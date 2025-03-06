using GroupFind.Data.Models;
using GroupFind.Data;
using Microsoft.EntityFrameworkCore;

public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        // Ensure database is created
        context.Database.Migrate();

        // Check if categories exist
        if (context.Category.Any())
        {
            return; // Database has been seeded
        }

        // Seed Categories
        var categories = new Category[]
        {
            new() { CategoryName = "Entertainment" },
            new() { CategoryName = "Technology" },
            new() { CategoryName = "Food & Drink" }
        };
        context.Category.AddRange(categories);
        context.SaveChanges();

        // Seed Users
        var users = new User[]
        {
            new() { LegalFirstName = "John", LegalLastName = "Doe", EmailAddress = "john.doe@email.com", PhoneNumber = "123-456-7890", Password = "hashed_password", AdminStatus = false },
            new() { LegalFirstName = "Jane", LegalLastName = "Smith", EmailAddress = "jane.smith@email.com", PhoneNumber = "987-654-3210", Password = "hashed_password", AdminStatus = true }
        };
        context.User.AddRange(users);
        context.SaveChanges();

        // Seed Events
        var events = new Event[]
        {
            new() { CreatorID = users[0].UserID, CategoryID = categories[0].CategoryID, EventTitle = "Live Concert", EventStartDateTime = DateTime.Now.AddDays(5), EventEndDateTime = DateTime.Now.AddDays(5).AddHours(4), City = "New York", Country = "USA", Address = "123 Music Lane", SignupLinkFromCreator = "#", User = users[0], Category = categories[0] },
            new() { CreatorID = users[1].UserID, CategoryID = categories[1].CategoryID, EventTitle = "Tech Meetup", EventStartDateTime = DateTime.Now.AddDays(10), EventEndDateTime = DateTime.Now.AddDays(10).AddHours(3), City = "San Francisco", Country = "USA", Address = "456 Tech Street", SignupLinkFromCreator = "#", User = users[1], Category = categories[1] }
        };
        context.Event.AddRange(events);
        context.SaveChanges();
    }
}
