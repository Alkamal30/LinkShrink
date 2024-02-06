using Microsoft.AspNetCore.Mvc;

namespace LinkShrink.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LinkController : ControllerBase
{
    private static List<string> _links = new List<string>();

    [HttpGet]
    public async Task<IActionResult> GetUrl(string url)
    {
        if (_links.Contains(url))
        {
            return Redirect("https://microsoft.com");
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUrl([FromBody] string url)
    {
        if(string.IsNullOrEmpty(url))
        {
            return BadRequest();
        }

        _links.Add(url);

        return Ok();
    }
}
