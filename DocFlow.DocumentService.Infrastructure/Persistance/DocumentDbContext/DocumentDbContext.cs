
using Microsoft.EntityFrameworkCore;

namespace DocFlow.DocumentService.Infrastructure.Persistence;

public sealed class DocumentDbContext : DbContext
{
    public DocumentDbContext(
        DbContextOptions<DocumentDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DocumentDbContext).Assembly);
    }
}
