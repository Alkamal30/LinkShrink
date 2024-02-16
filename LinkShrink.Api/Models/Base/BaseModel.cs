namespace LinkShrink.Api.Models.Base;

public class BaseModel<TId> where TId : struct
{
    public TId Id { get; set; }
}
