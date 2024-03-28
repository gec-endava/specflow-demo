using Microsoft.AspNetCore.Mvc;

namespace SpecPlayApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MathOperationsController : ControllerBase
{
    [HttpGet("add")]
    public IActionResult Add([FromQuery] int a, [FromQuery] int b)
    {
        return Ok(a + b);
    }

    [HttpGet("factorial")]
    public IActionResult Factorial([FromQuery] long a)
    {
        if (a > 20 || a < 0)
        {
            return BadRequest("a must be less than or equal to 20 and greater than or equal to 0");
}

        long factorial = a--;
        while (a > 0)
        {
            factorial *= a--;
        }
        return Ok(factorial);
    }

    [HttpPost("sum")]
    public IActionResult Sum([FromBody] int[] numbers)
    {
        var x = numbers.Sum();
        return Ok(x);
    }
}
