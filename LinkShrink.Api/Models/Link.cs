using LinkShrink.Api.Models.Base;

namespace LinkShrink.Api.Models;

public class Link : BaseModel<long>
{
    public string RedirectUrl { get; set; } = string.Empty;
    public string OriginUrl { get; set; } = string.Empty;
}
