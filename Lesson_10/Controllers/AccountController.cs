using Lesson_10.Exceptions;
using Lesson_10.Services;

namespace Lesson_10.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class AccountsController(IDbService _dbService) : ControllerBase
{

    [HttpGet("{accountId:int}")]
    public async Task<IActionResult> GetAccount(int accountId, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _dbService.GetAccountByIdAsync(accountId, cancellationToken);
            if (result == null)
            {
                return NotFound($"Account with id: {accountId} does not exist");
            }

            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}