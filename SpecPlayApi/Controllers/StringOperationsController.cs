using Microsoft.AspNetCore.Mvc;

namespace SpecPlayApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringOperationsController : ControllerBase
    {
        [HttpPost("count-chars")]
        public IActionResult CountCharacters([FromBody] string message)
        {
            return Ok(string.IsNullOrEmpty(message) ? 0 : message.Length);
        }

        [HttpPost("remove-vowels")]
        public IActionResult RemoveVowels([FromBody] string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return BadRequest("Invalid message");
            }

            var result = new string(message.Where(c => !IsVowel(c)).ToArray());
            return Ok(result);
        }

        private bool IsVowel(char c)
        {
            return "aeiouAEIOU".Contains(c);
        }
    }
}
