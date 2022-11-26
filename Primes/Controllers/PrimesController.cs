using Microsoft.AspNetCore.Mvc;
using Primes.API.Core;
using System.Collections;
using System.Collections.Generic;

namespace Primes.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrimesController : ControllerBase
{
    private readonly IPrimesManager primesManager;

    public PrimesController(IPrimesManager primesManager)
    {
        this.primesManager = primesManager;
    }

    /// <summary>
    /// Returns a list of primes to the given upper limit (inclusive).
    /// </summary>
    /// <param name="limit">The limit until which the primes should be returned.</param>
    /// <returns>IEnumarable (int) of primes.</returns>
    [HttpGet("list")]
    public ActionResult<IEnumerable<int>> GetPrimesToLimit([FromQuery] int limit)
    {
        if (limit <= 0 || limit > 100) 
        {
            return BadRequest($"The upper limit should be between 1 and 100 (inclusive).");
        }

        return Ok(primesManager.GetPrimesToLimit(limit));
    }
}
