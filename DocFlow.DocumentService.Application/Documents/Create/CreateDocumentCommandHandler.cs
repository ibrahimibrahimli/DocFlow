
using DocFlow.DocumentService.Application.Abstractions.Persistence;
using DocFlow.DocumentService.Domain.Documents;
using MediatR;

namespace DocFlow.DocumentService.Application.Documents.Create;

public sealed class CreateDocumentCommandHandler
    : IRequestHandler<CreateDocumentCommand, Guid>
{
    private readonly IDocumentRepository _documentRepository;

    public CreateDocumentCommandHandler(
        IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public async Task<Guid> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
    {
        var document = Document.Create(
            request.FileName,
            request.ContentType,
            request.ObjectKey);

        await _documentRepository.AddAsync(
            document,
            cancellationToken);

        return document.Id;
    }
}
