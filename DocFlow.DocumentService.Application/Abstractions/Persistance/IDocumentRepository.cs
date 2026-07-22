
using DocFlow.DocumentService.Domain.Documents;

namespace DocFlow.DocumentService.Application.Abstractions.Persistence;

public interface IDocumentRepository
{
    Task AddAsync(
        Document document,
        CancellationToken cancellationToken = default);
}
