using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Publy.Domain.Entities;

namespace Publy.Infra.Interfaces
{
  public interface IBaseRepository<T> where T : Base
  {
    Task<T> Create(T obj);
    Task<T> Update(T obj);
    Task<T> GetById(Guid id);
    Task<List<T>> GetAll();
    Task Remove(Guid id);
  }
}
