using Contacts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Application.Abstractions;

// I chose to introduce an abstraction over the DbContext to reduce tight coupling with a specific database context implementation.
// The Application layer should not depend on external layers (like Infrastructure), ensuring better separation of concerns.
// By using the interface `IApplicationDbContext`, I am also providing a basic level of abstraction over the database provider,
// which, while still tightly coupled to EF Core, offers some flexibility. For example, it makes unit testing the Application
// layer easier by allowing the use of mocks or in-memory databases instead of a real database connection.
// Though a full switch between PostgreSQL and SQL Server migrations may not be a common scenario, this abstraction provides
// a foundation for adapting or mocking specific database operations when needed.
public interface IApplicationDbContext
{
    public DbSet<Contact> Contacts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}