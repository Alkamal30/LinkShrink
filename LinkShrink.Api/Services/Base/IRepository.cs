using LinkShrink.Api.Models.Base;

namespace LinkShrink.Api.Services.Base;

public interface IRepository<TModel, TId> where TModel : BaseModel<TId>
{
    Task<TModel> GetByIdAsync(TId id);
    Task<IEnumerable<TModel>> GetAllAsync();

    Task AddAsync(TModel entity);
    Task UpdateAsync(TModel entity);
    Task RemoveAsync(TModel entity);
    Task RemoveByIdAsync(TId id);
}
