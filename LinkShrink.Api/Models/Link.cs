namespace LinkShrink.Api.Models;

public class Link
{
    public long Id { get; set; }
    public string RedirectUrl { get; set; } = string.Empty;
    public string OriginUrl { get; set; } = string.Empty;
}
