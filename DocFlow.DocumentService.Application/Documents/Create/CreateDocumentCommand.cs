using DocFlow.DocumentService.Application.Common.Results;
using MediatR;

namespace DocFlow.DocumentService.Application.Documents.Create
{
    public sealed record CreateDocumentCommand(
        string FileName,
        string ContentType,
        string ObjectKey
        ) : IRequest<Result<Guid>>;
}
