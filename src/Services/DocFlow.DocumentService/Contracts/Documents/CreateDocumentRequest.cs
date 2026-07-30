namespace DocFlow.DocumentService.Contracts.Documents
{
    public sealed record CreateDocumentRequest(
        string FileName,
        string ContentType,
        string ObjectKey);
}
