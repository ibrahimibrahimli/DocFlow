using DocFlow.DocumentService.Application.Documents.Create;
using DocFlow.DocumentService.Contracts.Documents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocFlow.DocumentService.Controllers
{
    

    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : BaseController
    {
        private readonly IMediator _mediator;

        public DocumentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDocumentRequest request, CancellationToken cancellationToken)
        {
            var command = new CreateDocumentCommand(
                request.FileName,
                request.ContentType,
                request.ObjectKey);

            var result = await _mediator.Send(command, cancellationToken);
            return HandleResult(result);
        }
    }
}
