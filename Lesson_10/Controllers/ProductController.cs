using Lesson_10.Exceptions;
using Lesson_10.RequestModel;
using Lesson_10.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_10.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IDbService _dbService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct(PostProductRequestModel request, CancellationToken cancellationToken)
    {
        try
        {
            await _dbService.AddProductAsync(request, cancellationToken);
            return Created();
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}