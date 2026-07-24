
using DocFlow.DocumentService.Domain.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocFlow.DocumentService.Infrastructure.Persistence.Configurations;

public sealed class DocumentConfiguration
    : IEntityTypeConfiguration<Document>
{
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.ToTable("documents");

        builder.HasKey(document => document.Id);

        builder.Property(document => document.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(document => document.ContentType)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(document => document.ObjectKey)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(document => document.Status)
            .HasConversion<string>()
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(document => document.CreatedAt)
            .IsRequired();
    }
}
