using Contacts.Application.Abstractions;
using Contacts.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.DbContexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Contact> Contacts { get; set; } = null!;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);
        base.OnModelCreating(builder);
    }
}
