using LinkShrink.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkShrink.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LinkController : ControllerBase
{
    public LinkController(LinkShrinkDbContext context)
    {
        _context = context;
    }


    private readonly LinkShrinkDbContext _context;


    [HttpGet]
    public async Task<IActionResult> GetUrl(string url)
    {
        Link? link = await _context.Links.FirstOrDefaultAsync(x => x.RedirectUrl == url);

        if (link is not null)
        {
            return Redirect(link.OriginUrl);
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

        Link newLink = new Link
        {
            OriginUrl = url,
            RedirectUrl = Guid.NewGuid().ToString()
        };

        await _context.Links.AddAsync(newLink);
        await _context.SaveChangesAsync();

        return Ok();
    }
}
