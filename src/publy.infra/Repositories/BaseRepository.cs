using Publy.Domain.Entities;
using Publy.Infra.Interfaces;
using Publy.Infra.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Publy.Infra.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : Base
  {
    private readonly PublyContext _context;

    public BaseRepository(PublyContext context)
    {
      _context = context;
    }

    public virtual async Task<T> Create(T obj)
    {
      _context.Add(obj);
      await _context.SaveChangesAsync();

      return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
      _context.Entry(obj).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return obj;
    }

    public virtual async Task<T> GetById(Guid id)
    {
      T obj = await _context
                .Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

      return obj;
    }

    public virtual async Task<List<T>> GetAll()
    {
      return await _context.Set<T>()
                            .AsNoTracking()
                            .ToListAsync();
    }

    public virtual async Task Remove(Guid id)
    {
      T obj = await GetById(id);

      if (obj != null)
      {
        _context.Remove(obj);
        await _context.SaveChangesAsync();
      }
    }
  }
}
