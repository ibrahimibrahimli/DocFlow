using MediatR;

namespace DocFlow.DocumentService.Application.Documents.Create
{
    public sealed record CreateDocumentCommand(
        string FileName,
        string ContentType,
        string ObjectKey
        ) : IRequest<Guid>;
}
