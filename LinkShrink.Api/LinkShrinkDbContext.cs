using LinkShrink.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LinkShrink.Api;

public class LinkShrinkDbContext : DbContext
{
    public LinkShrinkDbContext(DbContextOptions<LinkShrinkDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Link> Links { get; set; }
}
