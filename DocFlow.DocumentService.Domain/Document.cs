
using DocFlow.DocumentService.Domain.Common;

namespace DocFlow.DocumentService.Domain.Documents;

public sealed class Document : BaseEntity
{
    public string FileName { get; private set; } = string.Empty;

    public string ContentType { get; private set; } = string.Empty;

    public string ObjectKey { get; private set; } = string.Empty;

    public DocumentStatus Status { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    private Document()
    {
    }

    public static Document Create(
        string fileName,
        string contentType,
        string objectKey)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fileName);
        ArgumentException.ThrowIfNullOrWhiteSpace(contentType);
        ArgumentException.ThrowIfNullOrWhiteSpace(objectKey);

        return new Document
        {
            FileName = fileName,
            ContentType = contentType,
            ObjectKey = objectKey,
            Status = DocumentStatus.Pending,
            CreatedAt = DateTimeOffset.UtcNow
        };
    }

    public void StartProcessing()
    {
        if (Status != DocumentStatus.Pending)
        {
            throw new InvalidOperationException(
                $"Cannot start processing a document with status '{Status}'.");
        }

        Status = DocumentStatus.Processing;
    }

    public void Complete()
    {
        if (Status != DocumentStatus.Processing)
        {
            throw new InvalidOperationException(
                $"Cannot complete a document with status '{Status}'.");
        }

        Status = DocumentStatus.Completed;
    }

    public void Fail()
    {
        if (Status != DocumentStatus.Processing)
        {
            throw new InvalidOperationException(
                $"Cannot fail a document with status '{Status}'.");
        }

        Status = DocumentStatus.Failed;
    }
}
