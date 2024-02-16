
using LinkShrink.Api.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace LinkShrink.Api.Services.Base;

public class BaseRepository<TModel, TId> : IRepository<TModel, TId> 
    where TModel : BaseModel<TId> 
    where TId : struct
{
    protected BaseRepository(LinkShrinkDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TModel>();
    }


    protected LinkShrinkDbContext _context { get; set; }
    protected DbSet<TModel> _dbSet { get; set; }


    public async Task<TModel?> GetByIdAsync(TId id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }

    public async Task<IEnumerable<TModel>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(TModel entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task UpdateAsync(TModel entity)
    {
        _dbSet.Update(entity);

        return Task.CompletedTask;
    }

    public Task RemoveAsync(TModel entity)
    {
        _dbSet.Remove(entity);

        return Task.CompletedTask;
    }

    public async Task RemoveByIdAsync(TId id)
    {
        TModel? entity = await _dbSet.FirstOrDefaultAsync();

        if(entity is not null)
        {
            _dbSet.Remove(entity);
        }
    }
}
