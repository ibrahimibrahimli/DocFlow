using DocFlow.DocumentService.Application.Abstractions.Persistence;
using DocFlow.DocumentService.Domain.Documents;
using DocFlow.DocumentService.Infrastructure.Persistence;

namespace DocFlow.DocumentService.Infrastructure.Persistance.Repository
{
    public sealed class DocumentRepository : IDocumentRepository
    {
        private readonly DocumentDbContext _dbContext;

        public DocumentRepository(DocumentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Document document, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<Document>().AddAsync(document, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
