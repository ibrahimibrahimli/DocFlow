using DocFlow.DocumentService.Application.Common.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DocFlow.DocumentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }


        protected IActionResult HandleResult(Result result)
        {
            if (result.IsFailure)
                return BadRequest(result.Error);

            return Ok();
        }
    }

}
